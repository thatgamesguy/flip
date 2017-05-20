using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChunk : MonoBehaviour
{
    public void Remove()
    {
        StartCoroutine(DoRemove());
    }

    private IEnumerator DoRemove()
    {
        while(transform.localScale.x >= 0f)
        {
            transform.localScale -= Vector3.one * 2f * Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
