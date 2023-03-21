using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAlter : MonoBehaviour
{
    PlayerInventory inventory;

    [Header("Input Display Text")]
    public GameObject _InputKeyDisplay;

    [Header("Objects to Display")]
    public GameObject _serveredStagsHead;
    public GameObject _stagsHeart;
    public GameObject _stagsLeg;
    public GameObject _stagDecayingPhalli;
    public GameObject _stagsHoof;
    public GameObject _stagsEyeball;
    public GameObject _stagsTorso;

    [Header("Input Key")]
    public KeyCode _InputKey = KeyCode.E;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "StagHeadDisplay" && inventory._serveredStagsHead == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._serveredStagsHead = false;
                _serveredStagsHead.SetActive(true);
            }
        }

        if (gameObject.tag == "StagHeartDisplay" && inventory._serveredStagsHead == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._stagsHeart = false;
                _stagsHeart.SetActive(true);
            }
        }

        if (gameObject.tag == "StagLegDisplay" && inventory._stagsLeg == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._stagsLeg = false;
                _stagsLeg.SetActive(true);
            }
        }

        if (gameObject.tag == "DecayingPhalliDisplay" && inventory._stagDecayingPhalli == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._stagDecayingPhalli = false;
                _stagDecayingPhalli.SetActive(true);
            }
        }

        if (gameObject.tag == "HoofDisplay" && inventory._stagsHoof == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._stagsHoof = false;
                _stagsHoof.SetActive(true);
            }
        }

        if (gameObject.tag == "EyeballDisplay" && inventory._stagsEyeball == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._stagsEyeball = false;
                _stagsEyeball.SetActive(true);
            }
        }

        if (gameObject.tag == "TorsoDisplay" && inventory._stagsTorso == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                inventory._stagsTorso = false;
                _stagsTorso.SetActive(true);
            }
        }
    }
}
