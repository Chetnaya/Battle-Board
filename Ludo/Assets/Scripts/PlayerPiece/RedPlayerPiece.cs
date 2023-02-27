using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerPiece : PlayerPiece
{
    RollingDice redHomeRollingDice;

    private void Start()
    {
        redHomeRollingDice = GetComponentInParent<RedHome>().rollingDice;   
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null && GameManager.gm.rolledDice == redHomeRollingDice)
        {
            canMove = true;   
        }

        MoveSteps();
    }
}
