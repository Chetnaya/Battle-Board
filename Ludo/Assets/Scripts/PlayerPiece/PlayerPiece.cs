using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    
   public bool isReady; 
   public bool canMove;
   public bool moveNow;
   public int numberOfStepsAlreadyMoved;

   public Color color;
   public Vector3 originalPosition;


   public PathObjectsParent pathsParent;
   public PathPoints previousPathPoint;
   public PathPoints currentPathPoint;

   Coroutine MoveSteps_Coroutine;

   void Start()
   {
     originalPosition = transform.position;  
   }

   private void Awake()
   {
    pathsParent = FindObjectOfType<PathObjectsParent>();
   }

   public void MoveSteps(PathPoints[] pathPointsToMoveOn_)
   {
      MoveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));

      //Check if the current path point has any opponent player pieces
      if(currentPathPoint != null)
      {
        foreach(PlayerPiece playerPiece in currentPathPoint.playerPiecesList)
        {
            if (playerPiece != this && playerPiece.color != color)
            {
                // Kill the opponent player piece
                playerPiece.Kill();
                break;
            }
        }
      }
   }

   public void Kill()
   {
    // Reposition the player piece to the original position and make it not ready to move
    isReady = false;
    canMove = false;
    transform.position = originalPosition;
    numberOfStepsAlreadyMoved = 0;
    previousPathPoint = null;
    currentPathPoint.RemovePlayerPiece(this);
    currentPathPoint = null;
    }

   public void makePlayerReadyToMove(PathPoints[] pathPointsToMoveOn_)
   {
    isReady = true;
    transform.position = pathPointsToMoveOn_[0].transform.position;
    numberOfStepsAlreadyMoved = 1;

    previousPathPoint = pathPointsToMoveOn_[0];
    currentPathPoint = pathPointsToMoveOn_[0];

    // GameManager.gm.RemovePathPoint(previousPathPoint);
    GameManager.gm.AddPathPoint(currentPathPoint);

   }

   IEnumerator MoveSteps_Enum(PathPoints[] pathPointsToMoveOn_)
    {
        yield return new WaitForSeconds(0.25f);

        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;

        if(canMove)
        {
            previousPathPoint.RescaleAndRepositionAllPlayerPieces();

            for(int i =numberOfStepsAlreadyMoved; i< (numberOfStepsAlreadyMoved +numOfStepsToMove); i++)
            {   
                if(isPathPointAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
                {
                    transform.position = pathPointsToMoveOn_[i].transform.position;
                    // GameManager.gm.RemovePathPoint(pathPointsToMoveOn_[i]);
                    yield return new WaitForSeconds(0.25f);
                }
            }    
        }
        
        if(isPathPointAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
        {
            numberOfStepsAlreadyMoved += numOfStepsToMove;

            GameManager.gm.RemovePathPoint(previousPathPoint);
            previousPathPoint.RemovePlayerPiece(this);
            currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];

            currentPathPoint.AddPlayerPiece(this);

            GameManager.gm.AddPathPoint(currentPathPoint);
            previousPathPoint = currentPathPoint;
        }

        if(MoveSteps_Coroutine != null)
        {
            StopCoroutine(MoveSteps_Coroutine);
        }
        
    }
    bool isPathPointAvailableToMove(int numOfStepsToMove_, int numberOfStepsAlreadyMoved_ , PathPoints[] pathPointsToMoveOn_)
    {
        int leftNumberOfPathPoint = pathPointsToMoveOn_.Length - numberOfStepsAlreadyMoved_;

        if(leftNumberOfPathPoint >= numOfStepsToMove_)
        {
            return true;
        }
        return false;
    }

}
 