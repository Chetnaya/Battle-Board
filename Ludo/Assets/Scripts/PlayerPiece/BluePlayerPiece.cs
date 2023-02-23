using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPiece : PlayerPiece
{
    private void Start()
    {
        // MoveSteps();
    }
    private void OnMouseDown()
    {
        canMove = true;
        StartCoroutine("MoveStepsEnum");
    }

    public void MoveSteps()
    {
        for(int i =0; i<6; i++)
        {
            transform.position = pathsParent.commonPathPoints[i].transform.position;
        }
    }

    IEnumerator MoveStepsEnum()
    {
        yield return new WaitForSeconds(0.25f);
        if(canMove)
        {
            for(int i =0; i<6; i++)
            {
                transform.position = pathsParent.commonPathPoints[i].transform.position;
                yield return new WaitForSeconds(0.25f);
            }    
        }
    }
}
