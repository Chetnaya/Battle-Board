using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public PathObjectsParent pathObjParent;
    public List<PlayerPiece> playerPiecesList  = new List<PlayerPiece>();

    void Start()
    {
        pathObjParent = GetComponentInParent<PathObjectsParent>();  
    }

    public void AddPlayerPiece(PlayerPiece playerPiece_)
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
    void RescaleAndRepositionAllPlayerPieces()
    {
        int plsCount = playerPiecesList.Count;
        bool isOdd = (plsCount % 2) == 0? false :  true;
        // bool isOdd;
        // if(plsCount % 2 ==0)
        // {
        //     isOdd = false;
        // }
        // else
        // {
        //     isOdd = true;
        // }
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
        // if(playerPiecesList.Count > 1)
        // {
        //     for(int i = 0; i < playerPiecesList.Count; i++)
        //     {
        //         playerPiecesList[i].transform.localScale = new Vector3(pathObjParent.scales[playerPiecesList.Count - 1], pathObjParent.scales[playerPiecesList.Count-1], 1f);
                
        //     }
        // }
    }
}
