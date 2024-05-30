using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isOpen =false;

    private Animator animator;

    [SerializeField] int CoinGain;

    [SerializeField] AudioClip sound;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        if (!isOpen)
        {
            animator.SetTrigger("OpenChest");
            isOpen = true;
            AudioManager.Instance.PlayClipAt(sound, transform.position);
            Inventory.Instance.AddCoins(CoinGain);
        }
    }
}
