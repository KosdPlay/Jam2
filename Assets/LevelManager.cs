using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instantiate;

    [SerializeField] private Transform point;

    [SerializeField] private GameObject player;


    [SerializeField] private string name;

    public bool game;
    private bool a;

    private void Awake()
    {
        instantiate = this;
        game = false;
    }

    private void Start()
    {
        if (FlightProgress.instantiate.mod)
        {
            Dialogue.instantiate.StartDial(1);
        }
        else
        {
            game = true;
        }
    }

    private void Update()
    {
        if (game && !a)
        {
            a = true;
        }
        if (a && !game && FlightProgress.instantiate.mod)
        {
            a = false;
            StartCoroutine(MoveToSpawn());
            Invoke("D", 5f);
        }
        if (FlightProgress.instantiate.progress >= 100 && game && !FlightProgress.instantiate.mod)
        {
            game = false;
            D();
        }
    }

    private void D()
    {
        CutsceneManager.Instance.StartCutscene("CS_End_Space");
        Invoke("Next", 4);

    }

    private void Next()
    {
        SceneManager.LoadScene(name);
    }

    public void start()
    {
        game = true;
    }

    private IEnumerator MoveToSpawn()
    {
        while (Vector2.Distance(player.transform.position, point.position) > 0.8f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, point.position + new Vector3(0, 0, 0), 2 * Time.deltaTime);
            yield return null;
        }
        if (Vector2.Distance(player.transform.position, point.position) <= 0.8f)
        {
            CutsceneManager.Instance.StartCutscene("CS_1"); StopCoroutine(MoveToSpawn());
        }
    }
}
