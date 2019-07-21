using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
	
	public GameObject inventoryController;
	
	public Transform slotPanel;

    public GameObject invPanel;

    public int selectionIndex = 1;

    private bool isOpen = false;
	
	private InventoryController ic;
	
	private SlotController[] slots;
	
	private GameObject descPanel;
	
	private new Text name;
	private Text desc;
	private Text stats;

  	private int itemCount;
	private int oldSelectionIndex;

    private Text itemdesc;
	
	private Color normalColor;
	private Color highlightedColor;

	private GameObject playerClone;
	private GameObject displayCamera;

	private void Start() {
		
		ic = inventoryController.GetComponent<InventoryController>();
		
		ic.onInventoryChangeCallback += UpdateInventoryUI;
		
		slots = slotPanel.GetComponentsInChildren<SlotController>();
 
        // itemCount = ic.GetNumItems();
		
		descPanel = invPanel.transform.GetChild(3).gameObject;
		
		name = descPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
		
		desc = descPanel.transform.GetChild(1).gameObject.GetComponent<Text>();
		
		stats = descPanel.transform.GetChild(2).gameObject.GetComponent<Text>();
		
		// oldSelectionIndex = selectionIndex;

    }

    private void Update()
    {
		if (!isOpen && this.playerClone) {
			Destroy (this.playerClone);
		}
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.A) ||
				Input.GetButtonDown("RBGreen") ||
				Input.GetButtonDown("GHGreen"))
            {
				slots [selectionIndex].Unselect ();
				if (selectionIndex == 0)
				{
					selectionIndex = ic.GetMaxInventorySlots() - 1;
				} else {
					selectionIndex--;
				}
            }
            if (Input.GetKeyDown(KeyCode.S) ||
				Input.GetButtonDown("RBRed") ||
				Input.GetButtonDown("GHRed"))
            {
				slots [selectionIndex].Unselect ();
				if (selectionIndex == ic.GetMaxInventorySlots() - 1)
				{
					selectionIndex = 0;
				} else {
					selectionIndex++;
				}
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
            }
				
			slots [selectionIndex].Select ();
			if (slots[selectionIndex].ContainsItem())
            {
				SetSelectedData (slots [selectionIndex]);

            } 

            /*
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (slots[selectionIndex].ContainsItem())
                {

                }
            }
            */
        
        }
    }

	public bool IsOpen() {
		return isOpen;
	}

	public void ToggleOpen() {
		/* ResetSlots ();
		selectionIndex = 0;
		slots [selectionIndex].Select ();
		isOpen = !isOpen;
		invPanel.SetActive(isOpen); */
	}

	private void SetSelectedData(SlotController slot) {
		name.text = slot.GetName();
		desc.text = slot.GetDescription();
		stats.text = slot.GetStats();
	}

	private void ResetSlots() {
		foreach (SlotController slot in slots) {
			slot.Unselect ();
		}
	}


    private void UpdateInventoryUI() {
		
		List<GameObject> inventory = ic.GetInventory();
		
		for (int i = 0; i < slots.Length; i++) {
			
			if (i < inventory.Count) {
				
				slots[i].AddItemToSlot(inventory[i]);
				
			} else {
				
				slots[i].ClearSlot();
				
			}
			
		}
		
	}
	
	
	public void SetInventoryController(GameObject ic) {
		
		inventoryController = ic;
		
	}

	public void SetPlayer(GameObject player, GameObject displayCamera) {
		this.playerClone = Instantiate(player);
		foreach (Transform child in this.playerClone.transform) {
			//Change child.name to child.tag when possible
			if (child.name == "GuitarNotes" || child.name == "Main Camera")
				Destroy (child.gameObject);
		}
		this.playerClone.transform.position = new Vector3 (0, 1000, 0);
		this.displayCamera = Instantiate(displayCamera);
		this.displayCamera.transform.parent = this.playerClone.transform;
		this.displayCamera.transform.localPosition = new Vector3(0f, 0.22f, 10f);
		this.displayCamera.transform.localRotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);
		this.playerClone.GetComponent<Rigidbody> ().useGravity = false;
	}



}
