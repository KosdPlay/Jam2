using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveHelicopter : MonoBehaviour
{
    [SerializeField] private Transform up;
    [SerializeField] private bool isUp;
    [SerializeField] private Transform down;
    [SerializeField] private bool isDown;
    [SerializeField] private bool canMove;
    [SerializeField] private bool secondStage;

    [SerializeField] private Image progressBar;


    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tracePrefab;
    [SerializeField] private Transform point0;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private float speedA;
    [SerializeField] private float speedB;

    [SerializeField] private Transform point;

    private bool a = false;

    [SerializeField] private Animator animator;

    private void Start()
    {
        isUp = true;
        isDown = false;
        canMove = true;
        instantiate = this;
        hp = maxhp;
    }

    private void FixedUpdate()
    {
        progressBar.fillAmount = hp / maxhp;
        if (LevelManager.instantiate.game && !a)
        {
            a = true;
            Invoke("Spawn", speedA);
            Invoke("SpawnB", speedB);
            //hp += Time.deltaTime;

        }
        if (hp <= maxhp / 2)
        {
            secondStage = true;
        }
        if (canMove)
        {
            if (isUp)
            {
                transform.position = Vector2.MoveTowards(transform.position, down.position, 2 * Time.deltaTime);
            }
            if (isDown)
            {
                transform.position = Vector2.MoveTowards(transform.position, up.position, 2 * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, up.transform.position) < 0.5f)
            {
                isUp = true;
                isDown = false;
            }
            if (Vector2.Distance(transform.position, down.transform.position) < 0.5f)
            {
                isUp = false;
                isDown = true;
            }
        }
    }

    private void Spawn()
    {
        if (!secondStage && canMove)
        {

            StartCoroutine(SpawnA());
        }
        Invoke("Spawn", speedA);
    }

    private IEnumerator SpawnA()
    {

        Instantiate(bulletPrefab, point1.position + new Vector3(1, 0.2f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(bulletPrefab, point2.position + new Vector3(-1, 0.2f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(bulletPrefab, point1.position + new Vector3(1, 0.2f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(bulletPrefab, point2.position + new Vector3(-1, 0.2f, 0), new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(0.2f);
        Instantiate(bulletPrefab, point1.position + new Vector3(1, 0.2f, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(bulletPrefab, point2.position + new Vector3(-1, 0.2f, 0), new Quaternion(0, 0, 0, 0));
    }

    private void SpawnB()
    {
        animator.SetBool("At", true);
        if (!secondStage)
        {
            Instantiate(tracePrefab, point0.position + new Vector3(0, -4.5f, 0), point0.transform.rotation);
        }
        else
        {
            Instantiate(tracePrefab, point0.position + new Vector3(0, -4.5f, 0), point0.transform.rotation);
            Instantiate(tracePrefab, point1.position + new Vector3(-1, -4.5f, 0), point1.transform.rotation);
            Instantiate(tracePrefab, point2.position + new Vector3(1, -4.5f, 0), point2.transform.rotation);
        }
        canMove = false;
        Invoke("SpawnTrace", 2f);
    }

    private void SpawnTrace()
    {
        if (!secondStage)
        {
            Instantiate(laserPrefab, point0.position + new Vector3(0, -4, 0), point0.transform.rotation);
        }
        else
        {
            Instantiate(laserPrefab, point0.position + new Vector3(0, -4.5f, 0), point0.transform.rotation);
            Instantiate(laserPrefab, point1.position + new Vector3(-1, -4.5f, 0), point1.transform.rotation);
            Instantiate(laserPrefab, point2.position + new Vector3(1, -4.5f, 0), point2.transform.rotation);
        }
        Invoke("Stop", 1);
    }

    private void Stop()
    {
        canMove = true;
        animator.SetBool("At", false);
        Invoke("SpawnB", speedB);
    }

    [SerializeField] private float hp;
    [SerializeField] private float maxhp;
    public bool mod;

    public static MoveHelicopter instantiate;

    public void TakeDamage(int i)
    {
        if (hp - i <= 0)
        {
            hp = 0;
            Death();
        }
        else
        {
            hp -= i;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Reload", 0.3f);
        }
    }

    private void Reload()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Death()
    {
        Debug.Log("0");
        LevelManager.instantiate.game = false;
        canMove = false;
        StartCoroutine(MoveToSpawn());
    }


    private IEnumerator MoveToSpawn()
    {
        while (Vector2.Distance(transform.position, point.position) > 0.8f)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position + new Vector3(0, 0, 0), 2 * Time.deltaTime);
            yield return null;
        }
        if (Vector2.Distance(transform.position, point.position) <= 0.8f)
        {
            CutsceneManager.Instance.StartCutscene("CS_1"); StopCoroutine(MoveToSpawn());
            Destroy(this.gameObject, 4);
        }
    }
}
