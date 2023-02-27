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
        if(GameManager.gm.rolledDice != null)
        {
            if(!isReady)
            {
                if(GameManager.gm.rolledDice == blueHomeRollingDice && GameManager.gm.numOfStepsToMove == 6)
                {
                    makePlayerReadyToMove();
                    GameManager.gm.numOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.rolledDice == blueHomeRollingDice && isReady)
            {
                canMove = true;   
            }
        }

        MoveSteps();
    }

}
