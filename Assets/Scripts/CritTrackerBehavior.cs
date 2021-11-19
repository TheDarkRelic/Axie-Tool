using TMPro;
using UnityEngine;

public class CritTrackerBehavior : MonoBehaviour
{

    private void OnDisable()
    {
        SaveCrits();
    }

    [SerializeField] TMP_Text ourCritsTxt;
    [SerializeField] TMP_Text theirCritsTxt;
    [SerializeField] TMP_Text ourCritPercentTxt;
    [SerializeField] TMP_Text theirCritPercentTxt;

    private void Start()
    {
        RetrieveCritData();
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
    }

    private void RetrieveCritData()
    {
        GameData.OurCrits = PlayerPrefs.GetFloat("OurCrits");
        ConvertDoubleToText(ourCritsTxt, GameData.OurCrits);


        GameData.TheirCrits = PlayerPrefs.GetFloat("TheirCrits");
        ConvertDoubleToText(theirCritsTxt, GameData.TheirCrits);
    }

    #region Our Crit Methods
    public void AddOurCrit()
    {
        GameData.OurCrits++;
        ConvertDoubleToText(ourCritsTxt, GameData.OurCrits);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
    }


    public void MinusOurCrit()
    {
        GameData.OurCrits--;
        if(GameData.OurCrits <= PlayerPrefs.GetFloat("OurCrits")) { GameData.OurCrits = PlayerPrefs.GetFloat("OurCrits"); }
        ConvertDoubleToText(ourCritsTxt, GameData.OurCrits);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
    }

    public void RemoveOurCritEdit()
    {
        GameData.OurCrits--;
        if (GameData.OurCrits <= 0) { GameData.OurCrits = 0; }
        ConvertDoubleToText(ourCritsTxt, GameData.OurCrits);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
    }
    #endregion

    #region Their Crit Methods
    public void AddTheirCrit()
    {
        GameData.TheirCrits++;
        ConvertDoubleToText(theirCritsTxt, GameData.TheirCrits);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
    }

    public void MinusTheirCrit()
    {
        GameData.TheirCrits--;
        if (GameData.TheirCrits <= PlayerPrefs.GetFloat("TheirCrits")) { GameData.TheirCrits = PlayerPrefs.GetFloat("TheirCrits"); }
        ConvertDoubleToText(theirCritsTxt, GameData.TheirCrits);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
    }

    public void RemoveTheirCritEdit()
    {
        GameData.TheirCrits--;
        if (GameData.TheirCrits <= 0) { GameData.TheirCrits = 0; }
        ConvertDoubleToText(theirCritsTxt, GameData.TheirCrits);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);
    }
    #endregion

    void GetCritPercentAndCovertToTxt(float crit, TMP_Text critPercentTxt)
    {
        var totalCrits = GameData.OurCrits + GameData.TheirCrits;
        var critPercent = (crit / totalCrits) * 100;
        DisplayCritPercentage(critPercentTxt, critPercent);
    }

    private static void DisplayCritPercentage(TMP_Text critPercentTxt, float critPercent)
    {
        critPercentTxt.text = $"{critPercent:f1}%";
    }

    public void SaveCrits()
    {
        PlayerPrefs.SetFloat("OurCrits", GameData.OurCrits);
        GetCritPercentAndCovertToTxt(GameData.OurCrits, ourCritPercentTxt);

        PlayerPrefs.SetFloat("TheirCrits", GameData.TheirCrits);
        GetCritPercentAndCovertToTxt(GameData.TheirCrits, theirCritPercentTxt);
    }

    void ConvertDoubleToText(TMP_Text text, double amount) { text.text = $"{amount}"; }
}
