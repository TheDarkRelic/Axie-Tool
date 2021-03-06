using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{

    #region Listeners
    private void OnEnable()
    {
        WinLogic.OnWinComplete += DisplayWinLossDrawRecord;
        LoseLogic.OnLoseComplete += DisplayWinLossDrawRecord;
        DrawLogic.OnDrawComplete += DisplayWinLossDrawRecord;

        MatchesPlayedBehavior.OnMatchComplete += DisplayMatchesPlayed;
        PercentageCalculations.OnCalculation += DisplayWinLossDrawPercentages;
        RoundBehavior.OnRoundComplete += DisplayRounds;

        OpponentEnergyEquations.OnEnergyUsed += DisplayEnergyUsed;
        OpponentEnergyEquations.OnEnergyLost += DisplayEnergyLost;
        OpponentEnergyEquations.OnEnergyGained += DisplayEnergyGained;
        OpponentEnergyEquations.OnCurrentEnergyUpdate += DisplayCurrentEnergy;
    }


    private void OnDisable()
    {
        WinLogic.OnWinComplete -= DisplayWinLossDrawRecord;
        LoseLogic.OnLoseComplete -= DisplayWinLossDrawRecord;
        DrawLogic.OnDrawComplete -= DisplayWinLossDrawRecord;

        MatchesPlayedBehavior.OnMatchComplete -= DisplayMatchesPlayed;
        PercentageCalculations.OnCalculation -= DisplayWinLossDrawPercentages;
        RoundBehavior.OnRoundComplete -= DisplayRounds;

        OpponentEnergyEquations.OnEnergyUsed -= DisplayEnergyUsed;
        OpponentEnergyEquations.OnEnergyLost -= DisplayEnergyLost;
        OpponentEnergyEquations.OnEnergyGained -= DisplayEnergyGained;
        OpponentEnergyEquations.OnCurrentEnergyUpdate -= DisplayCurrentEnergy;
    }

    #endregion

    #region Text Fields
    [Header("Wins, Loses & Draw Text")]
    [SerializeField] TMP_Text winsTxt = null;
    [SerializeField] TMP_Text losesTxt = null;
    [SerializeField] TMP_Text drawsTxt = null;

    [Header("Wins, Loses & Draw Percentages Text")]
    [SerializeField] TMP_Text winPerTxt;
    [SerializeField] TMP_Text lossPerTxt;
    [SerializeField] TMP_Text drawPerTxt;

    [Header("Matches Played Text")]
    [SerializeField] TMP_Text matchesPlayedTxt = null;
    [Header("Rounds Text")]
    [SerializeField] TMP_Text roundTxt = null;

    [Header("Opponent Energy Text")]
    [SerializeField] TMP_Text energyUsedTxt = null;
    [SerializeField] TMP_Text energyLostTxt = null;
    [SerializeField] TMP_Text energyGainedTxt = null;
    [SerializeField] TMP_Text currentEnergyTxt = null;
    #endregion

    void Start()
    {
        DisplayWinLossDrawRecord();
        DisplayWinLossDrawPercentages();
    }

    void DisplayRounds() => ConvertIntToText(roundTxt, GameData.Rounds);

    void DisplayWinLossDrawPercentages()
    {
        ConvertFloatToText(winPerTxt, GameData.WinPercent);
        ConvertFloatToText(lossPerTxt, GameData.LosePercent);
        ConvertFloatToText(drawPerTxt, GameData.DrawPercent);
    }

    private void DisplayMatchesPlayed()
    {
        ConvertIntToText(matchesPlayedTxt, GameData.MatchesPlayed);
    }
    public void DisplayWinLossDrawRecord()
    {
        ConvertIntToText(winsTxt, GameData.Wins);
        ConvertIntToText(losesTxt, GameData.Loses);
        ConvertIntToText(drawsTxt, GameData.Draws);
    }
    private void DisplayCurrentEnergy()
    {
        ConvertIntToText(currentEnergyTxt, GameData.CurrentEnergy);
    }

    private void DisplayEnergyGained()
    {
        ConvertIntToText(energyGainedTxt, GameData.EnergyGained);
    }

    private void DisplayEnergyUsed()
    {
        ConvertIntToText(energyUsedTxt, GameData.EnergyUsed);
    }
    private void DisplayEnergyLost()
    {
        ConvertIntToText(energyLostTxt, GameData.EnergyLost);
    }

    void ConvertIntToText(TMP_Text text, int amount) { text.text = $"{amount}"; }
    void ConvertFloatToText(TMP_Text text, float amount) { text.text = $"{amount:f1}%"; }
}
