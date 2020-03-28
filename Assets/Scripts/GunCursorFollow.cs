using UnityEngine;
//SCRIPT BELONGS ON THE PLAYER PREFAB
//Allows the gun to follow the mouse

public class GunCursorFollow : MonoBehaviour
{
    public GameObject gun;//the gun prefab that the player has equipt
    public GameObject equiptGun;//the actual object of the equipt gun
    void Start()
    {
        //create a gun in game 
        equiptGun = Instantiate(gun, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        float zrot; // controlls the rotation of the gun in the z axis
        Quaternion rotation = new Quaternion(0, 0, 0, 0);// controlls the overall rotation of the gun

        //gets the in game mouse position using in game stats
        Vector3 mousePosition = FindObjectOfType<GameStats>().gameObject.GetComponent<GameStats>().inGameMousePosition;

        //creates a unitvector at the origin which points in the direction of the mouse from the players perspective
        Vector3 direction = Vector3.Normalize(Vector3.Scale(mousePosition, new Vector3(1, 1, 0)) - transform.position);

        //calculates the z axis rotation of the gun IN RADIANS
        zrot = Mathf.Atan(direction.y / direction.x);

        //This chunk converts the z rotation into a quaternion 
        //////////////////////////////////////////////////////
        if (direction.x >= 0)
        {
            equiptGun.gameObject.transform.localScale = new Vector3(.5f, .5f, 1f);//flips the gun appropriately
            rotation.eulerAngles = new Vector3(0, 0, (Mathf.Rad2Deg * zrot));
        }
        else
        {
            equiptGun.gameObject.transform.localScale = new Vector3(.5f, -.5f, 1f);//flips the gun appropriately
            rotation.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * zrot + 180);
        }
        //////////////////////////////////////////////////////
        
        //Applies the rotation to the gun
        equiptGun.gameObject.transform.rotation = rotation;
    }

}
