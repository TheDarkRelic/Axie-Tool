using System;
using UnityEngine;

public class MatchesPlayedBehavior : MonoBehaviour
{
    public static Action OnMatchComplete;

    private void OnEnable()
    {
        WinLogic.OnWinComplete += AddMatch;
        LoseLogic.OnLoseComplete += AddMatch;
        DrawLogic.OnDrawComplete += AddMatch;
    }

    private void OnDisable()
    {
        WinLogic.OnWinComplete -= AddMatch;
        LoseLogic.OnLoseComplete -= AddMatch;
        DrawLogic.OnDrawComplete -= AddMatch;
    }

    private void Start()
    {
        OnMatchComplete?.Invoke();
    }

    public void AddMatch()
    {
        GameData.MatchesPlayed++;
        PlayerPrefs.SetInt("MatchesPlayed", GameData.MatchesPlayed);
        OnMatchComplete?.Invoke();
    }

    public void RemoveMatch()
    {
        GameData.MatchesPlayed--;
        if (GameData.MatchesPlayed <= 0) { GameData.MatchesPlayed = 0; }
        OnMatchComplete?.Invoke();
    }

    public void RemoveMatchEdit()
    {
        GameData.MatchesPlayed -= 2;
        if (GameData.MatchesPlayed <= 0) { GameData.MatchesPlayed = 0; }
        OnMatchComplete?.Invoke();
    }

}
