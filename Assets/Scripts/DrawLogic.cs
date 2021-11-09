using System;

public static class DrawLogic
{

    public static Action OnDrawComplete;

    public static void EndState()
    {
        AddDraw();
    }

    public static void AddDraw()
    {
        GameData.Draws++;
        OnDrawComplete?.Invoke();
    }

    public static void RemoveDraw()
    {
        GameData.Draws--;
        if (GameData.Draws <= 0) { GameData.Draws = 0; }
        OnDrawComplete?.Invoke();
    }

}
