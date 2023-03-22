using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Items Found")]
    public bool _serveredStagsHead = false;
    public bool _stagsHeart = false;
    public bool _stagsLeg = false;
    public bool _stagDecayingPhalli = false;
    public bool _stagsHoof = false;
    public bool _stagsEyeball = false;
    public bool _stagsTorso = false;

    public bool _placedStagHead, _placedStagTorso, _placedStagEye, _placedStagHeart, _placedStagHoof,
    _placedStagLeg, _placedStagPhalli = false;
    void Update()
    {
        if (_placedStagEye == true && _placedStagHead == true &&
           _placedStagTorso == true && _placedStagHeart == true &&
           _placedStagLeg == true && _placedStagPhalli == true &&
           _placedStagHoof == true)
        {
            Debug.Log("GameOver");
        }
    }

    public void FoundStagHead()
    {
        _serveredStagsHead = true;
    }

    public void FoundHeart()
    {
        _stagsHeart = true;
    }

    public void FoundLeg()
    {
        _stagsLeg = true;
    }

    public void FoundDecayingPhalli()
    {
        _stagDecayingPhalli = true;
    }

    public void FoundStagHoof()
    {
        _stagsHoof = true;
    }

    public void FoundStagEyeball()
    {
        _stagsEyeball = true;
    }

    public void FoundStagTorso()
    {
        _stagsTorso = true;
    }
}
