using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetControl : MonoBehaviour
{
    private KeyCode firePrimary = KeyCode.Mouse0;
    private KeyCode fireSecondary = KeyCode.Mouse1;
    public Button primaryFireButton;
    public Button secondaryFireButton;

    private KeyCode keyToAssign;
    private int currentIndex;

    public void SetNewKey(int index)
    {
        currentIndex = index;
        StartCoroutine(WaitForKeyDown());
    }

    private IEnumerator WaitForKeyDown()
    {
        while (!Input.anyKeyDown)
            yield return null;

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                keyToAssign = vKey;
                break;
            }
        }

        switch (currentIndex)
        {
            case 0:
                firePrimary = keyToAssign;
                primaryFireButton.GetComponentInChildren<TextMeshProUGUI>().text = keyToAssign.ToString();
                break;
            case 1:
                fireSecondary = keyToAssign;
                secondaryFireButton.GetComponentInChildren<TextMeshProUGUI>().text = keyToAssign.ToString();
                break;
        }
    }
}
