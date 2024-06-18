using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FuelStorage : MonoBehaviour
{
    public int item;
    public int countFuel;
    public static FuelStorage instantiate;
    public int maxFuel;
    [SerializeField] private Image FuelBar;

    private void Start()
    {
        instantiate = this;
    }

    public void AddItem(int i)
    {
        item += i;
    }

    public void Recycling()
    {
        countFuel += item;
        item = 0;
        Debug.Log(countFuel / maxFuel);
        FuelBar.fillAmount = (float)countFuel / (float)maxFuel;
    }

    public int GetItem()
    {
        return item;
    }

    public int GetCountFuel()
    {
        return countFuel;
    }
}
