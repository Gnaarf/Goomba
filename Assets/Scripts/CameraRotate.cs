using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    [SerializeField] Transform goombaTransform;
    [SerializeField] Transform marioTransform;

    Transform target;

    Coroutine coroutine;

    private void Start()
    {
        SetNewTarget(Perspective.Current);
        Perspective.OnPerspectiveChange += (a, b) => {if (a != b) { Rotate(); } };
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), 0.1f);
    }

    void SetNewTarget(PerspectiveOption perspective)
    {
        target = perspective == PerspectiveOption.Mario ? marioTransform : goombaTransform;
    }

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

        SetNewTarget(Perspective.Current);
    }
}
