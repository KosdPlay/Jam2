using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseRoket : MonoBehaviour
{
    [SerializeField] private GameObject hint1;
    [SerializeField] private GameObject hint2;
    [SerializeField] bool a = true;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private string name;

    private void Start()
    {
        hint1.SetActive(false);
        hint2.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!a && FuelStorage.instantiate.countFuel >= FuelStorage.instantiate.maxFuel && DialogSystem.instantiate.a)
            {
                hint1.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Типа взлетели");
                    Dialogue.instantiate.CloseDialog();
                    DialogSystem.instantiate.CloseDialog();
                    CutsceneManager.Instance.StartCutscene("CS_2");
                    DialogSystem.instantiate.canMove = false;

                    Invoke("Next", 7);
                }
            }
            else if (FuelStorage.instantiate.item != 0)
            {
                hint2.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    FuelStorage.instantiate.Recycling();
                    Debug.Log("Загрузили топлево");
                    if (FuelStorage.instantiate.countFuel >= FuelStorage.instantiate.maxFuel)
                    {
                        Invoke("B", 0.5f);
                    }
                    audioSource.PlayOneShot(clip);
                }
            }
            else
            {
                hint1.SetActive(false);
                hint2.SetActive(false);
            }
        }
    }

    private void B()
    {
        a = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint1.SetActive(false);
            hint2.SetActive(false);
        }
    }

    public void Next()
    {
        if (Story.instantiate.cycle == 4)
        {
            Story.instantiate.cycle += 1;
            if (Story.instantiate.good >= 2)
            {
                SceneManager.LoadScene("Planet5A");
            }
            else if (Story.instantiate.bad >= 2)
            {
                SceneManager.LoadScene("Planet5B");
            }
            else if(Story.instantiate.rejection >= 2)
            {
                SceneManager.LoadScene("Planet5С");
            }
        }
        else
        {
            Story.instantiate.cycle += 1;
            SceneManager.LoadScene(name);
        }
    }
}
