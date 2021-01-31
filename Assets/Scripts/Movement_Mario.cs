using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Mario : MonoBehaviour
{
    Rigidbody2D rdbd;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    float horizontalInput;
    [SerializeField] float speed = 3f; // 1.5f = Goomba // 3 = Mario
    [SerializeField] float jumpFactor = 6;
    bool useKeyWasPressed = false;
    public bool isFloored = false;
    public bool canUseItem = false;
    public string typeOfPossibleItem = "";
    public string typeOfCurrentItem = "";
    public GameObject gameObjectOfPossibleItem = null;
    public Sprite fence;
    public Sprite instrument;
    public Sprite wateringCan;
    SpriteRenderer itemRenderer;
    bool wateredOnce = false;
    float flowerTimer = 3f;

    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        itemRenderer = GameObject.Find("ItemHolder").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * (Perspective.Current == PerspectiveOption.Mario ? 1 : -1);
        if (Input.GetKeyDown(KeyCode.Space) && isFloored)
            useKeyWasPressed = true;
    }

    private void FixedUpdate()
    {
        if (wateredOnce)
            flowerTimer -= Time.deltaTime;

        // automatic use of items when possible
        if (typeOfPossibleItem != "")
        {
            switch (typeOfPossibleItem)
            {

                case "Boomba":
                    if (typeOfCurrentItem == "Instrument")
                    {
                        Animator a = gameObjectOfPossibleItem.GetComponent<Animator>();
                        a.SetTrigger("GiveSax");
                        itemRenderer.sprite = null;
                        typeOfCurrentItem = "";
                    }
                    break;

                case "Flower":
                    if (typeOfCurrentItem == "Wateringcan")
                    {
                        Animator a = gameObjectOfPossibleItem.GetComponent<Animator>();
                        if (!wateredOnce)
                        {
                            a.SetInteger("Growth", a.GetInteger("Growth")+1);
                            wateredOnce = true;
                        }
                        else
                        {
                            if(flowerTimer<0)
                            {
                                a.SetInteger("Growth", a.GetInteger("Growth") + 1);
                                wateredOnce = false;
                                itemRenderer.sprite = null;
                                typeOfCurrentItem = "";
                            }
                        }


                    }
                    break;
                default:
                    break;
            }
        }

        if (useKeyWasPressed)
        {
            // doStuffIfMario
            rdbd.AddForce(Vector3.up * jumpFactor, ForceMode2D.Impulse);

            // doStuffIfGoomba
            // TODO change when CanJump etc. is in
            if (canUseItem && typeOfCurrentItem == "")
            {
                Debug.Log(typeOfCurrentItem);
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
        if (rdbd.velocity.x != 0)
        {
            spriteRenderer.flipX = rdbd.velocity.x < 0;
        }


        if (rdbd.bodyType != RigidbodyType2D.Static)
        {
            rdbd.velocity = new Vector3(horizontalInput * speed, rdbd.velocity.y, 0);
            spriteRenderer.flipX = rdbd.velocity.x < 0;

            animator.SetFloat("HorizontalSpeed", Mathf.Abs(rdbd.velocity.x));
            animator.SetFloat("VerticalSpeed", Mathf.Abs(rdbd.velocity.y));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Ladder ladder = collision.GetComponent<Ladder>();
        if (ladder != null && Input.GetKeyUp(KeyCode.L))
        {
            transform.position = ladder.OtherTrigger.transform.position + Vector3.up;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ladder ladder = collision.GetComponent<Ladder>();
        if (ladder != null)
        {
            ladder.Register(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Ladder ladder = collision.GetComponent<Ladder>();
        if (ladder != null)
        {
            ladder.Deregister();
        }
    }

}

