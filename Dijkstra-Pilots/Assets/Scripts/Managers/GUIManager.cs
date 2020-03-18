using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    //call to the player object, get the player shoot script, get the secondary weapon info from it. Use the secondary weapon's image info to change the UI
    //same for the ammo count
    public GameObject player;
    public TextMeshProUGUI ammoText;
    public Image secondaryWeaponImage;
    public Sprite emptyWeapon;
    private int secondaryAmmoCount;

    void Update()
    {
        if (player.GetComponent<PlayerShoot>().GetSecondaryWeapon() != null)
        {
            secondaryWeaponImage.sprite = player.GetComponent<PlayerShoot>().GetSecondaryWeapon().uiImage;
            secondaryAmmoCount = player.GetComponent<PlayerShoot>().GetSecondaryAmmoCount();
            ammoText.text = secondaryAmmoCount.ToString();
        }

        if (player.GetComponent<PlayerShoot>().GetSecondaryWeapon() == null)
        {
            secondaryWeaponImage.sprite = emptyWeapon;
            ammoText.text = 0.ToString();
        }
    }

}
