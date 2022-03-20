using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLight : MonoBehaviour
{
    private bool canGenerate = true;

    // Update is called once per frame
    void Update()
    {
        if (canGenerate)
            StartCoroutine(LightGenerator());
    }

    IEnumerator LightGenerator()
    {
        GameObject bullet = LightPool.SharedInstance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = transform.position; 
            bullet.SetActive(true);
        }
        canGenerate = false;
        yield return new WaitForSeconds(1.2f);
        canGenerate = true;
    }
}
