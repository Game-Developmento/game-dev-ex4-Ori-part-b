using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickSpawner : MonoBehaviour
{
    [SerializeField] public InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] public GameObject prefabToSpawn;
    [SerializeField] public Vector3 velocityOfSpawnedObject;

    [SerializeField] public float spawnDelay;

    private bool canSpawn = true;


    private void OnEnable()
    {
        spawnAction.Enable();
    }
    private void OnDisable()
    {
        spawnAction.Disable();
    }

    protected GameObject spawnObject()
    {
        if (canSpawn)
        {
            this.canSpawn = false;
            StartCoroutine(activeDelay());
            Vector3 positionOfSpawnedObject = transform.position;
            Quaternion rotationOfSpawnedObject = Quaternion.identity; // no rotation
            GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
            Mover newObjectMover = newObject.GetComponent<Mover>();
            if (newObjectMover)
            {
                newObjectMover.SetVelocity(velocityOfSpawnedObject);
            }

            return newObject;
        }
        return null;
    }

    IEnumerator activeDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        this.canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            spawnObject();
        }

    }
}
