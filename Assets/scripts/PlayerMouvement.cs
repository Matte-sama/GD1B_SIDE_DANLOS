using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpSpeed = 10f;
    public bool ground;

    public bool jumping;
    public Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump")) 
        {
            jumping = true;
        }
        
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (jumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed));
            jumping = false; 
        }
    }
}
