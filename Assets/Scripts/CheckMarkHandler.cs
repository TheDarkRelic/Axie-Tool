using UnityEngine;

/// <summary>
/// Handles checkmark logic
/// </summary>
public class CheckMarkHandler : MonoBehaviour
{
    [SerializeField] GameObject check1 = null;
    [SerializeField] GameObject check2 = null;
    [SerializeField] GameObject check3 = null;

    private void Start()
    {
        ResetCheckmarks();
    }
 
    public void CheckMark1Behavior()
    {
        check1.SetActive(true);
        check2.SetActive(false);
        check3.SetActive(false);
    }

    public void CheckMark2Behavior()
    {
        check1.SetActive(false);
        check2.SetActive(true);
        check3.SetActive(false);
    }

    public void CheckMark3Behavior()
    {
        check1.SetActive(false);
        check2.SetActive(false);
        check3.SetActive(true);
    }

    public void ResetCheckmarks()
    {
        check1.SetActive(false);
        check2.SetActive(false);
        check3.SetActive(false);
    }
}
