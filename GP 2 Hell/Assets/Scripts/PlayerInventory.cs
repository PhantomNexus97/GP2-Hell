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

    [Header("Items Placed")]
    public bool _placedStagHead = false;
    public bool _placedStagTorso = false;
    public bool _placedStagEye = false;
    public bool _placedStagHeart = false;
    public bool _placedStagHoof = false;
    public bool _placedStagLeg = false;
    public bool _placedStagPhalli = false;

    [Header("Holding Item")]
    public bool _holdingItem = false;
    public GameObject _heldItem;


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
