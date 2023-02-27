using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPiece : PlayerPiece
{
    RollingDice blueHomeRollingDice;

    private void Start()
    {
        blueHomeRollingDice = GetComponentInParent<BlueHome>().rollingDice;   
    }

    private void OnMouseDown()
    {
        if (GameManager.gm.rolledDice != null && GameManager.gm.rolledDice == blueHomeRollingDice)
        {
            canMove = true;   
        }

        MoveSteps();
    }

}
