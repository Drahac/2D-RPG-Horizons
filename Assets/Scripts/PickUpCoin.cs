using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClipAt(soundEffect, transform.position);
            Inventory.Instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
