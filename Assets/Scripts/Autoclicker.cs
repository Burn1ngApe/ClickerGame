using UnityEngine;
using System.Collections;

public class Autoclicker : MonoBehaviour, IClicker
{
    [SerializeField] private Playerclick _playerclick;

    [HideInInspector] public ulong AddedClicks = 0;
    private ulong _addedClicksAtStart;

    [SerializeField] private float _timeBetweenAddingClicks;


    private void Start() 
    { 
        _addedClicksAtStart = AddedClicks;

        StartCoroutine("AddClicks");
    }



    public void SetNewValue(ulong value, ulong amountOfInstalledUpgrades)
    {
        var clicksToAdd = amountOfInstalledUpgrades * value;

        AddedClicks += clicksToAdd;
    }



    public void ResetThis()
    {
        AddedClicks = _addedClicksAtStart;
    }



    private IEnumerator AddClicks()
    {
        _playerclick.AddScore(AddedClicks);

        yield return new WaitForSeconds(_timeBetweenAddingClicks);

        StartCoroutine("AddClicks");
    }
}
