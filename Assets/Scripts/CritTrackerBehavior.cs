using TMPro;
using UnityEngine;

public class CritTrackerBehavior : MonoBehaviour
{

    private void OnDisable()
    {
        SaveCrits();
    }

    public float ourCrits, theirCrits;
    [SerializeField] TMP_Text ourCritsTxt;
    [SerializeField] TMP_Text theirCritsTxt;
    [SerializeField] TMP_Text ourCritPercentTxt;
    [SerializeField] TMP_Text theirCritPercentTxt;

    private void Start()
    {
        RetrieveCritData();
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
    }

    private void RetrieveCritData()
    {
        ourCrits = PlayerPrefs.GetFloat("OurCrits");
        ConvertDoubleToText(ourCritsTxt, ourCrits);

        
        theirCrits = PlayerPrefs.GetFloat("TheirCrits");
        ConvertDoubleToText(theirCritsTxt, theirCrits);
    }

    #region Our Crit Methods
    public void AddOurCrit()
    {
        ourCrits++;
        ConvertDoubleToText(ourCritsTxt, ourCrits);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
    }


    public void MinusOurCrit()
    {
        ourCrits--;
        if(ourCrits <= PlayerPrefs.GetFloat("OurCrits")) { ourCrits = PlayerPrefs.GetFloat("OurCrits"); }
        ConvertDoubleToText(ourCritsTxt, ourCrits);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
    }

    public void RemoveOurCritEdit()
    {
        ourCrits--;
        if (ourCrits <= 0) { ourCrits = 0; }
        ConvertDoubleToText(ourCritsTxt, ourCrits);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
    }
    #endregion

    #region Their Crit Methods
    public void AddTheirCrit()
    {
        theirCrits++;
        ConvertDoubleToText(theirCritsTxt, theirCrits);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
    }

    public void MinusTheirCrit()
    {
        theirCrits--;
        if (theirCrits <= PlayerPrefs.GetFloat("TheirCrits")) { theirCrits = PlayerPrefs.GetFloat("TheirCrits"); }
        ConvertDoubleToText(theirCritsTxt, theirCrits);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
    }

    public void RemoveTheirCritEdit()
    {
        theirCrits--;
        if (theirCrits <= 0) { theirCrits = 0; }
        ConvertDoubleToText(theirCritsTxt, theirCrits);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);
    }
    #endregion

    void GetCritPercentAndCovertToTxt(float crit, TMP_Text critPercentTxt)
    {
        var totalCrits = ourCrits + theirCrits;
        var critPercent = (crit / totalCrits) * 100;
        DisplayCritPercentage(critPercentTxt, critPercent);
    }

    private static void DisplayCritPercentage(TMP_Text critPercentTxt, float critPercent)
    {
        critPercentTxt.text = $"{critPercent:f1}%";
    }

    public void SaveCrits()
    {
        PlayerPrefs.SetFloat("OurCrits", ourCrits);
        GetCritPercentAndCovertToTxt(ourCrits, ourCritPercentTxt);

        PlayerPrefs.SetFloat("TheirCrits", theirCrits);
        GetCritPercentAndCovertToTxt(theirCrits, theirCritPercentTxt);
    }

    void ConvertDoubleToText(TMP_Text text, double amount) { text.text = $"{amount}"; }
}
