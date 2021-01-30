using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    Coroutine coroutine;

    public bool Rotate()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(TurnCamera(.5f));
            return true;
        }
        return false;
    }

    IEnumerator TurnCamera(float duration)
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;

        float coroutineRunTime = 0f;
        Vector3 rotationPoint = new Vector3(transform.position.x, transform.position.y, 0f);

        while(coroutineRunTime < duration)
        {
            coroutineRunTime += Time.deltaTime;
            transform.RotateAround(rotationPoint, Vector3.up, Time.deltaTime / duration * 180);
            yield return null; 
        }

        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.RotateAround(rotationPoint, Vector3.up, 180);

        coroutine = null;
    }
}
