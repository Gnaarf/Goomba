using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTasks : MonoBehaviour
{
    string parentType = "";
    Animator a;
    float timeForMovingLimit = 1.5f;
    float timer = 0f;
    float turn = -1;
    float speed = 0.002f;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name.Contains("Flower"))
        {
            parentType = "Flower";
        }
        if (transform.parent.name.Contains("Boomba"))
        {
            parentType = "Boomba";
        }
        a = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.name.Contains("Flower"))
        {
            if (a.GetInteger("Growth") > 1)
                Destroy(gameObject);
        }
        if (transform.parent.name.Contains("Boomba"))
        {
            if (a.GetCurrentAnimatorStateInfo(0).IsName("BoombaSax"))
                Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > timeForMovingLimit)
        {
            speed *= turn;
            timer = 0;
        }
        transform.Translate(new Vector3(0, speed * turn, 0));

    }
}
