using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private List<ClickCostUpgrade> _clickCostUpgrades = new List<ClickCostUpgrade>();
    [SerializeField] private List<AutoClickerUpgrade> _autoclickerUpgrades = new List<AutoClickerUpgrade>();

    public LinkedList<ClickCostUpgrade> InstalledCCUpgrades;
    public LinkedList<AutoClickerUpgrade> InstalledACUpgrades;



    private void Awake()
    {
        InstalledCCUpgrades = new LinkedList<ClickCostUpgrade>(_clickCostUpgrades);
        InstalledACUpgrades = new LinkedList<AutoClickerUpgrade>(_autoclickerUpgrades);
    }



    public void UpgradePlayerclick(IClicker clicker)
    {
        var firstCostOfClick = InstalledCCUpgrades.First.Value.AddedCostToClick;
   
        InstalledCCUpgrades.RemoveFirst();

        var amountOfInstalledUpgrades = (ulong)(_clickCostUpgrades.Count - InstalledCCUpgrades.Count);
        clicker.SetNewValue(firstCostOfClick, amountOfInstalledUpgrades);
    }



    public void UpgradeAutoclicker(IClicker clicker)
    {
        var firstAmountOfClicks = InstalledACUpgrades.First.Value.AddedAmountOfClicks;

        InstalledACUpgrades.RemoveFirst();

        var amountOfInstalledUpgrades = (ulong)(_autoclickerUpgrades.Count - InstalledACUpgrades.Count);
        clicker.SetNewValue(firstAmountOfClicks, amountOfInstalledUpgrades);
    }



    public void ResetUpgrades()
    {
        InstalledCCUpgrades = new LinkedList<ClickCostUpgrade>(_clickCostUpgrades);
        InstalledACUpgrades = new LinkedList<AutoClickerUpgrade>(_autoclickerUpgrades);      
    }
}


