using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour
{
    public static RotationPlanet instantiate;
    [SerializeField] private GameObject planet;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    public bool facingRight = true;

    private void Start()
    {
        instantiate = this;
    }

    private void FixedUpdate()
    {
        if (DialogSystem.instantiate.canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                planet.transform.Rotate(0, 0, speed);
                if (!facingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                planet.transform.Rotate(0, 0, -speed);
                if (facingRight)
                {
                    Flip();
                } 

            }
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = player.transform.localScale;
        theScale.x *= -1;
        player.transform.localScale = theScale;
    }
}
