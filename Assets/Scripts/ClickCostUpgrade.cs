[System.Serializable]
public class ClickCostUpgrade : IUpgrade
{
    public ulong CostOfUpgrade;
    public ulong AddedCostToClick;

    public ulong GetCurrentCost()
    {
        return CostOfUpgrade;
    }
}
