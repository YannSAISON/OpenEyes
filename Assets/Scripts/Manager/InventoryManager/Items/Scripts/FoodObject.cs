using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class FoodObject : ItemObject {
    private void Awake() {
        itemType = ItemTypeEnum.Food;
    }

    public override void BeingUsed(AngerBar angerBar)
    {
    }
}
