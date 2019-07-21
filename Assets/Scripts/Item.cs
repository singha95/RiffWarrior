using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public new string name;
    public string description;

    public float dropPercentage;
    public float damageReduction;
    public float healthRecovery;

    public int value;

    public Sprite icon;

    private float creationTime;
    private float destroyTime;

    private new Rigidbody rigidbody;

    private bool detected;

    private GameObject inventoryController;
	
	private PlayerController playerController;

    private void Awake() {

        // destroyTime = 300;

        // rigidbody = GetComponent<Rigidbody>();

    }


    private void Update() {

        if (detected && (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("RBBlue") || Input.GetButtonDown("GHBlue")))
        {
            GameObject item = gameObject;
            item.SetActive(false);
			playerController.AddItemToInventory(gameObject);
        }
			//DestroyLoot();

	}


	private void DestroyLoot() {

		

	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			playerController = other.GetComponent<PlayerController>();
            detected = true;
        }
	}
    private void OnTriggerExit(Collider other)
    {
        detected = false;
    }
    public float GetDropChance()
    {
        return dropPercentage;
    }
	
	
	public Sprite GetIcon() {
		
		return icon;
		
	}

}
