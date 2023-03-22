using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ItemAlter : MonoBehaviour
{
    public PlayerInventory inventory;

    GameManager manager;

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
    public Dictionary<string, bool> _ItemsDisplayed = new Dictionary<string, bool>();
    public Transform _itemSpawnPoint;
    [Header("Input Key")]
    public KeyCode _InputKey = KeyCode.E;

    private void Start()
    {
        _ItemsDisplayed.Add("_serveredStagsHeadDisplayed", false);
        _ItemsDisplayed.Add("_stagsHeartDisplayed", false);
        _ItemsDisplayed.Add("_stagsLegDisplayed", false);
        _ItemsDisplayed.Add("_stagDecayingPhalliDisplayed", false);
        _ItemsDisplayed.Add("_stagsHoofDisplayed", false);
        _ItemsDisplayed.Add("_stagsEyeballDisplayed", false);
        _ItemsDisplayed.Add("_stagsTorsoDisplayed", false);
    }
    public void OnTriggerEnter(Collider Col)
    {
        PlayerInventory inventory = Col.GetComponent<PlayerInventory>();

        if ( gameObject.tag == "SH_Display" && inventory._serveredStagsHead == true)
        {
            _InputKeyDisplay.SetActive(true);
            
                if (Input.GetKeyDown(_InputKey))
                {
                    inventory._serveredStagsHead = false;
                    Instantiate(_serveredStagsHead, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                    Debug.Log("ItemDisplayed");
                }
           
        }

        if (gameObject.tag == "SHRT_Display" && inventory._serveredStagsHead == true)
        {
            _InputKeyDisplay.SetActive(true);
            if (inventory != null)
            {
                if (Input.GetKeyDown(_InputKey))
                {
                    _ItemsDisplayed["_stagsHeartDisplayed"] = true;
                    inventory._stagsHeart = false;
                    Instantiate(_stagsHeart, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                    Debug.Log("ItemDisplayed");
                }
            }
        }

        if (gameObject.tag == "SL_Display" && inventory._stagsLeg == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _ItemsDisplayed["_stagsLegDisplayed"] = true;
                inventory._stagsLeg = false;
                Instantiate(_stagsLeg, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
            }
        }

        if (gameObject.tag == "SP_Display" && inventory._stagDecayingPhalli == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _ItemsDisplayed["_stagDecayingPhalliDisplayed"] = true;
                inventory._stagDecayingPhalli = false;
                Instantiate(_stagDecayingPhalli, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
            }
        }

        if (gameObject.tag == "SHF_Display" && inventory._stagsHoof == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _ItemsDisplayed["_stagsHoofDisplayed"] = true;
                inventory._stagsHoof = false;
                Instantiate(_stagsHoof, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
            }
        }

        if (gameObject.tag == "SE_Display" && inventory._stagsEyeball == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _ItemsDisplayed["_stagsEyeballDisplayed"] = true;
                inventory._stagsEyeball = false;
                Instantiate(_stagsEyeball, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
            }
        }

        if (gameObject.tag == "SL_Display" && inventory._stagsTorso == true)
        {
            _InputKeyDisplay.SetActive(true);

            if (Input.GetKeyDown(_InputKey))
            {
                _ItemsDisplayed["_stagsTorsoDisplayed"] = true;
                inventory._stagsTorso = false;
                Instantiate(_stagsTorso, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
            }
        }
    }
}
