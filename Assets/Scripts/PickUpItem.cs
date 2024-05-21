using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    [SerializeField] AudioClip sound;

    [SerializeField] Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeItem();
        }
    }

    private void TakeItem()
    {
        Inventory.Instance.AddItem(item);
        AudioManager.Instance.PlayClipAt(sound, transform.position);
        Destroy(gameObject);
    }
}
