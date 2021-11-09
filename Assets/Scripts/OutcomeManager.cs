using UnityEngine;

public class OutcomeManager : MonoBehaviour
{

    public void SelectWin()
    {
        PlayingState.SetGameOutcome("Win");
    }

    public void SelectLoss()
    {
        PlayingState.SetGameOutcome("Lose");
    }

    public void SelectDraw()
    {
        PlayingState.SetGameOutcome("Draw");
    }

    public void ProcessOutcomeCall()
    {
        PlayingState.ProcessOutcome();
    }
}
