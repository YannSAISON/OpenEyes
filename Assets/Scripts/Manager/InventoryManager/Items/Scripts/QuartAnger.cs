using UnityEngine;

[CreateAssetMenu(fileName = "New Quart Anger", menuName = "Inventory System/Items/QuartAnger")]
public class QuartAnger : ItemObject {
    private void Awake() {
        itemType = ItemTypeEnum.Quart_Anger;
    }

    public override void BeingUsed(AngerBar angerBar)
    {
        angerBar.ChangeStatusAngry(angerBar.size / 4);
    }
}
