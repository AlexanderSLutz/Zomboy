using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject player;
    public void Switch(int newSlot)
    {
        switch (newSlot)
        {
            case 1:
                if (weapon1 != null)
                {
                    player.GetComponent<Shoot>().bullet = weapon1.GetComponent<GunStats>().bulletType;
                    player.GetComponent<GunCursorFollow>().gun = weapon1;
                    player.GetComponent<GunCursorFollow>().Create();
                    
                }
                break;
            case 2:
                if (weapon2 != null)
                {
                    player.GetComponent<Shoot>().bullet = weapon2.GetComponent<GunStats>().bulletType;
                    player.GetComponent<GunCursorFollow>().gun = weapon2;
                    player.GetComponent<GunCursorFollow>().Create();
                    
                }
                break;
            default:
                if (weapon3 != null)
                {
                    player.GetComponent<Shoot>().bullet = weapon3.GetComponent<GunStats>().bulletType;
                    player.GetComponent<GunCursorFollow>().gun = weapon3;
                    player.GetComponent<GunCursorFollow>().Create();
                    
                }
                break;
        }
        gameObject.GetComponent<InventorySystem>().UpdateSlot();
    }
}
