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
        // gameOver.gameObject.SetActive(false);

    }

    private void handleFirstCase()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    private void handleSecondCase()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(false);
    }
    private void handleThirdCase()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);

    }
    private void handleLastCase()
    {
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
        // gameOver.gameObject.SetActive(true);
    }
    IEnumerator getImmunity(float duration)
    {
        this.isImmune = true;
        yield return new WaitForSeconds(duration);
        this.isImmune = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 3:
                handleFirstCase();
                break;
            case 2:
                handleSecondCase();
                break;
            case 1:
                handleThirdCase();
                break;
            case 0:
                handleLastCase();
                Time.timeScale = 0;
                break;

        }

    }
}
