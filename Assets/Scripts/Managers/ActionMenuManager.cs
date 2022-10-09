using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenuManager : MonoBehaviour
{
    public GameObject selectedHex { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (selectedHex == null) return;

        Hex hex = selectedHex.GetComponent<Hex>();

        switch (hex.getType())
        {
            case HexType.Empty:
                // Open build context;
                break;
            default:
                // Open disorder context;
                break;
        }
    }

    // Function generates items for the action menu, based on the selected hex transform.
    // Generates from the possible types in the file HexType.
    public void GenerateBuildMenu(Transform transform)
    {
        
    }
}