using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileSpawn : MonoBehaviour
{
    public GameObject _objectToActivate;
    public float _spawnChance = 0.3f;
    public float _deactivateDelay = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player or another object you want to trigger the activation
        if (other.CompareTag("Player"))
        {
            // Generate a random number between 0 and 1
            float randomValue = Random.value;

            // Check if the random value is less than the spawn chance
            if (randomValue < _spawnChance)
            {
                // Activate the game object
                _objectToActivate.SetActive(true);

                // Deactivate the game object after the delay
                Invoke("DeactivateObject", _deactivateDelay);
            }
        }
    }

    private void DeactivateObject()
    {
        // Deactivate the game object
        _objectToActivate.SetActive(false);
    }
}
