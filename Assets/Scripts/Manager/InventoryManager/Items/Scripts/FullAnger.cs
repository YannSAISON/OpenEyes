using UnityEngine;

[CreateAssetMenu(fileName = "New Full Anger", menuName = "Inventory System/Items/FullAnger")]
public class FullAnger : ItemObject {
    private void Awake() {
        itemType = ItemTypeEnum.Full_Anger;
    }
}
