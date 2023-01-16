using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    private int healAmount = 2;
    [SerializeField] private AudioClip soundEffect;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClipAt(soundEffect, transform.position);
            PlayerHealth.Instance.HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
