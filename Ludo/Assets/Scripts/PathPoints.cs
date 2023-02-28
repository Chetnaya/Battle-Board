using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public List<PlayerPiece> playerPieces = new List<PlayerPiece>();

    public void AddPlayerPiece(PlayerPiece playerPiece_)
    {
        playerPieces.Add(playerPiece_);
    }

    public void RemovePlayerPiece(PlayerPiece playerPiece_)
    {
        if(playerPieces.Contains(playerPiece_))
        {
            playerPieces.Remove(playerPiece_);
        }
        // else
        // {
        //     Debug.Log("Path point not found to be removed."); 
        // }
    }
}
