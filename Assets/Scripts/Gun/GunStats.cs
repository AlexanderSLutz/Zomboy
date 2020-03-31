using UnityEngine;
//SCRIPT BELONGS ON ALL GUN PREFABS
//Contains all gun stats here
//DO NOT PUT BULLET STATS IN THE GUN SCRIPT
//LATER will have refrence to assoiated bullet??
//

public class GunStats : MonoBehaviour
{
    //All gun stats go here
    public bool hasKnockback = true;
    public float fireRate = 10f;
    public bool semiAuto = false;
    public GameObject bulletType;
    public float knockbackFactor = 10f;
    public int gunDamage = 100;

}


