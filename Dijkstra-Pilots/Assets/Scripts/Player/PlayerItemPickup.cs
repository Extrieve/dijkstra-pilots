﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickup : MonoBehaviour
{
    private PlayerKeys pKeys;
    private PlayerShoot pShoot;

    private void Awake()
    {
        pKeys = GetComponent<PlayerKeys>();
        pShoot = GetComponent<PlayerShoot>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            pKeys.AddKey(collision.gameObject.GetComponent<ItemInfo>());

            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Weapon"))
        {
            pShoot.SetSecondaryWeapon(collision.gameObject.GetComponent<PlayerWeapon>());

            collision.gameObject.SetActive(false);
        }
    }
}
