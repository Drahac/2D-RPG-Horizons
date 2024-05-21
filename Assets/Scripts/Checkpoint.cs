using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.Instance.respawnPoint = transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
