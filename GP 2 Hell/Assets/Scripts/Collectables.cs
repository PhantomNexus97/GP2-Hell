using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    PlayerInventory inventory;
    void OnTriggerEnter(Collider Col)
    {
        PlayerInventory inventory = Col.GetComponent<PlayerInventory>();

        if (gameObject.tag == "StagHead")
        {
            if (inventory != null)
            {
                inventory.FoundStagHead();
                gameObject.SetActive(false);

            }
        }

        if (gameObject.tag == "StagHeart")
        {
            if (inventory != null)
            {
                inventory.FoundHeart();
                gameObject.SetActive(false);

            }
        }

        if (gameObject.tag == "StagLeg")
        {
            if (inventory != null)
            {
                inventory.FoundLeg();
                gameObject.SetActive(false);

            }
        }

        if (gameObject.tag == "StagDecayingPhalli")
        {
            if (inventory != null)
            {
                inventory.FoundDecayingPhalli();
                gameObject.SetActive(false);

            }
        }

        if (gameObject.tag == "Staghoof")
        {
            if (inventory != null)
            {
                inventory.FoundStagHoof();
                gameObject.SetActive(false);

            }
        }

        if (gameObject.tag == "StagEyeball")
        {
            if (inventory != null)
            {
                inventory.FoundStagEyeball();
                gameObject.SetActive(false);

            }
        }

        if (gameObject.tag == "StagTorso")
        {
            if (inventory != null)
            {
                inventory.FoundStagTorso();
                gameObject.SetActive(false);

            }
        }


    }
}
