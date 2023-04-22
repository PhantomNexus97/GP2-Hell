using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public bool _triggerSound = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _triggerSound == false)
        {
            _triggerSound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _triggerSound == true)
        {
            _triggerSound = false;
        }
    }
    private void Update()
    {
        if (_triggerSound == true)
        {
            FindObjectOfType<AudioManager>().Play("Lurking");
        }
        else if (_triggerSound == false)
        {
            return;
        }
    }
 
}
