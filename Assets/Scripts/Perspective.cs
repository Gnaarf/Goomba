using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour
{
    public static PerspectiveOption Current { get; private set; }

    public delegate void PerspectiveChangeEventHandler(PerspectiveOption oldPerspective, PerspectiveOption newPerspective);

    public static event PerspectiveChangeEventHandler OnPerspectiveChange;

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
        PerspectiveOption Previous = Current;
        Current = perspective;

        Collider2D[] colliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag.IsFloorTag())
            {
                collider.enabled = collider.tag.IsActiveFloorTag();
            }
        }
        PerspectiveDependentActivater[] objects = FindObjectsOfType<PerspectiveDependentActivater>();
        foreach(PerspectiveDependentActivater obj in objects)
        {
            obj.gameObject.SetActive(Current == obj.ActiveOnPerspective);
        }
        OnPerspectiveChange.Invoke(Previous, Current);
    }
}




