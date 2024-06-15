using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text fuel;

    private void FixedUpdate()
    {
        fuel.text = FuelStorage.instantiate.GetCountFuel().ToString();
    }
}
