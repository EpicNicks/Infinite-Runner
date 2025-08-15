using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rbod;
    private Vector3 jumpforce = new Vector2(0, 600);
    public static bool isJumping = false, isGrounded = false, isDead = false;
    public static bool canDblJmp, hasDblJmp, dblJmpFlag;

    private Animator anim;

	void Start () {
        rbod = GetComponent<Rigidbody2D>();
        canDblJmp = PlayerPrefsManager.IsUnlocked("Double Jump");

        print("Red coins unlocked: " + PlayerPrefsManager.IsUnlocked("Red Coin").ToString());
        print("Double Jump unlocked: " + PlayerPrefsManager.IsUnlocked("Double Jump").ToString());


        //Set animator
        anim = GetComponent<Animator>();
	}
	

	void Update () {

        isJumping = Input.GetButton("Jump");
        CheckDist();

        //Animations
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("JumpType", Random.Range(0.0f, 1.0f));
    }

    //Unused in this implementation (otherwise, call in FixedUpdate())
    public void Jump()
    {
        float tapModifier = ClickMove.timer;
        Vector3 finalForce = new Vector3(0, jumpforce.y + tapModifier);
        if (isJumping && isGrounded)
        {
            rbod.AddForce(finalForce);
        }
    }

    public void DoubleJump()
    {
        if(!isGrounded && hasDblJmp && canDblJmp)
        {
            hasDblJmp = false;
            rbod.linearVelocity = jumpforce / 25;
            //rbod.AddForce(jumpforce * 1.5f);
        }
    }

    private void FixedUpdate()
    {
        if (dblJmpFlag)
        {
            DoubleJump();
            dblJmpFlag = false;
        }
    }

    public void Jump(Vector3 jumpHeight)
    {
        if (isJumping && isGrounded)
        {
            rbod.AddForce(jumpHeight);
        }
    }

    void CheckDist()
    {
        float xEdgeLeft = transform.position.x + transform.localScale.x / 2.0f;
        float xEdgeRight = transform.position.x - transform.localScale.x / 2.0f;
        float yEdgeDown = transform.position.y - transform.localScale.y / 2.0f;

        if (xEdgeLeft < BlockSpawner.LEFT_EDGE || xEdgeRight > BlockSpawner.RIGHT_EDGE || yEdgeDown < BlockSpawner.BOTTOM_EDGE)
        {
            Destroy(gameObject);
        }
    }
}
