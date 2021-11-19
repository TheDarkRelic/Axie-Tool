using UnityEngine;
using System;
/// <summary>
/// Handles opponent energy logic
/// </summary>
public class OpponentEnergyEquations : MonoBehaviour
{

    public static Action OnEnergyGained;
    public static Action OnEnergyUsed;
    public static Action OnEnergyLost;
    public static Action OnCurrentEnergyUpdate;

    [Header("WarningPanelHandler Script Object")]
    [SerializeField] WarningPanelHandler warningPanelHandler = null;
 
    void Start()
    {
        GameData.CurrentEnergy = 3;
        OnCurrentEnergyUpdate?.Invoke();

        GameData.EnergyUsed = 0;
        OnEnergyUsed?.Invoke();

        GameData.EnergyLost = 0;
        OnEnergyLost?.Invoke();

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
        var energySum = (GameData.CurrentEnergy - GameData.EnergyLost) + GameData.EnergyGained;
        GameData.EnergyUsed++;
        if (GameData.EnergyUsed >= energySum) { GameData.EnergyUsed = energySum; }
        OnEnergyUsed?.Invoke();
    }

    public void EnergyLost()
    {
        var energySum = (GameData.CurrentEnergy - GameData.EnergyUsed) + GameData.EnergyGained;
        GameData.EnergyLost++;
        if (GameData.EnergyLost >= energySum) { GameData.EnergyLost = energySum; }
        OnEnergyLost?.Invoke();
    }

    public void MultiplyEnergy()
    {
        GameData.CurrentEnergy = (GameData.CurrentEnergy - GameData.EnergyUsed) + (GameData.EnergyGained - GameData.EnergyLost) + 2;

        if (GameData.CurrentEnergy >= 10) { GameData.CurrentEnergy = 10; }

        OnCurrentEnergyUpdate?.Invoke();
        GameData.EnergyGained = 0;
        OnEnergyGained?.Invoke();

        GameData.EnergyUsed = 0;
        OnEnergyUsed?.Invoke();

        GameData.EnergyLost = 0;
        OnEnergyLost?.Invoke();
    }

    public void AddCurrentEnergy()
    {
        GameData.CurrentEnergy++;
        if (GameData.CurrentEnergy >= 10) { GameData.CurrentEnergy = 10; }
        OnCurrentEnergyUpdate?.Invoke();
    }

    public void RemoveCurrentEnergy()
    {
        GameData.CurrentEnergy--;
        if (GameData.CurrentEnergy <= 0) { GameData.CurrentEnergy = 0; }
        OnCurrentEnergyUpdate?.Invoke();
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

            GameData.EnergyLost = 0;
            OnEnergyLost?.Invoke();
        }
    }

}