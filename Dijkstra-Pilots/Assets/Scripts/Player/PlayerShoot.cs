﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePosition;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public AudioSource shootSound;
    private int secondaryAmmoCount;


    private PlayerWeapon secondaryWeapon;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            if (Timer.t < 5)
            {
                ScoreScript.scoreValue += 30;
            }
            else if (Timer.t < 15)
            {
                ScoreScript.scoreValue += 20;
            }
            else
            {
                ScoreScript.scoreValue += 10;
            }

            shootSound.Play();
        }

        if((Input.GetButtonDown("Fire2") && secondaryAmmoCount > 0) || (Input.GetButtonDown("Fire2") && secondaryAmmoCount > 0))
        {
            secondaryAmmoCount--;
            ShootSecondary();
        }

        if (secondaryAmmoCount <= 0)
            RemoveSecondaryWeapon();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePosition.up * bulletForce, ForceMode2D.Impulse);
    }

    private void ShootSecondary() //fire the weapon but use information from the secondary weapon to fire
    {
        GameObject bullet = Instantiate(secondaryWeapon.projectilePrefab, firePosition.position, firePosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePosition.up * secondaryWeapon.force, ForceMode2D.Impulse);
    }

    public void SetSecondaryWeapon(PlayerWeapon newWeapon)
    {
        secondaryWeapon = newWeapon;
        secondaryAmmoCount = secondaryWeapon.startingAmmo;
    }

    public void RemoveSecondaryWeapon()
    {
        secondaryWeapon = null;
    }

    public PlayerWeapon GetSecondaryWeapon()
    {
        return secondaryWeapon;
    }

    public int GetSecondaryAmmoCount()
    {
        return secondaryAmmoCount;
    }
}
