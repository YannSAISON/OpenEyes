using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database Object", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver {
    public ItemObject[] items;
    public Dictionary<int, ItemObject> GETItem = new Dictionary<int, ItemObject>();

    public void OnBeforeSerialize() {
        GETItem = new Dictionary<int, ItemObject>();
    }

    public void OnAfterDeserialize() {
        for (int i = 0; i < items.Length; i++) {
            if (GETItem.ContainsKey(i))
                continue;
            items[i].ID = i;
            GETItem.Add(i, items[i]);
        }
    }
}
