using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveDependentActivater : MonoBehaviour
{
    public PerspectiveOption ActiveOnPerspective { get; private set; }
    [SerializeField] PerspectiveOption activeOnPerspective;

    // Start is called before the first frame update
    void Start()
    {
        Perspective.OnPerspectiveChange += (oldPerspective, newPerspective) => gameObject.SetActive(newPerspective == activeOnPerspective);
    }
}
