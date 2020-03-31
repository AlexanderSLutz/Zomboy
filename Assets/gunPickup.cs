 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;
    public GameObject gameManager;
    public GameObject equipText;
    bool close = false;
    GameObject pickUp;
    GameObject oldGun;
    GameObject gunIcon;
    void Start()
    {
        gunIcon =Instantiate(gun, transform.position, transform.rotation);
        gunIcon.transform.localScale = new Vector3(.5f, .5f, 1);
    }



    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pickUp = Instantiate(equipText, transform.position, transform.rotation);
            close = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(pickUp); 
            close = false;
        }
    }
    void Update()
    {
        oldGun = player.GetComponent<GunCursorFollow>().equiptGun;
        if (Input.GetKey("e") && close) { 
            switch (gameManager.GetComponent<InventorySystem>().selectedSlot)
            {
                case 1:
                    gameManager.GetComponent<SwitchWeapon>().weapon1 = gun;
                    break;
                case 2:
                    gameManager.GetComponent<SwitchWeapon>().weapon2 = gun;
                    break;
                default:
                    gameManager.GetComponent<SwitchWeapon>().weapon3 = gun;
                    break;
            }
            gameManager.GetComponent<SwitchWeapon>().Switch(gameManager.GetComponent<InventorySystem>().selectedSlot);
            Destroy(gunIcon);
            Destroy(gameObject);
            //gameObject.GetComponent<gunPickup>().gun = oldGun;
            //Start(); 
        }
    }
}
