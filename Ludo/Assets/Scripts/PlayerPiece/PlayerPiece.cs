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
   }


   public void makePlayerReadyToMove(PathPoints[] pathPointsToMoveOn_)
   {
    isReady = true;
    transform.position = pathPointsToMoveOn_[0].transform.position;
    numberOfStepsAlreadyMoved = 1;

    previousPathPoint = pathPointsToMoveOn_[0];
    currentPathPoint = pathPointsToMoveOn_[0];
    // currentPathPoint.AddPathPoint(this);
    GameManager.gm.AddPathPoint(currentPathPoint);

    GameManager.gm.canDiceRoll = true;
    GameManager.gm.SelfDice = true;
    GameManager.gm.trasferDice = false;

   }

   IEnumerator MoveSteps_Enum(PathPoints[] pathPointsToMoveOn_)
    {
        GameManager.gm.trasferDice = false;
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
                    GetComponent<AudioSource>().Play();
                    yield return new WaitForSeconds(0.25f);
                }
            }    
        }
        
        if(isPathPointAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
        {
            // GameManager.gm.trasferDice = false;
            numberOfStepsAlreadyMoved += numOfStepsToMove;
        
            GameManager.gm.RemovePathPoint(previousPathPoint);
            previousPathPoint.RemovePlayerPiece(this);
            currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];

            if(currentPathPoint.AddPlayerPiece(this))
            {
                if(numberOfStepsAlreadyMoved == 57)
                {
                    GameManager.gm.SelfDice = true;
                }
                else
                {
                    if(GameManager.gm.numOfStepsToMove != 6)
                    {
                        GameManager.gm.trasferDice = true;
                    }
                    else
                    {
                        GameManager.gm.SelfDice = true;
                    }
                }
            }
            else
            {
                GameManager.gm.SelfDice = true;
            }


            GameManager.gm.AddPathPoint(currentPathPoint);
            previousPathPoint = currentPathPoint;
            GameManager.gm.numOfStepsToMove = 0;
   

            // if(GameManager.gm.numOfStepsToMove != 6)
            // {
            //     GameManager.gm.trasferDice = true;
            // }
            // else
            // {
            //     GameManager.gm.SelfDice = true;
            // }
        }

        // GameManager.gm.canMove = true;
        GameManager.gm.RollingDiceManager();

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
 