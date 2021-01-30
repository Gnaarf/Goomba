using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{



    public static IEnumerator LinearMovementCoroutine(Transform movementPerformer, Vector3 targetPosition, float duration, Action OnCoroutineFinished = null)
    {
        Vector3 startPosition = movementPerformer.position;

        float coroutineRunTime = 0f;

        while (coroutineRunTime < duration)
        {
            coroutineRunTime += Time.deltaTime;
            movementPerformer.position = Vector3.Lerp(startPosition, targetPosition, coroutineRunTime / duration);
            yield return null;
        }

        movementPerformer.position = targetPosition;

        if(OnCoroutineFinished != null)
        {
            OnCoroutineFinished();
        }
    }


}
