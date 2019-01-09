using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickMove : MonoBehaviour {

    ///Implement to increase jump height as screen is tapped
    ///Check if player is before apex of jump and add force
    public static float timer;
    private bool isMouseOver = false;
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (isMouseOver)
            timer += Time.deltaTime * 10;

        if (player == null)
        {
            CheckIfHighscore();
            ScoreManager.ResetScores();
            BlockMovementManager.blocks.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void CheckIfHighscore()
    {
        if(ScoreManager.score > PlayerPrefsManager.GetHighScore())
        {
            PlayerPrefsManager.SetHighScore(ScoreManager.score);
        }
    }

    //OnMouseEnter
    public void Jump()
    {
        isMouseOver = true;
        PlayerMovement.dblJmpFlag = true;
    }
    //OnMouseExit
    public void ResetJumpTimer()
    {
        //set min for jump
        if (timer < 1f)
            timer = 1f;
        //set cap for jump height
        if (timer > 2)
            timer = 2;

        PlayerMovement player = GameObject.FindObjectOfType<PlayerMovement>();
        PlayerMovement.isJumping = true;
        if (player != null)
            player.Jump(new Vector3(0, 600) * timer);
        timer = 0;

        isMouseOver = false;
    }
}
