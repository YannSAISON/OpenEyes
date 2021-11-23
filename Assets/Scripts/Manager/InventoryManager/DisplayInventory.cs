using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour {
    public GameObject inventoryPrefabs;
    public InventoryObject inventoryObject;
    public float xStart = 165.0f;
    public float yStart = 165.0f;
    public float xSpaceBetweenItems = 165.0f;
    public float ySpaceBetweenItems = 165.0f;
    public int numberColumn = 6;
    private Dictionary<InventorySlot, GameObject> m_ItemDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Awake() {
        m_ItemDisplayed = new Dictionary<InventorySlot, GameObject>();
    }

    private void Start() {
        var i = 0;

        if (inventoryObject.Container.items.Count == 0) {
            return;
        }

        foreach (var slot in inventoryObject.Container.items) {
            var obj = Instantiate(inventoryPrefabs, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            m_ItemDisplayed.Add(slot, obj);
            i++;
        }
    }

    private void Update() {
        if (inventoryObject.Container.items.Count == 0) {
            return;
        }

        for (int i = 0; i < inventoryObject.Container.items.Count; i++) {
            var slot = inventoryObject.Container.items[i];
            if (m_ItemDisplayed.ContainsKey(slot)) {
                m_ItemDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            } else {
                var obj = Instantiate(inventoryPrefabs, Vector3.zero, Quaternion.identity, transform);
                var objImageChildren = obj.GetComponentInChildren<Image>();
                var objTextMeshProUGUIChildren = obj.GetComponentInChildren<TextMeshProUGUI>();
                var item = inventoryObject.database.GETItem[0];
                objTextMeshProUGUIChildren.text = slot.amount.ToString("n0");
                objImageChildren.sprite = item.uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                m_ItemDisplayed.Add(slot, obj);
            }
        }
    }

    private Vector3 GetPosition(int i) {
        float posX = xSpaceBetweenItems * (i % numberColumn);
        float posY = (-ySpaceBetweenItems * (i / numberColumn));
        return new Vector3(posX + xStart, posY + yStart, 0.0f);
    }
}
