using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemObject : ScriptableObject {
    public int ID;
    public Sprite uiDisplay;
    public ItemTypeEnum itemType;
    [TextArea(15, 20)] public string description;
    public ItemBuff[] Buffs;

    public Item CreateItem() {
        Item newItem = new Item(this);

        return newItem;
    }
}

[System.Serializable]
public class Item {
    public string name;
    public int id;
    public ItemBuff[] Buffs;

    public Item(ItemObject itemObject) {
        name = itemObject.name;
        id = itemObject.ID;
        Buffs = new ItemBuff[itemObject.Buffs.Length];
        for (int i = 0; i < Buffs.Length; i++) {
            Buffs[i] = new ItemBuff(itemObject.Buffs[i].min, itemObject.Buffs[i].max);
        }
    }
}

[System.Serializable]
public class ItemBuff {
    public ItemAttribute attribute;
    public int value;
    public int min;
    public int max;

    public ItemBuff(int min, int max) {
        this.min = min;
        this.max = max;
        GenerateValue();
    }

    public void GenerateValue() {
        value = Random.Range(min, max);
    }
}
