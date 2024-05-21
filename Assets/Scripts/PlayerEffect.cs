using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour
{

    public void AddSpeed(int speed, float duration)
    {
        MovePlayer.Instance.ChangeSpeed(speed);
        StartCoroutine(RemomeSpeed (speed, duration));
    }

    private IEnumerator RemomeSpeed(int speed, float duration)
    {
        yield return new WaitForSeconds (duration);
        MovePlayer.Instance.ChangeSpeed(-speed);
    }
}
