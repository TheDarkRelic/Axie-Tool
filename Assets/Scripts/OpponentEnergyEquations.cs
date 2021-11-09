using UnityEngine;
using System;

public class OpponentEnergyEquations : MonoBehaviour
{

    public static Action OnEnergyGained;
    public static Action OnEnergyUsed;
    public static Action OnCurrentEnergyUpdate;

    [SerializeField] WarningPanelHandler warningPanelHandler = null;
 
    void Start()
    {
        GameData.CurrentEnergy = 3;
        OnCurrentEnergyUpdate?.Invoke();

        GameData.EnergyUsed = 0;
        OnEnergyUsed?.Invoke();

        GameData.EnergyGained = 0;
        OnEnergyGained?.Invoke();
    }
    public void EnergyGained()
    {
        GameData.EnergyGained++;
        if (GameData.EnergyGained >= 10) { GameData.EnergyGained = 10; }
        OnEnergyGained?.Invoke();
    }

    public void EnergyUsed()
    {
        GameData.EnergyUsed++;
        if (GameData.EnergyUsed >= GameData.CurrentEnergy) { GameData.EnergyUsed = GameData.CurrentEnergy; }
        OnEnergyUsed?.Invoke();
    }

    public void MultiplyEnergy()
    {
        GameData.CurrentEnergy = (GameData.CurrentEnergy - GameData.EnergyUsed) + GameData.EnergyGained + 2;

        if (GameData.CurrentEnergy >= 10) { GameData.CurrentEnergy = 10; }

        OnCurrentEnergyUpdate?.Invoke();
        GameData.EnergyGained = 0;
        OnEnergyGained?.Invoke();

        GameData.EnergyUsed = 0;
        OnEnergyUsed?.Invoke();
    }

    public void ResetEnergy()
    {
        if (warningPanelHandler.isDisabled || PlayingState.gameOutcome != null)
        {
            GameData.CurrentEnergy = 3;
            OnCurrentEnergyUpdate?.Invoke();

            GameData.EnergyUsed = 0;
            OnEnergyUsed?.Invoke();

            GameData.EnergyGained = 0;
            OnEnergyGained?.Invoke();
        }
    }

}