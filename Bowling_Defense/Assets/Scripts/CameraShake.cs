using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 OriginalPosition = transform.localPosition;

        float ElapsedTime = 0.0f;

        while(ElapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, OriginalPosition.z);
            
            ElapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = OriginalPosition;
    }
}
