using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public GameObject bulletPrefab;
    public ObjectPool bulletPool;

    public Transform muzzle;

    public int curAmmo;

    public int maxAmmo;

    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;

    private float lastShootTime;

    private bool isPlayer;




    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        if(GetComponent<PlayerController>())
            isPlayer = true;
    }
        

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }
        
        return false;
    }


    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo --;

        GameObject bullet = bulletPool.GetObject();

        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if(isPlayer)
        {
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
        }

    }
}
