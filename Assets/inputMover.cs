using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);


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
        float horizontal = moveHorizontal.ReadValue<float>();
        Vector3 movementVector = Vector3.right * horizontal * speed * Time.deltaTime;
        transform.position += movementVector;

    }
}
