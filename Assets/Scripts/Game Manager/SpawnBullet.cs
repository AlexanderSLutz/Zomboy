using UnityEngine;
//SCRIPT BELONGS ON THE GAME MANAGER
//spawns a bullet in game
//SHOULD ONLY BE called by shoot function

public class SpawnBullet : MonoBehaviour
{
    private Quaternion rotation;//used to control thr rotation of the bullet

    //creates a bullet given the player and the bullet being shot
    public void CreateBullet(GameObject player, GameObject bullet)
    {
        float zrot; // controlls the rotation of the bullet in the z axis
        GameObject clone; // a clone of the bullet

        // controlls the overall rotation of the bullet 
        rotation = new Quaternion(0, 0, 0, 0);

        //gets the in game mouse position using in game stats
        Vector3 mousePosition = FindObjectOfType<GameStats>().gameObject.GetComponent<GameStats>().inGameMousePosition;

        //creates a unitvector at the origin which points in the direction of the mouse from the players perspective
        Vector3 direction = Vector3.Normalize((Vector3.Scale((mousePosition), new Vector3(1, 1, 0)) - player.transform.position));

        //calculates the z axis rotation of the bullet IN RADIANS
        zrot = Mathf.Atan(direction.y / direction.x);

        //This chunk converts the z rotation into a quaternion 
        //////////////////////////////////////////////////////
        if (direction.x >= 0)
        {
            rotation.eulerAngles = new Vector3(0, 0, (Mathf.Rad2Deg * zrot + 90 + 180));
        }
        else
        {
            rotation.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * zrot + 90);
        }
        //////////////////////////////////////////////////////
        
        //Creates bullet in game
        clone = Instantiate(bullet, player.transform.position, rotation);

        //bullet automaticaticaly destroyed after a degsinate damount of time 
        Destroy(clone, clone.GetComponent<Bullet>().despawnTime);

        //adds a velocity to the bullet in the proper direction
        clone.GetComponent<Rigidbody2D>().velocity = direction * bullet.gameObject.GetComponent<Bullet>().bulletSpeed;

    }
}
