using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    [SerializeField] string triggerTag;
    private float ignoreTimer = 1.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ignoreTimer <= 0 && other.CompareTag(triggerTag))
        {
            Debug.Log("hit!");
            ignoreTimer = 1.0f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        ignoreTimer -= Time.deltaTime;
    }
}
