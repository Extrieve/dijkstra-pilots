using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public List<GameObject> referenceObjects = new List<GameObject>();

    public void SendReferences()
    {
        ReferenceHandler.SetReferences(referenceObjects);
    }
}
