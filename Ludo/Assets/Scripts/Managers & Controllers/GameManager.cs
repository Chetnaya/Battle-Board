using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int numOfStepsToMove;
    public RollingDice rolledDice;

    List<PathPoints> playerOnPathPointsList = new List<PathPoints>();
    
    bool canDiceRoll = true;


    private void Awake()
    {
        gm =this;        
    }

    public void AddPathPoint(PathPoints PathPoints_)
    {
        playerOnPathPointsList.Add(PathPoints_);
    }

    public void RemovePathPoint(PathPoints PathPoints_)
    {
        if(playerOnPathPointsList.Contains(PathPoints_))
        {
            playerOnPathPointsList.Remove(PathPoints_);
        }
        else
        {
            Debug.Log("Path point not found to be removed."); 
        }
    }
}
