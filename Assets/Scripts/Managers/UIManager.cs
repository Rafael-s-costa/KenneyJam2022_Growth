using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text turnText;

    [SerializeField]
    private TMP_Text totalDisorder;

    [SerializeField]
    private TMP_Text famine;

    [SerializeField]
    private TMP_Text revolt;

    [SerializeField]
    private TMP_Text disease;

    [SerializeField]
    private TMP_Text thirst;

    [SerializeField]
    private TMP_Text availableMoves;

    public void SetTurnText(int turn)
    {
        turnText.text = "Turn " + turn;
    }

    public void SetTotalDisorderText(int disorderPercent)
    {
        totalDisorder.text = "Total Disorder" + disorderPercent + "%";
    }

    public void SetFamineText(int famineValue)
    {
        famine.text = famineValue.ToString();
    }

    public void SetRevoltText(int revoltValue)
    {
        revolt.text = revoltValue.ToString();
    }

    public void SetDiseaseText(int diseaseValue)
    {
        disease.text = diseaseValue.ToString();
    }

    public void SetThirstText(int thirstValue)
    {
        thirst.text = thirstValue.ToString();
    }

    public void SetAvailableMoves(int moves, int totalMoves)
    {
        availableMoves.text = moves.ToString() + "/" + totalMoves.ToString();
    }
}
