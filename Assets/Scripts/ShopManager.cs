using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField] private Text npc_name;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject sellButtonprefab;
    [SerializeField] private Transform sellButtonParent;

    private bool isOpen = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen)
        {
            CloseShop();
        }
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        npc_name.text = pnjName;
        UpdateItemToSell(items);
        animator.SetBool("IsOpen", true);
    }


    private void UpdateItemToSell(Item[] items)
    {
        for (int i = 0; i < sellButtonParent.childCount; i++)
        {
            Destroy(sellButtonParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(sellButtonprefab, sellButtonParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.setItemName(items[i].name);
            buttonScript.setItemPrice(items[i].cost.ToString());
            buttonScript.setItemImage(items[i].image);
            buttonScript.setItem(items[i]);
        }
    }

    public void CloseShop()
    {
        animator.SetBool("IsOpen", false);
        StartCoroutine(Closing());
    }

    private IEnumerator Closing()
    {
        yield return new WaitForSeconds(1f);
        isOpen = false;
        yield return null;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
