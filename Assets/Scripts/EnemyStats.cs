using UnityEngine;
//SCRIPT BELONGS ON ALL ENEMY PREFABS
//Contains all stats of the enemy
//MORE HERE LATER(movement etc.)
//
public class EnemyStats : MonoBehaviour
{
    //All enemy stats go here
    public int Health = 100;
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
