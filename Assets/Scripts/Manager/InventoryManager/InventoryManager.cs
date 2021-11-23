using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour {
    public InventoryObject inventory;
    
    //TODO : mettre dans le script du player InventoryManager.Instance.OnTriggerEnter(other);
    private void OnTriggerEnter2D(Collider2D other) {
        var item = other.GetComponent<GroundItem>();

        if (!item) return;
        Item newItem = new Item(item.item);
        inventory.AddItem(newItem, 1);
        Destroy(other.gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            inventory.Load();
        }
    }

    private void OnApplicationQuit() {
        inventory.Container.items.Clear();
    }
}
