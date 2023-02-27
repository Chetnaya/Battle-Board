using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerPiece : PlayerPiece
{
    RollingDice greenHomeRollingDice;

    private void Start()
    {
        greenHomeRollingDice = GetComponentInParent<GreenHome>().rollingDice;   
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null && GameManager.gm.rolledDice == greenHomeRollingDice)
        {
            canMove = true;   
        }

        MoveSteps();
    }
}
