using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	
	public delegate void OnInventoryChange();
	
	public OnInventoryChange onInventoryChangeCallback;

    private int maxInventorySlots;

    private List<GameObject> inventory;

    public bool isOpen = false;

    private void Awake() {

        maxInventorySlots = 16;
		
		inventory = new List<GameObject>();

    }


	public void AddItemToInventory(GameObject item) {
		
		if (inventory.Count >= maxInventorySlots) {
			
			Debug.Log("Inventory is full");
			
		} else {
			
			inventory.Add(item);
			
			if (onInventoryChangeCallback != null) {
				
				onInventoryChangeCallback.Invoke();
				
			}
			
			DisplayLootMessage(item);
			
		}
		
	}
	
	
	private void DisplayLootMessage(GameObject item) {
		
		// Display loot message on HUD
		
	}
	
	
	private void RemoveItemFromInventory(GameObject item) {
		
		inventory.Remove(item);

		if (onInventoryChangeCallback != null) {

			onInventoryChangeCallback.Invoke();

		}
		
	}


    private void DisplayInventory() {

        // If player is not in combat (there is a function that returns the status
        // somewhere), and they press one of the fret buttons, display the
        // inventory on the HUD. Ask Jess for 2D drawing of an inventory system!
        // Might also need a display of the character to the side, and what he's
        // wearing

    }


    private void NavigateInventory() {

        // Change players buttons based on inInventory. I think it is
        // ideal if the inventory is an nxn grid, and downstrum goes down,
        // upstrum goes up, green button goes left, red button goes right
		
		// Maybe need to set up another bool of the player to be inInventory,
		// and set controls based on that (tell Shawn to do it)

        /*
            if (Input.GetKeyDown(KeyCode.Q) || (Input.GetButtonUp("RBGreen"))) {
                //go left
                selectionIndex--;
            }
            if (Input.GetKeyDown(KeyCode.W) || (Input.GetButtonUp("RBRed"))) {
                selectionIndex++;
            }
            */
    }
	
	
	private void CloseInventory() {
		
		
		
	}


    private void EquipItem() {

        // This is getting really complex

    }
	
	
	public List<GameObject> GetInventory() {
		
		return inventory;
		
	}

    public int GetNumItems()
    {
        return inventory.Count;
    }
	
	
	public int GetMaxInventorySlots() {
		
		return maxInventorySlots;
		
	}


}
