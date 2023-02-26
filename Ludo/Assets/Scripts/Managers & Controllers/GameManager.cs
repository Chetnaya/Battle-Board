using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int numOfStepsToMove;
    public RollingDice rolledDice;

    private void Awake()
    {
        gm =this;        
    }
}
