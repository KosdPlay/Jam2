using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] private float time;
    void Start()
    {
        Destroy(this.gameObject, time);
    }

}
