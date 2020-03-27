using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public int jumpHeight = 100;
    public int moveSpeed = 100;
    public Animator animation;
    
    bool facingright = true;
    bool touchingFloor = false;

    void FixedUpdate()
    {
        

        animation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetKey("space"))
        {
            if (touchingFloor)
            {
                rb.velocity = (new Vector2(0, jumpHeight));
                touchingFloor = false;
            }
           
        }
        if (Input.GetKey("d"))
        {
            if (!facingright)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingright = true;
            }
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            animation.SetFloat("Speed", 7);
        }
        if (Input.GetKey("a"))
        {

            if (facingright)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingright = false;
            }
           
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }


        

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        touchingFloor = true;
    }
}
