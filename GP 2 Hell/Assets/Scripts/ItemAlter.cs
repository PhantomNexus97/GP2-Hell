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
    public KeyCode _inputKey = KeyCode.E;


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

    void OnTriggerStay(Collider col)
    {
        PlayerInventory inventory = col.GetComponent<PlayerInventory>();

        if (gameObject.tag == "SH_Display" && inventory._serveredStagsHead == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
                
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_serveredStagsHeadDisplayed"] = true;
                inventory._serveredStagsHead = false;
                Instantiate(_serveredStagsHead, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                Debug.Log("ItemDisplayed");
                inventory._placedStagHead = true;
            }
        }

        if (gameObject.tag == "SHRT_Display" && inventory._stagsHeart == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
                
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_stagsHeartDisplayed"] = true;
                inventory._stagsHeart = false;
                Instantiate(_stagsHeart, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                Debug.Log("ItemDisplayed");
                inventory._placedStagHeart = true;
            }
        }

        if (gameObject.tag == "SL_Display" && inventory._stagsLeg == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
               
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_stagsLegDisplayed"] = true;
                inventory._stagsLeg = false;
                Instantiate(_stagsLeg, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                inventory._placedStagLeg = true;
            }
        }

        if (gameObject.tag == "SP_Display" && inventory._stagDecayingPhalli == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_stagDecayingPhalliDisplayed"] = true;
                inventory._stagDecayingPhalli = false;
                Instantiate(_stagDecayingPhalli, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                inventory._placedStagPhalli = true;
            }
            
        }

        if (gameObject.tag == "SHF_Display" && inventory._stagsHoof == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_stagsHoofDisplayed"] = true;
                inventory._stagsHoof = false;
                Instantiate(_stagsHoof, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                inventory._placedStagHoof = true;
            }
            
        }

        if (gameObject.tag == "SE_Display" && inventory._stagsEyeball == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_stagsEyeballDisplayed"] = true;
                inventory._stagsEyeball = false;
                Instantiate(_stagsEyeball, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                inventory._placedStagEye = true;
            }
            
        }

        if (gameObject.tag == "ST_Display" && inventory._stagsTorso == true)
        {
            if (Input.GetKeyDown(_inputKey))
            {
                _InputKeyDisplay.SetActive(true);
                _ItemsDisplayed["_stagsTorsoDisplayed"] = true;
                inventory._stagsTorso = false;
                Instantiate(_stagsTorso, _itemSpawnPoint.position, _itemSpawnPoint.rotation);
                inventory._placedStagTorso = true;
            }
            
        }
    }
}
