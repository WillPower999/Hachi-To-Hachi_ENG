using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectible : MonoBehaviour
{
    public Vector3 rotationDirection;
    public float rotationSpeed;
    private float _initialYPosition;
    public float bobDistance;
    public float bobDuration;
    public Ease ease;
    [HideInInspector] public bool canCollect;
    public AudioClip collectSound;

    public enum CollectibleType
    {
        Daifuku,
        Tako,
        Orb,
        Brick,
        Squeal
    }

    public CollectibleType activeType;

    private void Start()
    {
        canCollect = true;
        StartCoroutine(BobCo());
        _initialYPosition = transform.position.y;
    }

    private void Update()
    {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(_initialYPosition + bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        transform.DOMoveY(_initialYPosition - bobDistance, bobDuration).SetEase(ease);
        yield return new WaitForSeconds(bobDuration);
        StartCoroutine(BobCo());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetCollected();
            Destroy(gameObject);
        }
    }

    public void GetCollected()
    {
        if (canCollect)
        {
            if (activeType == CollectibleType.Daifuku)
            {
                if (HealthBarV2.Instance != null)
                {
                    HealthBarV2.Instance.AddHealth();
                }
            }
            else if (activeType == CollectibleType.Squeal)
            {

            }
            else if (activeType == CollectibleType.Brick)
            {

            }

            if (CollectibleManager.Instance != null)
            {
                CollectibleManager.Instance.PlayCollectSound(collectSound);
            }

            canCollect = false;
        }
    }
}
