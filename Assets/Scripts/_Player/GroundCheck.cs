using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private void OnCollisionEnter2D()
    {
        PlayerMovement.isGrounded = true;
        PlayerMovement.hasDblJmp = true;
    }

    private void OnCollisionExit2D()
    {
        PlayerMovement.isGrounded = false;
    }
}
