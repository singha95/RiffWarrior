using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour {

	public GameObject[] lootTable;
	
	private bool opened;
    private bool found;
	
	private GameObject inventoryController;
	
	private List<GameObject> chestItems;

	
	private void Awake() {
		
		opened = false;

	}
    public void Update()
    {
        if (found && !opened)
        {
            OpenChest();
            opened = true;
        }
    }

	
    public void OpenChest() {
		RollForLoot();
    }


	private void RollForLoot() {
        chestItems = new List<GameObject>();
        // float random = Random.Range(1, 100);
        foreach (GameObject item in lootTable)
        {
            Item loot = item.GetComponent<Item>();
            if (loot.GetDropChance() >= 0) chestItems.Add(item);
        }
        // Debug.Log(chestItems.ToArray().Length);
		StartCoroutine("DispenseItems");
	}
	
    void OnTriggerStay(Collider other)
    {
        if (!opened && other.gameObject.CompareTag("Player") &&
			(Input.GetKeyDown(KeyCode.Q) ||
			Input.GetButtonDown("RBBlue") ||
			Input.GetButtonDown("GHBlue")))
        {
            found = true;
        }
    }

	
	public void SetInventoryController(GameObject ic) {
		
		// inventoryController = ic;
		
	}
	
	
	private IEnumerator DispenseItems() {
		
		Vector3 position = new Vector3(
			transform.position.x, 
			transform.position.y + 5.0f, 
			transform.position.z
		);
		
		while (chestItems.Count > 0) {	
		
			GameObject newLoot = Instantiate(
				chestItems[0], 
				position, 
				Quaternion.identity
			);
		
			Rigidbody rigidbody = newLoot.GetComponent<Rigidbody>();
		
			float direction = Random.Range(5.0f, 5.0f);
			
			rigidbody.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
			
			rigidbody.AddForce(new Vector3(direction, 0.0f, 0.0f), ForceMode.Impulse);
			
			chestItems.RemoveAt(0);
			
			yield return new WaitForSeconds(0.25f);
			
		}
		
	}

}
