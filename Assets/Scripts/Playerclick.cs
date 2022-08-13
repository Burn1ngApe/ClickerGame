using UnityEngine;
using TMPro;

public class Playerclick : MonoBehaviour, IClicker
{
    public ulong TotalScoreNumber = 0;

    public ulong ClickCost;
    [SerializeField] private ulong _X;

    [SerializeField] private TMP_Text _score;
    [SerializeField] private GameObject _win;



    private void Start()
    {
        ClickCost = _X;
    }



    public void SetNewValue(ulong value, ulong amountOfInstalledUpgrades)
    {
        ClickCost = _X + (amountOfInstalledUpgrades * value);
    }



    public void ResetThis()
    {
        ClickCost = _X;
        SubScore(TotalScoreNumber);
    }



    public void AddScore(ulong addedScore)
    {
        CheckForMaxNumber(addedScore);

        TotalScoreNumber += addedScore;
        _score.text = SetValueWithSuffix(TotalScoreNumber);

    }



    public void SubScore(ulong subScore)
    {    
        TotalScoreNumber -= subScore;
        _score.text = SetValueWithSuffix(TotalScoreNumber);

    }



    private void CheckForMaxNumber(ulong addedScore)
    {
        double biggerValue = (double)TotalScoreNumber + (double)addedScore;

        if (biggerValue > (double)ulong.MaxValue)
        {
            Time.timeScale = 0;
            _win.SetActive(true);
        }

    }



    private string SetValueWithSuffix(ulong value)
    {
        int zero = 0;

        while (value >= 1000)
        {
            ++zero;

            value /= 1000;
        }

        string suffix = string.Empty;

        switch (zero)
        {
            case 1: suffix = "K"; break;
            case 2: suffix = "M"; break;
            case 3: suffix = "B"; break;
            case 4: suffix = "T"; break;
            case 5: suffix = "Qd"; break;
            case 6: suffix = "Qn"; break;
            case 7: suffix = "Sx"; break;
            case 8: suffix = "Sp"; break;
            case 9: suffix = "Oc"; break;
        }

        return $"{value:0}{suffix}";
    }
}

