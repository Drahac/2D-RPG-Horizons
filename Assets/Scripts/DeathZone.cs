using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private Animator fadeAnimator;

    private void Awake()
    {
        fadeAnimator = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer(collision));
        }
    }

    private IEnumerator RespawnPlayer(Collider2D collision)
    {
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.Instance.respawnPoint;

    }
}
