using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3((float)player.GetComponent<PlayerStats>().currentPlayerHealth / player.GetComponent<PlayerStats>().maxPlayerHealth, 1,1);
    }
}
