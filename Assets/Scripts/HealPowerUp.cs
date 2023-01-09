using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    private int healAmount = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
