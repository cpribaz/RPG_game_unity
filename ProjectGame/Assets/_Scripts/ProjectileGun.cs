using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    //bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //gunstats 
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference 
    public Camera fpsCam;
    public Transform attackPoint;
    public Transform targetPoint;

    //Graphics 
    public TextMeshPro ammunitionDisplay;

    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //set ammo display, if it exists 
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    private void MyInput()
    {
        //check if allowd to hold to fire 
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //reload auto when trying to shoot without amo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

       
        //Calculate direction from attack to target 
        Vector3 directionWithoutSpread = targetPoint.position  - attackPoint.position;

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet in shoot direction 
        currentBullet.transform.forward = directionWithoutSpread.normalized;

        //add forces to bullet 
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);


        bulletsLeft--;
        bulletsShot++;

        //invoke resetShot function 
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }


    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

}
