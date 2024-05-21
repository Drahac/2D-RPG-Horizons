using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCredit : MonoBehaviour
{

    [SerializeField] private Animator fadeAnimator;
    private IEnumerator fadeNextImage()
    {
        fadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
    }
}
