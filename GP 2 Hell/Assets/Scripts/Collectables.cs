using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
   public PlayerInventory inventory;
    void OnTriggerEnter(Collider Col)
    {
        PlayerInventory inventory = Col.GetComponent<PlayerInventory>();

        if (gameObject.tag == "StagHead" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundStagHead();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }

        if (gameObject.tag == "StagHeart" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundHeart();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }

        if (gameObject.tag == "StagLeg" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundLeg();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }

        if (gameObject.tag == "StagsDecayingPhalli" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundDecayingPhalli();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }

        if (gameObject.tag == "StagHoof" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundStagHoof();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }

        if (gameObject.tag == "StagEyeballs" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundStagEyeball();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }

        if (gameObject.tag == "StagTorso" && inventory._holdingItem == false)
        {
            if (inventory != null)
            {
                inventory.FoundStagTorso();
                gameObject.SetActive(false);
                inventory._heldItem.SetActive(true);
                inventory._holdingItem = true;

            }
        }


    }
}
