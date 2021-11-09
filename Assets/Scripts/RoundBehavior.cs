using System;
using UnityEngine;

public class RoundBehavior : MonoBehaviour
{

    public static Action OnRoundComplete;


    private void Start()
    {
        ResetRounds();
        OnRoundComplete?.Invoke();
    }
    public void AddRound()
    {
        GameData.Rounds++;
        OnRoundComplete?.Invoke();
    }
    public void ResetRounds()
    {
        {
            GameData.Rounds = 1;
            OnRoundComplete?.Invoke();
        }
    }

}
