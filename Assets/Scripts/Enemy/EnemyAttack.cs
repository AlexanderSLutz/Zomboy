using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = transform.position;
        float distance = Vector3.Magnitude(playerPos - enemyPos);

        //Debug.Log(distance);

        if (distance < gameObject.GetComponent<EnemyStats>().attackRange)
        {
            player.GetComponent<PlayerStats>().currentPlayerHealth -= gameObject.GetComponent<EnemyStats>().enemyDamage;
        }
    }
}
