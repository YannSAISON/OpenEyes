using UnityEngine;

[CreateAssetMenu(fileName = "New Full Anger", menuName = "Inventory System/Items/FullAnger")]
public class FullAnger : ItemObject {
    private void Awake() {
        itemType = ItemTypeEnum.Full_Anger;
    }

    public override void BeingUsed(AngerBar angerBar)
    {
        angerBar.ChangeStatusAngry(angerBar.size);
    }
}
