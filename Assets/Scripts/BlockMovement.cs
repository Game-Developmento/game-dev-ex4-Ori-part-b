using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] string triggeringTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        inputMover mover = other.GetComponent<inputMover>();

        if (mover && other.tag == triggeringTag && gameObject.activeSelf)
        {
            mover.setIsBlocked(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        inputMover mover = other.GetComponent<inputMover>();
        if (mover)
        {
            mover.setIsBlocked(true);
        }
    }
}
