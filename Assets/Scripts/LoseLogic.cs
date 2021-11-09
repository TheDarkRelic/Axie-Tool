using System;

public static class LoseLogic
{

    public static Action OnLoseComplete;

    public static void EndState()
    {
        AddLoss();
    }

    public static void AddLoss()
    {
        GameData.Loses++;
        OnLoseComplete?.Invoke();
    }

    public static void RemoveLoss()
    {
        GameData.Loses--;
        if (GameData.Loses <= 0) { GameData.Loses = 0; }
        OnLoseComplete?.Invoke();
    }

}
