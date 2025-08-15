using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickMove : MonoBehaviour
{
    public static float timer;
    private bool isMouseOver = false;
    private bool isSpacePressed = false;
    private PlayerMovement player;

    public Image chargeImage;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HandleKeyboardInput();

        if (isMouseOver || isSpacePressed)
            timer += Time.deltaTime * 10;

        if (player == null)
        {
            CheckIfHighscore();
            ScoreManager.ResetScores();
            BlockMovementManager.blocks.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (chargeImage != null)
        {
            chargeImage.fillAmount = Mathf.Lerp(0, 1, timer - 1);
        }
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSpacePressed)
        {
            Jump();
            isSpacePressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isSpacePressed)
        {
            ResetJumpTimer();
            isSpacePressed = false;
        }
    }

    void CheckIfHighscore()
    {
        if (ScoreManager.score > PlayerPrefsManager.GetHighScore())
        {
            PlayerPrefsManager.SetHighScore(ScoreManager.score);
        }
    }

    public void Jump()
    {
        isMouseOver = true;
        PlayerMovement.dblJmpFlag = true;
    }

    public void ResetJumpTimer()
    {
        if (timer < 1f)
            timer = 1f;
        if (timer > 2)
            timer = 2;
        PlayerMovement player = FindAnyObjectByType<PlayerMovement>();
        PlayerMovement.isJumping = true;
        if (player != null)
            player.Jump(new Vector3(0, 600) * timer);
        timer = 0;
        isMouseOver = false;
    }
}