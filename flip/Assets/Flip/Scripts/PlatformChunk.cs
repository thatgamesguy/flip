using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChunk : MonoBehaviour
{
    public float scaleSpeed = 2f;

    private static readonly float MIN_SCALE = 0.1f;

    public void Remove()
    {
        StartCoroutine(DoRemove());
    }

    private IEnumerator DoRemove()
    {
        while(transform.localScale.x >= MIN_SCALE)
        {
            transform.localScale -= (Vector3)Vector2.one * scaleSpeed * Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
