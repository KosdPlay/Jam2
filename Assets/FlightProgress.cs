using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlightProgress : MonoBehaviour
{
    public float progress;
    [SerializeField] private Image progressBar;

    [SerializeField] private float hp;
    [SerializeField] private float maxhp;
    public bool mod;

    [SerializeField] private GameObject rocket;

    public static FlightProgress instantiate;

    private void Start()
    {
        instantiate = this;
        hp = maxhp;
    }

    private void FixedUpdate()
    {
        if (!mod)
        {
            progress += Time.deltaTime;
            progressBar.fillAmount = progress / 100;
        }
        else
        {
            progressBar.fillAmount = hp / maxhp;
        }
    }

    public void TakeDamage(int i)
    {
        if (mod == false)
        {
            if (progress - i < 0)
            {
                progress = 0;
            }
            else
            {
                progress -= i;
            }
        }
        else
        {
            if (hp - i <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                hp -= i;
                rocket.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Invoke("Reload", 0.3f);
            }
        }
    }

    private void Reload()
    {
        rocket.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
