using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_GoombaItems : MonoBehaviour
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
        if (collision.tag == "Item")
        {
            var itemType = collision.gameObject.GetComponent<ItemScript>().typeOfThisItem;
            if(itemType == "Wateringcan" || itemType == "Instrument" || itemType == "Fence")
                marioScript.canUseItem = true;
            marioScript.typeOfPossibleItem = itemType;
            marioScript.gameObjectOfPossibleItem = collision.gameObject;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            marioScript.canUseItem = false;
            marioScript.typeOfPossibleItem = null;
            marioScript.gameObjectOfPossibleItem = null;
        }

    }
}
