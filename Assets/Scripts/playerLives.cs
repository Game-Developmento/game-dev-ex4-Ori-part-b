using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLives : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, gameOver;
    private int health;
    private bool isImmune = false;


    public void decrementLife()
    {
        this.health -= 1;
    }

    public bool getImmune()
    {
        return this.isImmune;
    }
    public void activeImmunity(float duration)
    {
        StartCoroutine(getImmunity(duration));
    }
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

    }

    IEnumerator getImmunity(float duration)
    {
        this.isImmune = true;
        yield return new WaitForSeconds(duration);
        this.isImmune = false;
    }
    void Update()
    {
        switch (health)
        {
            case 2:
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart2.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;

        }

    }
}
