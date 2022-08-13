[System.Serializable]
public class AutoClickerUpgrade : IUpgrade
{
    public ulong CostOfUpgrade;
    public ulong AddedAmountOfClicks;

    public ulong GetCurrentCost()
    {
        return CostOfUpgrade;
    }
}
