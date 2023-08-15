using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlayerTurn = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void EndTurnPlayer()
    {
        isPlayerTurn = false;
    }

    public void EndTurnOpponent()
    {
        isPlayerTurn = true;
    }

    // public bool IsPlayerTurn()
    // {
    // return isPlayerTurn;
    // }

    // public bool IsOpponentTurn()
    // {
    // return !isPlayerTurn;
    // }
}
