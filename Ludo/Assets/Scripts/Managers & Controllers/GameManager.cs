using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int numOfStepsToMove;
    public RollingDice rolledDice;

    List<PathPoints> playerOnPathPointsList = new List<PathPoints>();
    
    public bool canDiceRoll = true;
    public bool trasferDice = false;
    public bool SelfDice = false;

    public int blueOutPlayers;
    public int redOutPlayers;
    public int yellowOutPlayers;
    public int greenOutPlayers;

    public RollingDice[] ManageRollingDice;


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

    public void RollingDiceManager()
    {
        int nextDice;
        if(GameManager.gm.trasferDice)
        {
            //To transfer
            for(int i=0; i<4; i++)
            {
                // if(GameManager.gm.rolledDice == )
            }
        }
        else
        {
            if(GameManager.gm.SelfDice)
            {
                GameManager.gm.SelfDice = false;
                GameManager.gm.canDiceRoll = true;
            }
        }
    }
}
