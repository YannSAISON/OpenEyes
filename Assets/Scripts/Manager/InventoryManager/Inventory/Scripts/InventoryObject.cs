using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject {
    public string savePath = "/Inventory.Save";
    public ItemDatabaseObject database;
    public Inventory Container;

    public void AddItem(Item item, int amount) {
        if (item.Buffs.Length > 0) {
            Container.items.Add(new InventorySlot(item.id, item, amount));
            return;
        }

        for (int i = 0; i < Container.items.Count; i++) {
            if (Container.items[i].item.id == item.id) {
                Container.items[i].AddAmount(amount);
                return;
            }
        }

        Container.items.Add(new InventorySlot(item.id, item, amount));
    }

    [ContextMenu("Save")]
    public void Save() {
        IFormatter formatter = new BinaryFormatter();
        string pathToCheck = string.Concat(Application.persistentDataPath, savePath);
        Stream stream = new FileStream(pathToCheck, FileMode.Create, FileAccess.Write);

        formatter.Serialize(stream, Container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load() {
        string pathToCheck = string.Concat(Application.persistentDataPath, savePath);

        if (!File.Exists(pathToCheck)) return;
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(pathToCheck, FileMode.Open, FileAccess.Read);
        Container = (Inventory) formatter.Deserialize(stream);
        stream.Close();
    }

    [ContextMenu("Clear")]
    public void Clear() {
        Container = new Inventory();
    }
}

[System.Serializable]
public class Inventory {
    public List<InventorySlot> items;
}

[System.Serializable]
public class InventorySlot {
    public int id;
    public Item item;
    public int amount;

    public InventorySlot(int id, Item item, int amount) {
        this.id = id;
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value) {
        amount += value;
    }
}
