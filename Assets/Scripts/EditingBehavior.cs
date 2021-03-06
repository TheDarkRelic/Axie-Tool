using UnityEngine;
/// <summary>
/// Controls the editing of the app
/// </summary>
public class EditingBehavior : MonoBehaviour
{

    [Header("CritTracker Script Object")]
    [SerializeField] CritTrackerBehavior critTracker;
    [Header("MatchesPlayedBehavior Script Object")]
    [SerializeField] MatchesPlayedBehavior Matches;
    [Header("Edit Panel Object")]
    [SerializeField] GameObject editPanel;


    public void OpenEditPanel() {editPanel.SetActive(true); }
    public void CloseEditPanel() { editPanel.SetActive(false); }

    public void AddOurCritEdit() { critTracker.AddOurCrit(); }
    public void RemoveOurCritEdit() { critTracker.RemoveOurCritEdit(); }

    public void AddTheirCritEdit() { critTracker.AddTheirCrit(); }
    public void RemoveTheirCritEdit() { critTracker.RemoveTheirCritEdit(); }

    public void AddMatchesPlayed() { Matches.AddMatch(); }
    public void RemoveMatchesPlayed() { Matches.RemoveMatchEdit(); }

    public void AddWinEdit() 
    {
        WinLogic.AddWin();
    }

    public void RemoveWinEdit() 
    {
        if (GameData.Wins == 0) { return; }
        WinLogic.RemoveWin();
        RemoveMatchesPlayed();
    }

    public void AddLossEdit() 
    {
        LoseLogic.AddLoss();
    }

    public void RemoveLossEdit()
    {
        if (GameData.Loses == 0) { return; }
        LoseLogic.RemoveLoss();
        RemoveMatchesPlayed();
    }

    public void AddDrawEdit()
    {
        DrawLogic.AddDraw();
    }

    public void RemoveDrawEdit()
    {
        if (GameData.Draws == 0) { return; }
        DrawLogic.RemoveDraw();
        RemoveMatchesPlayed();
    }

}
