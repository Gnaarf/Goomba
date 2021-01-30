using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Collider2D OtherTrigger { get => _otherTrigger; }

    [SerializeField] Collider2D _otherTrigger;
}
