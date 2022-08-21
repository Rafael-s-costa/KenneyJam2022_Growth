using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = GetComponent<GameStateManager>();
    }
}
