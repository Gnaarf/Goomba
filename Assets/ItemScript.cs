using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string typeOfThisItem = null;
    // Start is called before the first frame update
    void Start()
    {
        if (name.Contains("Water"))
            typeOfThisItem = "Wateringcan";
        if (name.Contains("Instrument"))
            typeOfThisItem = "Instrument";
        if (gameObject.name.Contains("Fence"))
            typeOfThisItem = "Fence";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
