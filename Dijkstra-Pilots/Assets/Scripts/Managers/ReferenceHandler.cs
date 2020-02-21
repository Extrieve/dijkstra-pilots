using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReferenceHandler
{
    public static List<GameObject> referenceObjects = new List<GameObject>();

    public static void SetReferences(List<GameObject> objects)
    {
        referenceObjects = objects;
    }

    public static GameObject GetObject(int ID)
    {
        if (referenceObjects.Count - 1 < ID)
        {
            Debug.LogError("The ID provided is longer than the object list");

            return null;
        }
        else
        {
            return referenceObjects[ID];
        }
    }
}
