using UnityEngine.UI;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public int selectedSlot = 1;
    void Start()
    {
        inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
        inventory.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<SwitchWeapon>().weapon1.GetComponent<SpriteRenderer>().sprite;
        inventory.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<SwitchWeapon>().weapon2.GetComponent<SpriteRenderer>().sprite;
        inventory.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<SwitchWeapon>().weapon3.GetComponent<SpriteRenderer>().sprite;
        inventory.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = gameObject.GetComponent<SwitchWeapon>().weapon1.GetComponent<SpriteRenderer>().color;
        inventory.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = gameObject.GetComponent<SwitchWeapon>().weapon2.GetComponent<SpriteRenderer>().color;
        inventory.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = gameObject.GetComponent<SwitchWeapon>().weapon3.GetComponent<SpriteRenderer>().color;
    }

    public void UpdateSlot()
    {
        inventory.transform.GetChild(selectedSlot - 1).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = player.GetComponent<GunCursorFollow>().gun.GetComponent<SpriteRenderer>().color;
        inventory.transform.GetChild(selectedSlot - 1).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = player.GetComponent<GunCursorFollow>().gun.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        int currSlot = selectedSlot;
        var s = Input.GetAxis("Mouse ScrollWheel");
        if (s > 0f)
        {
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.black;
            if (selectedSlot != 3)
            {
                selectedSlot++;
            }
            else
            {
                selectedSlot = 1;
            }
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
        }
        else if (s < 0f)
        {
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.black;
            if (selectedSlot != 1)
            {
                selectedSlot--;
            }
            else
            {
                selectedSlot = 3;
            }
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
        }
        if (Input.GetKeyDown("1"))
        {
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.black;
            selectedSlot = 1;
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
        }
        if (Input.GetKeyDown("2"))
        {
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.black;
            selectedSlot = 2;
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
        }
        if (Input.GetKeyDown("3"))
        {
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.black;
            selectedSlot = 3;
            inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
        }
        if (currSlot != selectedSlot)
        {
            GetComponent<SwitchWeapon>().gameObject.GetComponent<SwitchWeapon>().Switch(selectedSlot);
            inventory.transform.GetChild(selectedSlot - 1).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = player.GetComponent<GunCursorFollow>().gun.GetComponent<SpriteRenderer>().sprite;
            inventory.transform.GetChild(selectedSlot - 1).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = player.GetComponent<GunCursorFollow>().gun.GetComponent<SpriteRenderer>().color;

        }
    }
}
