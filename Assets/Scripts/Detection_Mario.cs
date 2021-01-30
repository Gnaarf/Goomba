using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Mario : MonoBehaviour
{
    Movement_Mario marioScript;
    // Start is called before the first frame update
    void Start()
    {
        marioScript = transform.GetComponentInParent<Movement_Mario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.IsActiveFloorTag())
            marioScript.isFloored = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.IsActiveFloorTag())
            marioScript.isFloored = false;
    }
}
