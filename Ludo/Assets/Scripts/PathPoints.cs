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

    public bool AddPlayerPiece(PlayerPiece playerPiece_)
    {
        if(playerPiecesList.Count > 0 )
        {
            string prePlayerPieceName = playerPiecesList[0].name;
            string currentPlayerPieceName = playerPiece_.name;
        }
        addPlayer(playerPiece_);
        return false;
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
