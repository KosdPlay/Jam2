using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    private void Start()
    {
        Invoke("D", 2);
    }

    private void D()
    {
        Destroy(this.gameObject);
    }
}
