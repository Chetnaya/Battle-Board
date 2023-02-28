using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public List<PlayerPiece> playerPiecesList  = new List<PlayerPiece>();

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
        if(playerPiecesList.Count > 1)
        {
            for(int i = 0; i < playerPiecesList.Count; i++)
            {
                playerPiecesList[i].transform.localScale = new Vector3(0.01f, 0.01f, 1f);
            }
        }
    }
}
