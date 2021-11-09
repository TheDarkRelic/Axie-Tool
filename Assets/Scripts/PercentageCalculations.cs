using System;
using UnityEngine;

public class PercentageCalculations : MonoBehaviour
{

    private void OnEnable()
    {
        MatchesPlayedBehavior.OnMatchComplete += CalculateWinLossPercentages;
    }

    private void OnDisable()
    {
        MatchesPlayedBehavior.OnMatchComplete -= CalculateWinLossPercentages;
    }

    public static Action OnCalculation;

    public void CalculateWinLossPercentages()
    {
        GameData.WinPercent = (float) GameData.Wins / GameData.MatchesPlayed * 100;
        GameData.LosePercent = (float) GameData.Loses / GameData.MatchesPlayed * 100;
        GameData.DrawPercent = (float) GameData.Draws / GameData.MatchesPlayed * 100;
        OnCalculation?.Invoke();
    }

    

    

}
