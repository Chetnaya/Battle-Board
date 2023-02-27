using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerPiece : PlayerPiece
{
    RollingDice yellowHomeRollingDice;

    private void Start()
    {
        yellowHomeRollingDice = GetComponentInParent<YellowHome>().rollingDice;   
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null && GameManager.gm.rolledDice == yellowHomeRollingDice)
        {
            canMove = true;   
        }

        MoveSteps();
    }
}

