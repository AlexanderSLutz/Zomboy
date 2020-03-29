using UnityEngine.UI;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject inventory;
    public int selectedSlot = 1;
    void Start()
    {
        inventory.transform.GetChild(selectedSlot - 1).gameObject.GetComponent<Shadow>().effectColor = Color.white;
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
        }
    }
}
