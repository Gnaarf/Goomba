using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_EnemyGoomba : MonoBehaviour
{
    Rigidbody2D rdbd;

    float speed = 1f;
    public bool turnAround = false;
    public bool isDead = false;
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            rdbd.velocity = new Vector3(0, 0, 0);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

        else
        {
            if (turnAround)
                rdbd.velocity = new Vector3(speed, rdbd.velocity.y, 0);
            else
                rdbd.velocity = new Vector3(-speed, rdbd.velocity.y, 0);
        }
    }
}
