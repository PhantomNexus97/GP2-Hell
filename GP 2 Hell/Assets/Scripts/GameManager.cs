using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    //Player
    public UnitHealthSystem _playerHealth = new UnitHealthSystem(200, 200);

    ItemAlter alter;
    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    void Update()
    {
        if(alter._serveredStagsHeadDisplayed == true && alter._stagDecayingPhalliDisplayed == true && 
            alter._stagsEyeballDisplayed == true && alter._stagsHeartDisplayed == true &&
            alter._stagsHoofDisplayed == true && alter._stagsLegDisplayed == true && 
            alter._stagsTorsoDisplayed == true)
        {
            Debug.Log("Victory");
        }
        else
        {
            return;
        }

    }


    public void PlayerTakeDamage(int dmg)
    {
        _playerHealth.DmgUnit(dmg);
    }


}
