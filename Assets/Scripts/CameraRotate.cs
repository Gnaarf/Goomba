using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    Coroutine coroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coroutine == null)
        {
            coroutine = StartCoroutine(TurnCamera(.5f));
        }
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
