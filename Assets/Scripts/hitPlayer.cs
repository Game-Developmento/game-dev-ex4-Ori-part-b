using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    [SerializeField] string triggerTag;
    [SerializeField] float duration = 2.5f;
    [SerializeField] float winkSpeed = 5.0f;

    private Renderer playerRenderer;
    private float ignoreTimer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ignoreTimer <= 0 && other.CompareTag(triggerTag))
        {
            Debug.Log("hit!");
            ignoreTimer = 1.0f;
            playerRenderer = other.GetComponent<Renderer>();
            this.StartCoroutine(playerHit(playerRenderer));
        }
    }

    IEnumerator playerHit(Renderer playerRenderer)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float visibilityValue = Mathf.PingPong(Time.time * winkSpeed, 1);
            bool isVisible = visibilityValue > 0.5f;
            playerRenderer.enabled = isVisible;
            yield return null;

        }
        playerRenderer.enabled = true;
    }
    private void Start()
    {
        ignoreTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ignoreTimer -= Time.deltaTime;

    }
}
