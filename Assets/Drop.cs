using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private bool a = false;

    void Update()
    {
        if (!a && DialogSystem.instantiate.a)
        {
            a = true;
            FuelStorage.instantiate.item = 3;
        }
    }
}
