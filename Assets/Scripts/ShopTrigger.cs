using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private bool isInRange;

    [SerializeField] private GameObject interactUI;

    [SerializeField] Item[] itemsToSell;

    [SerializeField] string pnjName;


    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.Instance.OpenShop(itemsToSell, pnjName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.SetActive(false);
            ShopManager.Instance.CloseShop();
        }
    }
}
