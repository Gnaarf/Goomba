﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Mario : MonoBehaviour
{
    Rigidbody2D rdbd;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer renderer;

    float horizontalInput;
    [SerializeField] float speed = 3f; // 1.5f = Goomba // 3 = Mario
    [SerializeField] float jumpFactor = 6;
    bool useKeyWasPressed = false;
    public bool isFloored = false;
    public bool canUseItem = false;
    public string typeOfPossibleItem = null;
    public string typeOfCurrentItem = null;
    public GameObject gameObjectOfPossibleItem = null;
    public Sprite fence;
    public Sprite instrument;
    public Sprite wateringCan;
    SpriteRenderer itemRenderer;

    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        itemRenderer = GameObject.Find("ItemHolder").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isFloored)
            useKeyWasPressed = true;
    }

    private void FixedUpdate()
    {
        if (useKeyWasPressed)
        {
            // doStuffIfMario
            rdbd.AddForce(Vector3.up * jumpFactor, ForceMode2D.Impulse);

            // doStuffIfGoomba
            // TODO change when CanJump etc. is in
            if(canUseItem)
            {
                typeOfCurrentItem = typeOfPossibleItem;
                switch (typeOfPossibleItem)
                {
                    case "Fence":
                        itemRenderer.sprite = fence;
                        break;
                    case "Instrument":
                        itemRenderer.sprite = instrument;
                        break;
                    case "Wateringcan":
                        itemRenderer.sprite = wateringCan;
                        break;
                    default:
                        Debug.LogWarning("Something didn't go right. Other string expected.");
                        break;
                }
                Destroy(gameObjectOfPossibleItem);
            }

            useKeyWasPressed = false;
        }
        rdbd.velocity = new Vector3(horizontalInput * speed, rdbd.velocity.y, 0);
        renderer.flipX = rdbd.velocity.x < 0;

        animator.SetFloat("VerticalSpeed", Mathf.Abs(rdbd.velocity.x));

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Ladder ladder = collision.GetComponent<Ladder>();
        if (ladder != null && Input.GetKeyUp(KeyCode.L))
        {
            transform.position = ladder.OtherTrigger.transform.position + Vector3.up;
        }
    }

}

