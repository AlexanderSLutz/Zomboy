using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public int jumpHeight = 100;
    public int moveSpeed = 100;
    public Animator animation;
    public GameObject gameManager;
    public float backwardsSpeedFactor = .8f;
    
    public bool facingright = true;
    bool touchingFloor = false;

    void FixedUpdate()
    {

        Vector3 mousePosition = gameManager.GetComponent<GameStats>().inGameMousePosition;
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
                rb.velocity = new Vector2(moveSpeed * backwardsSpeedFactor, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }


        if (Input.GetKey("a"))
        {
            if (facingright)
            {
                rb.velocity = new Vector2(-moveSpeed * backwardsSpeedFactor, rb.velocity.y) ;
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed , rb.velocity.y);
            }
                    
            
        }
        if (mousePosition.x > transform.position.x && !facingright)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingright = true;
        }

        else if (mousePosition.x < transform.position.x && facingright)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingright = false;
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        touchingFloor = true;
    }
}
