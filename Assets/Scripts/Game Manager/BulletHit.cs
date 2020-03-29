using UnityEngine;
//SCRIPT BELONGS ON THE GAME MANAGER
//This script is called when a bullet hits an object with the tag of enemy
//Reduces enemy's health by the damage of the bullet

public class BulletHit : MonoBehaviour
{
    public void WasHit(GameObject hitObject, int damage)
    {
        //gets the health of the enemy and reduces it by the damage of the bullet
        hitObject.GetComponent<EnemyStats>().Health = hitObject.GetComponent<EnemyStats>().Health - damage;
    }
}
