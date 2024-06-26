using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    private int CoinsCount;
    public Text coinsCountText;

    public static Inventory Instance;

    [SerializeField] private List<Item> content= new List<Item>();
    private int contentCurrentIndex=0;

    [SerializeField] private Image itemImageUI;
    [SerializeField] private Sprite emptyItem;
    [SerializeField] private Text itemTextUI;

    [SerializeField] PlayerEffect playerEffect;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'inventaire dans la scene");
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void AddCoins(int Count)
    {
        CoinsCount+=Count;
        UpdateTextUI();
    }

    public int GetCoinsCount()
    {
        return CoinsCount;
    }

    public void SetCoinsCount(int newCoinsCount)
    {
        CoinsCount = newCoinsCount;
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = CoinsCount.ToString();
    }

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.Instance.HealPlayer(currentItem.hpBonus);
        playerEffect.AddSpeed(currentItem.SpeedBonus,currentItem.duration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();


    } 

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        if (contentCurrentIndex < content.Count-1)
        {
            contentCurrentIndex++;
        }
        else
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        if (contentCurrentIndex > 0)
        {
            contentCurrentIndex--;
        }
        else
        {
            contentCurrentIndex = content.Count-1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count == 0)
        {
            itemImageUI.sprite = emptyItem;
            itemTextUI.text = "";
            return;
        }

        itemImageUI.sprite = content[contentCurrentIndex].image;
        itemTextUI.text = content[contentCurrentIndex].name;
    }

    public void AddItem(Item item)
    {
        content.Add(item);
    }
}
