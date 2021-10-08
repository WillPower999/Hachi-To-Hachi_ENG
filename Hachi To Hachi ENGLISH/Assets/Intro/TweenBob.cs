using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenBob : MonoBehaviour
{
    public float bobDuration;
    public float bobDistance;

    void Start()
    {
        StartCoroutine(Bob());
    }

    private IEnumerator Bob()
    {
        transform.DOMoveY(transform.position.y + bobDistance, bobDuration);
        yield return new WaitForSeconds(bobDuration);
        transform.DOMoveY(transform.position.y - bobDistance, bobDuration);
        yield return new WaitForSeconds(bobDuration);
        StartCoroutine(Bob());
    }
}
