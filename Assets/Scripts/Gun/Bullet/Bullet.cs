using UnityEngine;
//SCRIPT BELONGS ON ALL BULLET PREFABS
//This Script establishes the properties of the bullet,
//detects bullet collisions, and destroys the bullet in collisions.
//USE SORTING LAYERS TO MAKE THE BULLET APPEAR BEHIND THE PLAYER
public class Bullet : MonoBehaviour
{
    //all bullet stats go here
    //DO NOT put gun stats(i.e. fire rate) here)
    //public int Damage = 10;
    public float bulletSpeed = 1f;
    public float despawnTime = 2f;

    //a refrence to the player
    public GameObject Player;
    private void Start()
    {
        //Ignores collisions between bullets and the player
        //Allows the bullet to spawn in the center of the player
        //Bullet and player MUST be assigned to layers 8 & 9
        Physics2D.IgnoreLayerCollision(8,9);
        Physics2D.IgnoreLayerCollision(9,9);
    }

    //Detects collisions
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
        //  if an enemy is hit call that enemys WasHit function
        if (collisionInfo.gameObject.tag == "Enemy")
        {
            FindObjectOfType<BulletHit>().gameObject.GetComponent<BulletHit>().WasHit(collisionInfo.gameObject, FindObjectOfType<GunCursorFollow>().equiptGun.GetComponent<GunStats>().gunDamage);
        }
        Destroy(gameObject);
    }
  
}
        //destroy the bullet upon collision
