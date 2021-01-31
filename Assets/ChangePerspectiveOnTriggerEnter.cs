using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePerspectiveOnTriggerEnter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Perspective.SwitchPerspective();
    }
}
