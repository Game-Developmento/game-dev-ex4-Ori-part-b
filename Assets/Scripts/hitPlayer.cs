using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    [SerializeField] string triggerTag;
    [SerializeField] float visibilityDuration = 2.0f;
    [SerializeField] float winkSpeed = 10.0f;

    private float visibilityTimer = 0.0f;

    private bool isWinking = false;

    private Renderer otherRenderer;
    private float ignoreTimer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (visibilityTimer <= 0.0f && ignoreTimer <= 0 && other.CompareTag(triggerTag))
        {
            Debug.Log("hit!");
            otherRenderer = other.GetComponent<Renderer>();
            ignoreTimer = 1.0f;
            visibilityTimer = visibilityDuration;
            isWinking = true;

        }
    }
    private void Start()
    {
        ignoreTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ignoreTimer -= Time.deltaTime;
        if (isWinking)
        {
            float visibilityAmount = Mathf.PingPong(Time.time * winkSpeed, 1);

            otherRenderer.enabled = visibilityAmount > 0.5f;
            if (visibilityTimer <= 0)
            {
                isWinking = false;
                otherRenderer.enabled = true;
            }
            visibilityTimer -= Time.deltaTime;
        }

    }
}
