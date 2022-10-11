using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private HexType Type;
    public DisorderType disorderType { get; set; } = DisorderType.None;
    public IDictionary neighbours { get; set; } = new Dictionary<string, Hex>();

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.SelectHex(gameObject);
        }
    }

    public HexType getType()
    {
        return Type;
    }
}
