using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 20f;

    private bool isBlocked = true;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);

    public void setIsBlocked(bool value)
    {
        this.isBlocked = value;
    }
    void OnEnable()
    {
        moveHorizontal.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (isBlocked)
        {
            float horizontal = moveHorizontal.ReadValue<float>();
            Vector3 movementVector = Vector3.right * horizontal * speed * Time.deltaTime;
            transform.position += movementVector;
        }
    }
}
