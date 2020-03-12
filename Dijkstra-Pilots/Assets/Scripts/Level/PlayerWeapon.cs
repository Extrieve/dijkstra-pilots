using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : ItemInfo
{
    public float force;
    public int projectileCount;
    public int startingAmmo;
    public int bulletDamage;
    public GameObject projectilePrefab; //the projectile prefab that will be fired when using this weapon
    public Sprite uiImage; //image to be used for the UI display
}
