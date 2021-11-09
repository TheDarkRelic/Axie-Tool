using UnityEngine;

public class WarningPanelHandler : MonoBehaviour
{
    [SerializeField] GameObject warningPanel;
    public bool isDisabled;

    private void Start()
    {
        CheckWarningPanelBool();
    }

    private void CheckWarningPanelBool()
    {
        if (PlayerPrefs.GetInt("IsDisabled") == 0)
        {
            isDisabled = false;
        }
        else if (PlayerPrefs.GetInt("IsDisabled") == 1)
        {
            isDisabled = true;
        }
    }

    public void OpenWanringPanel()
    {
        if (PlayingState.gameOutcome == null)
        {
            if (!isDisabled)
            {
                warningPanel.SetActive(true);
                return;
            }
        }
        PlayingState.ResetOutcome();
    }

    public void CloseWarningPanel()
    {
        warningPanel.SetActive(false);
    }

    public void DisableWarningPanel()
    {
        isDisabled = true;
        PlayerPrefs.SetInt("IsDisabled", 1);
        CloseWarningPanel();
    }
}
