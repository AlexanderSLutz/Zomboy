using System.Collections;//Needed for IEnumerator!!!!!!
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject player;
    bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = transform.position;
        float distance = Vector3.Magnitude(playerPos - enemyPos);

        //Debug.Log(distance);

        if (distance < gameObject.GetComponent<EnemyStats>().attackRange)
        {
            if(canAttack)
            {
                StartCoroutine(ExampleCoroutine());

               
            }

        }
    }




    IEnumerator ExampleCoroutine()
    {
        player.GetComponent<PlayerStats>().currentPlayerHealth -= gameObject.GetComponent<EnemyStats>().enemyDamage;

        canAttack = false;

        //waits for time of fire rate
        yield return new WaitForSeconds(1 / (gameObject.GetComponent<EnemyStats>().attackSpeed));

        //enables shooting again
        canAttack = true;
    }


}
