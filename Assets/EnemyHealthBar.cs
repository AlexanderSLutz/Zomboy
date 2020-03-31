using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public float enemyMaxHealth;
    void Update()
    {
        enemyMaxHealth = 1;// (float)gameObject.GetComponentInParent<EnemyStats>().maxHealth;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(enemyMaxHealth, 1, 1);

    }
}
