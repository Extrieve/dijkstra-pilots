using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    private List<ItemInfo> keys = new List<ItemInfo>();
    
    public void AddKey(ItemInfo newKey)
    {
        keys.Add(newKey);
    }

    public void UseKey()
    {
        keys.RemoveAt(keys.Count - 1);
    }
}
