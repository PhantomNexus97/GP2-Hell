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

    [Header("On Display")]
    public bool _serveredStagsHeadDisplayed = false;
    public bool _stagsHeartDisplayed = false;
    public bool _stagsLegDisplayed = false;
    public bool _stagDecayingPhalliDisplayed = false;
    public bool _stagsHoofDisplayed = false;
    public bool _stagsEyeballDisplayed = false;
    public bool _stagsTorsoDisplayed = false;

    [Header("Input Key")]
    public KeyCode _InputKey = KeyCode.E;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "StagHeadDisplay" && inventory._serveredStagsHead == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _serveredStagsHeadDisplayed = true;
                inventory._serveredStagsHead = false;
                _serveredStagsHead.SetActive(true);
            }
        }

        if (gameObject.name == "StagHeartDisplay" && inventory._serveredStagsHead == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _stagsHeartDisplayed = true;
                inventory._stagsHeart = false;
                _stagsHeart.SetActive(true);
            }
        }

        if (gameObject.name == "StagLegDisplay" && inventory._stagsLeg == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _stagsLegDisplayed = true;
                inventory._stagsLeg = false;
                _stagsLeg.SetActive(true);
            }
        }

        if (gameObject.name == "DecayingPhalliDisplay" && inventory._stagDecayingPhalli == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _stagDecayingPhalliDisplayed = true;
                inventory._stagDecayingPhalli = false;
                _stagDecayingPhalli.SetActive(true);
            }
        }

        if (gameObject.name == "HoofDisplay" && inventory._stagsHoof == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _stagsHoofDisplayed = true;
                inventory._stagsHoof = false;
                _stagsHoof.SetActive(true);
            }
        }

        if (gameObject.name == "EyeballDisplay" && inventory._stagsEyeball == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _stagsEyeballDisplayed = true;
                inventory._stagsEyeball = false;
                _stagsEyeball.SetActive(true);
            }
        }

        if (gameObject.name == "TorsoDisplay" && inventory._stagsTorso == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _stagsTorsoDisplayed = true;
                inventory._stagsTorso = false;
                _stagsTorso.SetActive(true);
            }
        }
    }
}
