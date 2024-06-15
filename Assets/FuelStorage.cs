using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStorage : MonoBehaviour
{
    [SerializeField] private int countFuel;
    public static FuelStorage instantiate;

    private void Start()
    {
        DontDestroyOnLoad(this);
        instantiate = this;
    }

    public void AddCountFuel(int i)
    {
        countFuel += i;
    }

    public int GetCountFuel()
    {
        return countFuel;
    }
}
