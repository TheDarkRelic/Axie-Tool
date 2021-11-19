/// <summary>
/// Holds all the available data for the app
/// </summary>
public static class GameData
{
    public static int wins;
    public static int loses;
    public static int draws;

    public static int rounds;
    public static int matchesPlayed;

    public static float winPercent;
    public static float losePercent;
    public static float drawPercent;

    public static int energyUsed;
    public static int energyLost;
    public static int energyGained;
    public static int currentEnergy;

    public static float ourCrits;
    public static float theirCrits;



    public static void InitializeWinLoseDrawSaveData(int savedWins, int savedLoses, int savedDraws)
    {
        Wins = savedWins;
        Loses = savedLoses;
        Draws = savedDraws;
    }

    public static void InitializeMatchesPlayedSaveData(int savedMatchesPlayed)
    {
        MatchesPlayed = savedMatchesPlayed;
    }

    public static void InitializeWinLoseDrawPercentageData(float winData, float loseData, float drawData)
    {
        WinPercent = winData;
        LosePercent = loseData;
        DrawPercent = drawData;
    }

    public static void InitializeCritPercentageData(float ourCrits, float theirCrits)
    {
        TheirCrits = theirCrits;
        OurCrits = ourCrits;
    }

    public static int Wins { get { return wins; } set { wins = value; } }

    public static int Loses { get { return loses; } set { loses = value; } }

    public static int Draws { get { return draws; } set { draws = value; } }

    public static int Rounds { get { return rounds; } set { rounds = value; } }

    public static int MatchesPlayed { get { return matchesPlayed; } set { matchesPlayed = value; } }

    public static int EnergyUsed { get { return energyUsed; } set { energyUsed = value; } }
    public static int EnergyLost { get { return energyLost; } set { energyLost = value; } }

    public static int EnergyGained { get { return energyGained; } set { energyGained = value; } }

    public static int CurrentEnergy { get { return currentEnergy; } set { currentEnergy = value; } }

    public static float WinPercent { get { return winPercent; } set { winPercent = value; } }
    public static float LosePercent { get { return losePercent; } set { losePercent = value; } }
    public static float DrawPercent { get { return drawPercent; } set { drawPercent = value; } }

    public static float TheirCrits { get { return theirCrits; } set { theirCrits = value; } }
    public static float OurCrits { get { return ourCrits; } set { ourCrits = value; } }





}
