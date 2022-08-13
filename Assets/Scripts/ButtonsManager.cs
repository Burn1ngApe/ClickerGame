using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private Upgrades _upgrades;

    public Button UpgradeClickCostButton;
    public Button UpgradeAutoClickerButton;

    public Playerclick PlayerclickService;
    public Autoclicker AutoclickerService;



    public void ClickMade()
    {
        PlayerclickService.AddScore(PlayerclickService.ClickCost);
    }



    private bool CheckCostOfUpgrade(IUpgrade upgrade)
    {
        bool enoughScoreForUpgrade = false;


        if (PlayerclickService.TotalScoreNumber >= upgrade.GetCurrentCost())
        {
            enoughScoreForUpgrade = true;
        }
        else enoughScoreForUpgrade = false;

        return enoughScoreForUpgrade;
    }



    public void UpgradeClickCost()
    {
        if (!CheckCostOfUpgrade(_upgrades.InstalledCCUpgrades.First.Value)) return;

        PlayerclickService.SubScore(_upgrades.InstalledCCUpgrades.First.Value.CostOfUpgrade);
        _upgrades.UpgradePlayerclick(PlayerclickService);

        if (_upgrades.InstalledCCUpgrades.Count == 0) UpgradeClickCostButton.interactable = false; 
    }



    public void UpgradeAutoClicker()
    {
        if (!CheckCostOfUpgrade(_upgrades.InstalledACUpgrades.First.Value)) return;

        PlayerclickService.SubScore(_upgrades.InstalledACUpgrades.First.Value.CostOfUpgrade);
        _upgrades.UpgradeAutoclicker(AutoclickerService);

        if (_upgrades.InstalledACUpgrades.Count == 0) UpgradeAutoClickerButton.interactable = false;

    }



    public void ResetButton()
    {
        UpgradeClickCostButton.interactable = true;
        UpgradeAutoClickerButton.interactable = true;

        AutoclickerService.ResetThis();
        PlayerclickService.ResetThis();

        _upgrades.ResetUpgrades();
    }
}
