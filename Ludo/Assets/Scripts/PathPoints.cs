using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour

{
    PathPoints[] pathToMoveOn;
    public PathObjectsParent pathObjParent;
    public List<PlayerPiece> playerPiecesList  = new List<PlayerPiece>();

    void Start()
    {
        pathObjParent = GetComponentInParent<PathObjectsParent>();  
    }

    public bool AddPlayerPiece(PlayerPiece playerPiece_)
    {
        if(playerPiecesList.Count == 1 )
        {
            string prePlayerPieceName = playerPiecesList[0].name;
            string currentPlayerPieceName = playerPiece_.name;

            currentPlayerPieceName = currentPlayerPieceName.Substring(0, currentPlayerPieceName.Length-4);

            if(!prePlayerPieceName.Contains(currentPlayerPieceName))
            {
                playerPiecesList[0].isReady = false;

                StartCoroutine( revertOnStart(playerPiecesList[0]));

                playerPiecesList[0].numberOfStepsAlreadyMoved = 0;

                RemovePlayerPiece(playerPiecesList[0]);
                playerPiecesList.Add(playerPiece_);

                return false;
            }
        }
        addPlayer(playerPiece_);
        return true;
    }

    IEnumerator revertOnStart(PlayerPiece playerPiece_)
    {
        if(playerPiece_.name.Contains("Blue"))
        {
            GameManager.gm.blueOutPlayers -= 1;
            pathToMoveOn = pathObjParent.BluePathPoints;
        }
        else if(playerPiece_.name.Contains("Yellow"))
        {
            GameManager.gm.yellowOutPlayers -= 1;
            pathToMoveOn = pathObjParent.YellowPathPoints;
        }
        else if(playerPiece_.name.Contains("Red"))
        {
            GameManager.gm.redOutPlayers -= 1;
            pathToMoveOn = pathObjParent.RedPathPoints;
        }
        else if(playerPiece_.name.Contains("Green"))
        {
            GameManager.gm.greenOutPlayers -= 1;
            pathToMoveOn = pathObjParent.GreenPathPoints;
        }

        //To move the player back to same path after being killed.
        for(int i=playerPiece_.numberOfStepsAlreadyMoved; i>= 0; i--)
        {
            playerPiece_.transform.position = pathToMoveOn[i].transform.position;
            yield return new WaitForSeconds(0.02f);
        }

        //To set the position after the player is killed 
        playerPiece_.transform.position = pathObjParent.BasePathPoints[basePointPosition(playerPiece_.name)].transform.position;
    }

    int basePointPosition(string name)
    {
        for(int i =0; i< pathObjParent.BasePathPoints.Length; i++)
        {
            if(pathObjParent.BasePathPoints[i].name == name)
            {
                return i;
            }

        }
        return -1;
    }

    void addPlayer(PlayerPiece playerPiece_)
    {
        playerPiecesList.Add(playerPiece_);
        RescaleAndRepositionAllPlayerPieces();
    }

    public void RemovePlayerPiece(PlayerPiece playerPiece_)
    {
        if(playerPiecesList.Contains(playerPiece_))
        {
            playerPiecesList.Remove(playerPiece_);
            RescaleAndRepositionAllPlayerPieces();
        } 
    }
    //To rescale the player when they are on the same block
    public void RescaleAndRepositionAllPlayerPieces()
    {
        int plsCount = playerPiecesList.Count;
        bool isOdd = (plsCount % 2) == 0? false :  true;

        int spriteLayers = 0;
        
        int extent = plsCount / 2;
        int counter = 0;
        
        if(isOdd)
        {
            for(int i = -extent; i<=extent; i++)
            {
                playerPiecesList[counter].transform.localScale = new Vector3(pathObjParent.scales[plsCount - 1], pathObjParent.scales[plsCount -1], 1f);

                playerPiecesList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjParent.positionsDifference[plsCount - 1]), transform.position.y, 0f );
                counter++;
            }
        }
        else
        {
            for(int i = -extent; i<extent; i++)
            {
                playerPiecesList[counter].transform.localScale = new Vector3(pathObjParent.scales[plsCount-1], pathObjParent.scales[plsCount - 1], 1f);
                playerPiecesList[counter].transform.position = new Vector3(transform.position.x + ( i * pathObjParent.positionsDifference[plsCount - 1]), transform.position.y, 0f);
                counter++;
            }
        }
        
        for(int i =0; i< playerPiecesList.Count; i++)
        {
            playerPiecesList[i].GetComponent<SpriteRenderer>().sortingOrder = spriteLayers;
            spriteLayers++;
        }
    }
}
