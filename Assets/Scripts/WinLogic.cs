using System;

public static class WinLogic
{

    public static Action OnWinComplete;

    public static void EndState()
    {
        AddWin();
    }

    public static void AddWin()
    {
        GameData.Wins++;
        OnWinComplete?.Invoke();
    }

    public static void RemoveWin()
    {
        GameData.Wins--;
        if (GameData.Wins <= 0) { GameData.Wins = 0; }
        OnWinComplete?.Invoke();
    }

}
