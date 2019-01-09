using UnityEngine;

public class DeathCheck : MonoBehaviour {

    private void OnCollisionEnter2D()
    {
        PlayerMovement.isDead = true;
    }
}
