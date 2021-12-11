using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBarV2 : MonoBehaviour
{
    public static HealthBarV2 Instance;

    public List<GameObject> healthIcons;
    public int _maxHealth;
    public int _currentHealth;
    private bool _canTakeDamage;

    void Awake()
    {
        Instance = this;
        _maxHealth = healthIcons.Count;
        _currentHealth = _maxHealth;
        _canTakeDamage = true;
    }

    //ONLY FOR TESTING
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddHealth();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DeductHealth();
        }
    }

    public void AddHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth++;

            foreach (GameObject healthIcon in healthIcons)
            {
                healthIcon.SetActive(false);
            }

            for (int i = 0; i < _currentHealth; i++)
            {
                healthIcons[i].SetActive(true);
            }
        }
    }

    public void DeductHealth()
    {
        if (!_canTakeDamage) return;

        if (_currentHealth > 1)
        {
            _currentHealth--;

            foreach (GameObject healthIcon in healthIcons)
            {
                healthIcon.SetActive(false);
            }

            for (int i = 0; i < _currentHealth; i++)
            {
                healthIcons[i].SetActive(true);
            }

            StartCoroutine(DeductHealthBuffer());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private IEnumerator DeductHealthBuffer()
    {
        _canTakeDamage = false;
        yield return new WaitForSeconds(.5f);
        _canTakeDamage = true;
    }
}
