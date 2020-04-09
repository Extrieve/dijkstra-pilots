using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private string status;
    public int health = 100; // health that determines when system is destroyed
    private int maxHealth;
    private string[] statusNames = new string[] { "Healthy", "Slightly Hurt", "Badly Hurt", "Barely Alive", "Dying" };
    private string[] systemStatusNames = new string[] { "Operational", "Damaged", "Badly Damaged", "Critical Damage", "Non-Operational" };

    private void Awake()
    {
        maxHealth = health;
    }

    private void Update()
    {
        if(health <= 0)
        {
            health = 0;
        }
    }

    public string GetCurrentStatus(int health, int statusType)
    {
        int code = 0;

        if (health > 75)
            code = 0;
        else if (health <= 75 && health >= 50)
            code = 1;
        else if (health <= 50 && health >= 25)
            code = 2;
        else if (health <= 25 && health >= 1)
            code = 3;
        else if (health <= 0)
            code = 4;

        if (statusType == 0)
            return statusNames[code];
        else 
            return systemStatusNames[code];
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int hp)
    {
        health = hp;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetStatus(string newStatus)
    {
        status = newStatus;
    }

    public string GetStatus()
    {
        return status;
    }

    public void ChangeHealth(int changeAmt)
    {
        health += changeAmt;
    }
}
