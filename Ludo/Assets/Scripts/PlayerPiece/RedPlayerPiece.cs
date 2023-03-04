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
        if(GameManager.gm.rolledDice != null)
        {
            if(!isReady)
            {
                if(GameManager.gm.rolledDice == redHomeRollingDice && GameManager.gm.numOfStepsToMove == 6)
                {
                    makePlayerReadyToMove(pathsParent.RedPathPoints);
                    GameManager.gm.numOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.rolledDice == redHomeRollingDice && isReady)
            {
                canMove = true;   
            }
        }
        
        MoveSteps(pathsParent.RedPathPoints);
    }
}
