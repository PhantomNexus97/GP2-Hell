using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    //Player
    public UnitHealthSystem _playerHealth = new UnitHealthSystem(200, 200);


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

    }


    public void PlayerTakeDamage(int dmg)
    {
        _playerHealth.DmgUnit(dmg);
    }


}
