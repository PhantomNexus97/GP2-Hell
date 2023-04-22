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
        if (other.CompareTag("Player"))
        {
       
            float randomValue = Random.value;
            
            if (randomValue < _spawnChance)
            {
                
                _objectToActivate.SetActive(true);
                
                Invoke("DeactivateObject", _deactivateDelay);
            }
        }
    }

    private void DeactivateObject()
    {
        
        _objectToActivate.SetActive(false);
    }
}
