using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text fuel;
    [SerializeField] private TMP_Text cycle;


    private void FixedUpdate()
    {
        fuel.text = FuelStorage.instantiate.GetItem().ToString();
        cycle.text = Story.instantiate.cycle.ToString();
    }
}
