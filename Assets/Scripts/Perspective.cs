using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour
{
    public static PerspectiveOption Current { get; private set; }

    private void Start()
    {
        SetPerspective(PerspectiveOption.Mario);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bool HasRotatedSuccessfully = FindObjectOfType<CameraRotate>().Rotate();

            if (HasRotatedSuccessfully)
            {
                SwitchPerspective();
            }
        }
    }

    private void SwitchPerspective()
    {
        SetPerspective((Current == PerspectiveOption.Mario) ? PerspectiveOption.Goomba : PerspectiveOption.Mario);
    }

    private void SetPerspective(PerspectiveOption perspective)
    {
        Current = perspective;

        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag.IsFloorTag())
            {
                collider.enabled = collider.tag.IsActiveFloorTag();
            }
        }
    }
}




