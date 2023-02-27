using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
   public bool isReady; 
   public bool canMove;
   public bool moveNow;
   public int numberOfStepsAlreadyMoved;

   public PathObjectsParent pathsParent;

   Coroutine MoveSteps_Coroutine;

   private void Awake()
   {
    pathsParent = FindObjectOfType<PathObjectsParent>();
   }

   public void MoveSteps(PathPoints[] pathPointsToMoveOn_)
   {
      MoveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));
   }

   public void makePlayerReadyToMove(PathPoints[] pathPointsToMoveOn_)
   {
    isReady = true;
    transform.position = pathPointsToMoveOn_[0].transform.position;
    numberOfStepsAlreadyMoved = 1;
   }

   IEnumerator MoveSteps_Enum(PathPoints[] pathPointsToMoveOn_)
    {
        yield return new WaitForSeconds(0.25f);

        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;

        if(canMove)
        {
            for(int i =numberOfStepsAlreadyMoved; i< (numberOfStepsAlreadyMoved +numOfStepsToMove); i++)
            {
                transform.position = pathPointsToMoveOn_[i].transform.position;
                yield return new WaitForSeconds(0.25f);
            }    
        }
        numberOfStepsAlreadyMoved += numOfStepsToMove;

        if(MoveSteps_Coroutine != null)
        {
         StopCoroutine(MoveSteps_Coroutine);
        }
        
    }

}
 