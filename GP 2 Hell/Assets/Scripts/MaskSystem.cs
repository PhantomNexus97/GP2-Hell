using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSystem : MonoBehaviour
{
    public float _maskStamina = 100f;
    public bool _maskActive = false;
    public bool _maskBroken = false;
    public KeyCode _maskKey = KeyCode.Q;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_maskKey))
        {  
            ActiveMask();
        }

        if(_maskActive == true)
        {
            if (_maskStamina > 0)
            {
                _maskStamina -= Time.deltaTime;
                Debug.Log("Mask Active");
            }
            else
            {
                Debug.Log("Mask Destoryed");
                _maskStamina = 0;
                _maskBroken = true;
                _maskActive = false;
            }
        }
    }

    void ActiveMask()
    {
        _maskActive = true;
    }
}
