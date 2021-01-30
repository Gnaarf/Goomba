﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_EnemyGoomba : MonoBehaviour
{
    Movement_EnemyGoomba enemyGoomba;
    // Start is called before the first frame update
    void Start()
    {
        enemyGoomba = transform.GetComponentInParent<Movement_EnemyGoomba>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.IsActiveFloorTag())
            enemyGoomba.turnAround = !enemyGoomba.turnAround;
    }
}
