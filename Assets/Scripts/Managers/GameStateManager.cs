using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance => s_Instance;
    private static GameStateManager s_Instance;

    public Hex selectedHex { get; set; }

    // Turns and moves.
    public int turn { get; private set; }
    public int turnMoves { get; private set; } = 1;
    public int availableMoves { get; private set; }

    public bool inTurn { get; private set; } = true;

    // Disorder.
    public int disorderLevel { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        s_Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (availableMoves == 0)
        {
            EndTurn();

            GenerateDisorder();

            StartTurn();
        }
    }
    

    public void SelectHex(Hex hex)
    {
        selectedHex = hex;

        switch (hex.getType())
        {
            case HexType.Empty:
                OpenBuildHex();
                break;
            case HexType.Water:
            case HexType.Town:
            case HexType.Castle:
            case HexType.Food:
            case HexType.Plain:
                OpenFixHex(hex);
                break;
            default:
                break;
        }
    }

    private void OpenBuildHex()
    {

    }

    public void BuildHex(Hex hex)
    {
        RemoveTurnMove();
    }

    private void OpenFixHex(Hex hex)
    {
        if (!hex.disorderType.Equals(DisorderType.None))
        {

        }
    }

    public void FixHex()
    {
        RemoveTurnMove();
    }

    public void SpawnNeighbouringEmptyHexes(Hex hex)
    {

    }

    private void RemoveTurnMove()
    {
        availableMoves -= 1;
    }

    private void EndTurn()
    {
        inTurn = false;

        turnMoves += 1;
    }

    private void StartTurn()
    {
        availableMoves = turnMoves;
    }

    private void GenerateDisorder()
    {
        Debug.Log("Generating disorder");
    }
}
