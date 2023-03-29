using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemAlter : MonoBehaviour
{
    public PlayerInventory inventory;

    GameManager manager;

    public bool _itemAlterTrigger = false;

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

    [Header("Object Spawn Points")]
    public Transform _itemSpawnPoint_01;
    public Transform _itemSpawnPoint_02;
    public Transform _itemSpawnPoint_03;
    public Transform _itemSpawnPoint_04;
    public Transform _itemSpawnPoint_05;
    public Transform _itemSpawnPoint_06;
    public Transform _itemSpawnPoint_07;

    [Header("Input Key")]
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

    private void OnTriggerEnter(Collider other)
    {
        _itemAlterTrigger = true;
        _InputKeyDisplay.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        _itemAlterTrigger = false;
        _InputKeyDisplay.SetActive(false);

    }
    private void Update()
    {
        if(_itemAlterTrigger == true) 
        {
            if (Input.GetKeyUp(_inputKey))
            {
                if (gameObject.tag == "Offering Table" && inventory._serveredStagsHead == true)
                {

                    _ItemsDisplayed["_serveredStagsHeadDisplayed"] = true;
                    inventory._serveredStagsHead = false;
                    Instantiate(_serveredStagsHead, _itemSpawnPoint_01.position, _itemSpawnPoint_01.rotation);
                    Debug.Log("ItemDisplayed");
                    inventory._placedStagHead = true;

                }
                else if (gameObject.tag == "Offering Table" && inventory._stagsHeart == true)
                {

                    _ItemsDisplayed["_stagsHeartDisplayed"] = true;
                    inventory._stagsHeart = false;
                    Instantiate(_stagsHeart, _itemSpawnPoint_02.position, _itemSpawnPoint_02.rotation);
                    Debug.Log("ItemDisplayed");
                    inventory._placedStagHeart = true;
                }
                else if (gameObject.tag == "Offering Table" && inventory._stagsLeg == true)
                {

                    _ItemsDisplayed["_stagsLegDisplayed"] = true;
                    inventory._stagsLeg = false;
                    Instantiate(_stagsLeg, _itemSpawnPoint_03.position, _itemSpawnPoint_03.rotation);
                    inventory._placedStagLeg = true;
                }
                else if (gameObject.tag == "Offering Table" && inventory._stagDecayingPhalli == true)
                {

                    _ItemsDisplayed["_stagDecayingPhalliDisplayed"] = true;
                    inventory._stagDecayingPhalli = false;
                    Instantiate(_stagDecayingPhalli, _itemSpawnPoint_04.position, _itemSpawnPoint_04.rotation);
                    inventory._placedStagPhalli = true;
                }
                else if (gameObject.tag == "Offering Table" && inventory._stagsHoof == true)
                {
                    _ItemsDisplayed["_stagsHoofDisplayed"] = true;
                    inventory._stagsHoof = false;
                    Instantiate(_stagsHoof, _itemSpawnPoint_05.position, _itemSpawnPoint_05.rotation);
                    inventory._placedStagHoof = true;
                }
                else if (gameObject.tag == "Offering Table" && inventory._stagsEyeball == true)
                {
                    _ItemsDisplayed["_stagsEyeballDisplayed"] = true;
                    inventory._stagsEyeball = false;
                    Instantiate(_stagsEyeball, _itemSpawnPoint_06.position, _itemSpawnPoint_06.rotation);
                    inventory._placedStagEye = true;
                }
                else if (gameObject.tag == "Offering Table" && inventory._stagsTorso == true)
                {
                    _ItemsDisplayed["_stagsTorsoDisplayed"] = true;
                    inventory._stagsTorso = false;
                    Instantiate(_stagsTorso, _itemSpawnPoint_07.position, _itemSpawnPoint_07.rotation);
                    inventory._placedStagTorso = true;
                }
                else
                {
                    return;
                }
            }

        }
    }
    //void OnTriggerStay(Collider col)
    //{
        //PlayerInventory inventory = col.GetComponent<PlayerInventory>();

        //_InputKeyDisplay.SetActive(true);


        //if (Input.GetKeyDown(_inputKey))
        //{


        //}
    //}
}
