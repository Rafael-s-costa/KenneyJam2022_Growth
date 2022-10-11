using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => s_Instance;
    private static GameManager s_Instance;

    private HexGrid hexGrid;
    private ActionMenuManager actionMenuManager;
    private UIManager uiManager;

    public Hex selectedHex { get; set; }

    // Turns and moves.
    public int turn { get; private set; } = 1;
    public int turnMoves { get; private set; } = 1;
    public int availableMoves { get; private set; } = 1;

    public bool inTurn { get; private set; } = true;

    // Disorder.
    public int disorderLevel { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        s_Instance = this;
    }

    void Start()
    {
        hexGrid = GameObject.Find("HexGrid").GetComponent<HexGrid>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        GameObject castleObject = hexGrid.SpawnHex("castle", hexGrid.gameObject.transform);

        SpawnNeighbouringEmptyHexes(castleObject.transform);
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
    

    public void SelectHex(GameObject hexObject)
    {
        selectedHex = hexObject.GetComponent<Hex>();

        switch (selectedHex.getType())
        {
            case HexType.Empty:
                OpenBuildHex(hexObject);
                break;
            case HexType.Water:
            case HexType.Town:
            case HexType.Castle:
            case HexType.Food:
            case HexType.Plain:
            case HexType.Forest:
                OpenFixHex(selectedHex);
                break;
            default:
                break;
        }
    }

    private void OpenBuildHex(GameObject emptyHex)
    {
        Transform emptyHexTransform = emptyHex.transform;
        GameObject newHex = hexGrid.SpawnHex("farm", emptyHexTransform);
        SpawnNeighbouringEmptyHexes(newHex.transform);
        RemoveTurnMove();

        Destroy(emptyHex);
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

    private void SpawnNeighbouringEmptyHexes(Transform hexTransform)
    {
        hexGrid.SpawnNeighbouringEmptyHexes(hexTransform);
    }

    private void RemoveTurnMove()
    {
        availableMoves -= 1;

        UpdateTurnUI();
    }

    private void EndTurn()
    {
        inTurn = false;

        turnMoves += 1;
    }

    private void StartTurn()
    {
        turn++;
        availableMoves = turnMoves;

        uiManager.SetTurnText(turn);
        UpdateTurnUI();
    }

    private void GenerateDisorder()
    {
        Debug.Log("Generating disorder");
    }

    private void UpdateTurnUI()
    {
        uiManager.SetAvailableMoves(availableMoves, turnMoves);
    }
}
