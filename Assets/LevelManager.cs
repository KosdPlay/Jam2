using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instantiate;

    [SerializeField] private Transform point;

    [SerializeField] private GameObject player;

    public bool game;
    private bool a;

    private void Start()
    {
        instantiate = this;
        game = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            game = true;
        }
        if (game && !a)
        {
            a = true;
        }
        if (a && !game)
        {
            a = false;
            StartCoroutine(MoveToSpawn());
            Invoke("D", 5f);
        }
    }

    private void D()
    {
        CutsceneManager.Instance.StartCutscene("CS_End_Space");
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
