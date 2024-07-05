using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullFuel : MonoBehaviour
{
    bool a = false;

    private void Update()
    {
        if (!a && FuelStorage.instantiate.countFuel >= FuelStorage.instantiate.maxFuel)
        {
            Dialogue.instantiate.StartDial(2);
            a = true;
        }
    }
}
