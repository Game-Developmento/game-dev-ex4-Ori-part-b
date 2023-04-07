using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    [SerializeField] string triggerTag;
    [SerializeField] float duration = 2.5f; // the duration of the "hit" effect
    [SerializeField] float winkSpeed = 5.0f; // the speed of the "winking" effect

    private Renderer playerRenderer;
    private float ignoreTimer; // the timer to prevent self-hitting
    private bool isCoroutineFinished = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the object can trigger a hit and if the ignore timer is over
        if (ignoreTimer <= 0 && other.CompareTag(triggerTag))
        {
            Debug.Log("hit!");

            // decrement the player's life
            playerLives otherPlayerLive = other.GetComponent<playerLives>();
            if (otherPlayerLive != null && !otherPlayerLive.getImmune())
            {
                otherPlayerLive.decrementLife();
            }

            // activate immunity
            otherPlayerLive.activeImmunity(duration);

            playerRenderer = other.GetComponent<Renderer>();
            StartCoroutine(playerHit(playerRenderer));

            gameObject.GetComponent<Renderer>().enabled = false;
            ignoreTimer = 1.0f;
        }


    }

    IEnumerator playerHit(Renderer playerRenderer)
    {
        isCoroutineFinished = false;
        float startTime = Time.time;

        // play the "winking" effect for the duration of the effect
        while (Time.time - startTime < duration)
        {
            float visibilityValue = Mathf.PingPong(Time.time * winkSpeed, 1);
            bool isVisible = visibilityValue > 0.5f;
            playerRenderer.enabled = isVisible;
            yield return null;
        }
        playerRenderer.enabled = true;
        isCoroutineFinished = true;
        Destroy(gameObject);

    }
    private void Start()
    {
        ignoreTimer = 1.0f;
    }

    void Update()
    {
        ignoreTimer -= Time.deltaTime;

    }
    private void OnBecameInvisible()
    {
        if (isCoroutineFinished)
        {
            Destroy(gameObject);
        }

    }
}
