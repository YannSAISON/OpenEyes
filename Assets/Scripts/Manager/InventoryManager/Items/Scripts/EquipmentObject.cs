using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject {
    private void Awake() {
        itemType = ItemTypeEnum.Equipment;
    }
}
