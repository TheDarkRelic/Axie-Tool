
public static class PlayingState
{
    public static string gameOutcome;
    

    public static void ProcessOutcome()
    {
        switch (gameOutcome)
        {
            case "Win":
                {
                    WinLogic.EndState();
                }
                break;
            case "Lose":
                {
                    LoseLogic.EndState();
                }
                break;
            case "Draw":
                {
                    DrawLogic.EndState();
                }
                break;
            default:
                {
                    ResetOutcome();
                }
                break;
        }

    }

    public static void SetGameOutcome(string result) { gameOutcome = result; }

    public static void ResetOutcome() => gameOutcome = null;

}
