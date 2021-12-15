using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject {
    private void Awake() {
        itemType = ItemTypeEnum.Default;
    }

    public override void BeingUsed(AngerBar angerBar)
    {
    }
}
