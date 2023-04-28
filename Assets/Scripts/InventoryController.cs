using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject spaceUI;
    bool onSpaceUI = false;

    public GameObject inventoryUI;
    bool onInventory = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   
        {
            if (onSpaceUI && !onInventory)
            {
                Debug.Log("인벤토리 켜기");
                GameObject.Find("Canvas").transform.Find("Scroll View").gameObject.SetActive(true);
                onInventory = true;
                return;
            }
            if (onInventory)
            {
                Debug.Log("인벤토리 끄기");
                inventoryUI.SetActive(false);
                onInventory = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!onSpaceUI)
            {
                spaceUI.SetActive(true);
                onSpaceUI = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onSpaceUI)
        {
            spaceUI.SetActive(false);
            onSpaceUI = false;
        }
        if (onInventory)
        {
            Debug.Log("인벤토리 끄기");
            inventoryUI.SetActive(false);
            onInventory = false;
        }
    }
}
