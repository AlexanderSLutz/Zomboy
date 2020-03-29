using System.Collections;//Needed for IEnumerator!!!!!!
using UnityEngine;
//SCRIPT BELONGS ON THE PLAYER PREFAB
//Allows the player to shoot the currently selected bullet from the currently selected gun
//CURRENTLY only functions in automatic
//LATER add semi auto(easy)
public class Shoot : MonoBehaviour
{
    public GameObject bullet;//a reference to the selected bullet prefab
    private bool canShoot = true;//used to control fire rate

    //detects if the shoot key is pressed and starts fireing
    void Update()
    {
        if (gameObject.GetComponent<GunCursorFollow>().gun.GetComponent<GunStats>().semiAuto)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (canShoot)
                {
                    StartCoroutine(ExampleCoroutine());
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                if (canShoot)
                {
                    StartCoroutine(ExampleCoroutine());
                }
            }
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //disables shooting for duration of fire rate
        canShoot = false;

        if (gameObject.GetComponent<GunCursorFollow>().gun.GetComponent<GunStats>().hasKnockback)
        {
            if (gameObject.GetComponent<Movement>().facingright)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-gameObject.GetComponent<GunCursorFollow>().gun.GetComponent<GunStats>().knockbackFactor,0));
            }

            if (!gameObject.GetComponent<Movement>().facingright)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(gameObject.GetComponent<GunCursorFollow>().gun.GetComponent<GunStats>().knockbackFactor, 0));
            }

        }
    

        //spawns a bullet using the SpawnBullet function
        FindObjectOfType<SpawnBullet>().gameObject.GetComponent<SpawnBullet>().CreateBullet(gameObject, bullet);

        //waits for time of fire rate
        yield return new WaitForSeconds(1 / (gameObject.GetComponent<GunCursorFollow>().gun.GetComponent<GunStats>().fireRate));

        //enables shooting again
        canShoot = true;
    }

}
