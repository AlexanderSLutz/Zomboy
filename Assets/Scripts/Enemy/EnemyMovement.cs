using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    


    // Update is called once per frame
    void FixedUpdate()
    {
        float playerPosition = player.transform.position.x;

        if (Mathf.Abs(transform.position.x - playerPosition) <= gameObject.GetComponent<EnemyStats>().agroRange)
        {
            if(transform.position.x < player.transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<EnemyStats>().movementSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }

            if (transform.position.x > player.transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-gameObject.GetComponent<EnemyStats>().movementSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
        }


    }
}
