using UnityEngine;
//SCRIPT BELONGS ON THE PLAYER PREFAB
//Allows the gun to follow the player
//USE SORTING LAYERS TO HAVE THE GUN APPEAR INFRONT OF THE PLAYER
public class GunPlayerFollow : MonoBehaviour
{
    void Update()
    {
        //Sets the players equiptGun to the position of the player
        gameObject.GetComponent<GunCursorFollow>().equiptGun.gameObject.transform.position = transform.position;
    }
}
