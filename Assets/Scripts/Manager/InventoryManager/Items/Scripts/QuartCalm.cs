using UnityEngine;

[CreateAssetMenu(fileName = "Quart Calm", menuName = "Inventory System/Items/QuartCalm")]
public class QuartCalm : ItemObject
{
    private void Awake()
    {
        itemType = ItemTypeEnum.Quart_Calm;
    }

    public override void BeingUsed(AngerBar angerBar)
    {
        angerBar.ChangeStatusCalm(angerBar.size / 4);
    }
}
