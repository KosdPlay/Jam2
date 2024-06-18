using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layka_TP : MonoBehaviour
{
    [SerializeField] private GameObject laika;
    [SerializeField] private GameObject point;
    bool a = false;

    private void Update()
    {
        if (!a && FuelStorage.instantiate.countFuel >= FuelStorage.instantiate.maxFuel)
        {
            Destroy(GetComponent<FindsLaika>());
            laika.transform.position = point.transform.position;
            laika.transform.Rotate(0, 0, 180);
            Dialogue.instantiate.StartDial(3);
            a = true;
        }
    }
}
