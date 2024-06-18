using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public static Story instantiate;
    public int good;
    public int rejection;
    public int bad;

    public bool firstStory;
    public bool secondStory;
    public bool thirdStory;
    public bool fourthStory;

    public int cycle;

    private void Start()
    {
        DontDestroyOnLoad(this);
        instantiate = this;
    }
}
