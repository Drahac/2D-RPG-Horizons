using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private float cinematicDuration;
    private float playerMoveSpeed;
    private float playerJumpForce;
    
    void Start()
    {
        MovePlayer movePlayerTemp = MovePlayer.Instance;

        playerMoveSpeed = movePlayerTemp.GetMoveSpeed();
        playerJumpForce = movePlayerTemp.GetJumpForce();

        movePlayerTemp.ChangeJumpForce(-playerJumpForce);
        movePlayerTemp.ChangeSpeed(-playerMoveSpeed);

        StartCoroutine(ResetMovePlayer());

    }

    private IEnumerator ResetMovePlayer()
    {
        yield return new WaitForSeconds(cinematicDuration);

        MovePlayer movePlayerTemp = MovePlayer.Instance;

        movePlayerTemp.ChangeSpeed(playerMoveSpeed);
        movePlayerTemp.ChangeJumpForce(playerJumpForce);


        yield return null;

    }



}
