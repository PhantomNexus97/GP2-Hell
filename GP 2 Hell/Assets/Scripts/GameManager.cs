using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    //Player
    public UnitHealthSystem _playerHealth = new UnitHealthSystem(200, 200);

    public bool _placedStagHead, _placedStagTorso, _placedStagEye, _placedStagHeart, _placedStagHoof,
        _placedStagLeg, _placedStagPhalli = false;

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
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheeseEnemy")
        {
            _placedStagHead = true;
        }
    }

    public void PlayerTakeDamage(int dmg)
    {
        _playerHealth.DmgUnit(dmg);
    }


}
