using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }

    public IEnumerator ShakeScreen(float duration, float magnitude)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.position = new Vector3(target.position.x + xOffset, target.position.y + yOffset, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //transform.localPosition = transform.position;
    }
}
