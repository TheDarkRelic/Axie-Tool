using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    private void OnDisable()
    {
        SaveData();
    }


    private void Awake()
    {
        GetWinLoseDrawSavedData();
        GetMatchesPlayedSavedData();
        GetWinLoseDrawPercentageSavedData();
        GetCritPercentageSavedData();
    }
    private void SaveData()
    {
        SaveWins();
        SaveLoses();
        SaveDraws();
        SaveWinPercent();
        SaveLosePercent();
        SaveDrawPercent();
        SaveMatchedPlayed();
    }

    private void GetWinLoseDrawSavedData()
    {
        
        var wins = PlayerPrefs.GetInt("Wins");
        var loses = PlayerPrefs.GetInt("Loses");
        var draws = PlayerPrefs.GetInt("Draws");

        GameData.InitializeWinLoseDrawSaveData(wins, loses, draws);
    }
    private void GetMatchesPlayedSavedData()
    {
        var matchesPlayed = PlayerPrefs.GetInt("MatchesPlayed");
        GameData.InitializeMatchesPlayedSaveData(matchesPlayed);
    }

    private void GetWinLoseDrawPercentageSavedData()
    {
        var winPer = PlayerPrefs.GetFloat("WinPercent");
        var losePer = PlayerPrefs.GetFloat("LosePercent");
        var drawPer = PlayerPrefs.GetFloat("DrawPercent");
        GameData.InitializeWinLoseDrawPercentageData(winPer, losePer, drawPer);
    }

    private void GetCritPercentageSavedData()
    {
        var ourCrits = PlayerPrefs.GetFloat("OurCrits");
        var theirCrits = PlayerPrefs.GetFloat("TheirCrits");
        GameData.InitializeCritPercentageData(ourCrits, theirCrits);
    }

    private void SaveWins() => PlayerPrefs.SetInt("Wins", GameData.Wins);
    private void SaveLoses() => PlayerPrefs.SetInt("Loses", GameData.Loses);
    private void SaveDraws() => PlayerPrefs.SetInt("Draws", GameData.Draws);

    private void SaveWinPercent() => PlayerPrefs.SetFloat("WinPercent", GameData.WinPercent);
    private void SaveLosePercent() => PlayerPrefs.SetFloat("LosePercent", GameData.LosePercent);
    private void SaveDrawPercent() => PlayerPrefs.SetFloat("DrawPercent", GameData.DrawPercent);

    private void SaveMatchedPlayed() => PlayerPrefs.SetInt("MatchesPlayed", GameData.MatchesPlayed);

    public void ClearAllPrefs(int sceneToLoad)
    {
        GameData.MatchesPlayed = 0;
        GameData.Wins = 0;
        GameData.Loses = 0;
        GameData.Draws = 0;
        GameData.WinPercent = 0;
        GameData.LosePercent = 0;
        GameData.DrawPercent = 0;
        GameData.TheirCrits = 0;
        GameData.OurCrits = 0;
        PlayerPrefs.SetInt("IsDisabled", 0);
        SceneManager.LoadScene(sceneToLoad);
    }

}
