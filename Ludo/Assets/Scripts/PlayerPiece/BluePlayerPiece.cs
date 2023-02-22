using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPiece : PlayerPiece
{
    private void Start()
    {
        MoveSteps();
    }
    public void MoveSteps()
    {
        for(int i =0; i<3; i++)
        {
            transform.position = pathsParent.commonPathPoints[i].transform.position;
        }
    }

    IEnumerator MoveStepsEnum()
    {
        for(int i =0; i<3; i++)
        {
            transform.position = pathsParent.commonPathPoints[i].transform.position;
            yield return new WaitForSeconds(1f);
        }
        // transform.position = commonPathPoints[i].transform.position;
        // yield return new WaitForSeconds(1f);
    }
}
