using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour {
    public InventoryObject inventory;
    public static InventoryManager Instance { get; private set; }


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //TODO : mettre dans le script du player InventoryManager.Instance.OnTriggerEnter(other);
    public void AddNewGroundItem(Collider2D other) {
        var item = other.GetComponent<GroundItem>();

        if (!item) return;
        Item newItem = new Item(item.item);
        inventory.AddItem(newItem, 1);
        Destroy(other.gameObject);
    }

    public bool InventoryAsFullAnger() {
        return inventory.InventoryAsFullAnger();
    }

    public void RemoveFullAnger() {
        inventory.RemoveFullAnger();
    }

    public bool InventoryAsQuartAnger() {
        return inventory.InventoryAsQuartAnger();
    }

    public int InventoryGetNumberOfQuartAnger() {
        return inventory.InventoryGetNumberOfQuartAnger();
    }
    public void RemoveQuartAnger() {
        inventory.RemoveQuartAnger();
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
