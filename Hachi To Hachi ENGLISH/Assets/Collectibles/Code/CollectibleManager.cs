using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    [SerializeField] List<GameObject> squeals;
    [SerializeField] GameObject squealBrick;

    int bricksCollected;
    [SerializeField] TextMeshProUGUI brickCounter;

    AudioSource audioSource;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        squealBrick.SetActive(false);
    }

    public void PlayCollectSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void HandleSquealCollected(GameObject squealCollected)
    {
        squeals.Remove(squealCollected);
        if (squeals.Count <= 0)
        {
            squealBrick.SetActive(true);
        }
    }

    public void HandleBrickCollected()
    {
        bricksCollected++;
        brickCounter.SetText(" x 0" + bricksCollected.ToString());
    }
}
