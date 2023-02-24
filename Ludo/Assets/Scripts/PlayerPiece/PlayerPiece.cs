using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
   public bool canMove;
   public bool moveNow;
   public int numberOfStepsToMove;

   public PathObjectsParent pathsParent;

   Coroutine MoveSteps_Coroutine;

   private void Awake()
   {
    pathsParent = FindObjectOfType<PathObjectsParent>();
   }

   public void MoveSteps()
   {
      MoveSteps_Coroutine = StartCoroutine(MoveSteps_Enum());
   }

   IEnumerator MoveSteps_Enum()
    {
        yield return new WaitForSeconds(0.25f);

        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;
        if(canMove)
        {
            for(int i =0; i<numOfStepsToMove; i++)
            {
                transform.position = pathsParent.commonPathPoints[i].transform.position;
                yield return new WaitForSeconds(0.25f);
            }    
        }
        
        if(MoveSteps_Coroutine != null)
        {
         StopCoroutine(MoveSteps_Coroutine);
        }
        
    }

}
 