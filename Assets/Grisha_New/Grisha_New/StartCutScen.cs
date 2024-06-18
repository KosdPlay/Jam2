using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CutsceneManager.Instance.StartCutscene("CS_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
