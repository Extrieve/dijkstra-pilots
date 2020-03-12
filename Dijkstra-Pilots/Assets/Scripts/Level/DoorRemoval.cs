using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRemoval : MonoBehaviour
{
    public GameObject[] rayPoints = new GameObject[4];
    public GameObject[] doors = new GameObject[4];
    public GameObject[] hallPoints = new GameObject[4];
    public GameObject hallPrefab;

    private void Start()
    {
        Debug.Log("Removing");
        for (int i = 0; i < 4; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayPoints[i].transform.position, rayPoints[i].transform.forward, 10);

            if (hit.collider != null || hit.transform != null)
            {
                Debug.Log("Hit: " + hit.collider.gameObject);
                doors[i].SetActive(false);

                GameObject target;

                if (i == 0 || i == 2)
                    Instantiate(hallPrefab, hallPoints[i].transform);
                else
                {
                    target = Instantiate(hallPrefab, hallPoints[i].transform);
                    target.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }
    }
}
