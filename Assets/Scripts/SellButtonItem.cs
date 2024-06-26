using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{

    [SerializeField] private Text itemName;
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemPrice;

    private Item item;

    public void setItemName(string name)
    {
        itemName.text = name;
    }

    public void setItemPrice(string price)
    {
        itemPrice.text = price;
    }

    public void setItemImage(Sprite image)
    {
        itemImage.sprite = image;
    }

    public void setItem(Item item)
    {
        this.item = item;
    }

    public void BuyItem()
    {
        Inventory inventory = Inventory.Instance;

        if (inventory.GetCoinsCount() >= item.cost)
        {
            inventory.AddItem(item);
            inventory.UpdateInventoryUI();
            inventory.AddCoins(-item.cost);
            inventory.UpdateTextUI();
        }
    }

}
