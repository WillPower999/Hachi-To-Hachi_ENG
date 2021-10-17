using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaifukuManager : MonoBehaviour
{
    public static DaifukuManager Instance;

    private int _totalCoinsInLevel;
    private int _collectedCoinsInLevel;
    private int _totalCoinsInGame;

    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI coinCountTwo;

    public AudioSource collectSound;

    private void Awake()
    {
        Instance = this;
        _totalCoinsInLevel = FindObjectsOfType<Daifuku>().Length;
        DisplayCoinCount();

        _totalCoinsInGame = PlayerPrefs.GetInt("coinCount");
    }

    void DisplayCoinCount()
    {
        //coinCount.SetText(_collectedCoinsInLevel + "/" + _totalCoinsInLevel);
        //coinCountTwo.SetText(_collectedCoinsInLevel + "/" + _totalCoinsInLevel);

        //coinCount.SetText(_collectedCoinsInLevel + "/" + _totalCoinsInLevel);
        //coinCountTwo.SetText(_collectedCoinsInLevel + "/" + _totalCoinsInLevel);
    }

    public void IncrementCollectedCoinCount()
    {
        _collectedCoinsInLevel++;
        DisplayCoinCount();

        PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") + 1);

        /*if (_collectedCoinsInLevel >= _totalCoinsInLevel)
        {
            //You Win Menu? Or Level Continue
            YouWinMenu.Instance.Show("You Win!");
        }*/
    }
}
