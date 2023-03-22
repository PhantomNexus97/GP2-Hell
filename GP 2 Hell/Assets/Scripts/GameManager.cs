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

    public bool allTrue = true;
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

    public void PlayerTakeDamage(int dmg)
    {
        _playerHealth.DmgUnit(dmg);
    }


}
