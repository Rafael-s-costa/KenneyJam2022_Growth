using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private HexType Type;
    public DisorderType disorderType { get; set; } = DisorderType.None;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameStateManager.Instance.SelectHex(this);
        }
    }

    public HexType getType()
    {
        return Type;
    }
}
