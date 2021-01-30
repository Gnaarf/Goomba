using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public Collider2D OtherTrigger { get => _otherTrigger; }

    [SerializeField] Collider2D _otherTrigger;
    Collider2D _ownTrigger;

    Transform _transformInFrontOfLadder = null;

    private void Start()
    {
        _ownTrigger = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(_transformInFrontOfLadder != null && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rigidbody2D rigidbody = _transformInFrontOfLadder.GetComponent<Rigidbody2D>();
            Action onCoroutineFinished = null;
            if (rigidbody != null)
            {
                rigidbody.bodyType = RigidbodyType2D.Static;
                onCoroutineFinished = () => rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }

            _transformInFrontOfLadder.position = new Vector3(transform.position.x, _transformInFrontOfLadder.position.y, _transformInFrontOfLadder.position.z);
            StartCoroutine(Helpers.LinearMovementCoroutine(_transformInFrontOfLadder, OtherTrigger.transform.position, 1.2f, onCoroutineFinished));

        }
    }

    public void Register(Transform transform)
    {
        Debug.Log(transform != null ? "ladder" : "ladder end");
        _transformInFrontOfLadder = transform;
    }

    public void Deregister()
    {
        Debug.Log("ladder end");
        _transformInFrontOfLadder = null;
    }
}
