using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    string names = null;
    // Start is called before the first frame update
    public void Start(string name)
    {
        CutsceneManager.Instance.StartCutscene("CS");
        names = name;
        Invoke("Start1", 5f);
    }

    void Start1()
    {
        SceneManager.LoadScene(names);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
