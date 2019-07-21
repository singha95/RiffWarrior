using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour {
	
	public Image icon;
	
	private Item item;

    private new string name;

    private string description;
	
	private string stats;

	private bool selected = false;

	private Color highlightedColor = new Color (0.0f, 0.25f, 0.5f);
	private Color normalColor = new Color(0x0, 0x0, 0x0, 0xBF);
	
	private Image slotImage;
	
	
	private void Awake() {
		slotImage = gameObject.GetComponent<Image>();
	}

	private void Update() {
		if (selected) {
			Highlight ();
		} else {
			Unselect();
		}
	}

    public void AddItemToSlot(GameObject newItem) {
		
		item = newItem.GetComponent<Item>();
        name = item.name;
        description = item.description;
		icon.sprite = item.GetIcon();
		
		if (item.healthRecovery != 0) {
			stats = "Health recovery: " + item.healthRecovery;
		} else {
			stats = "Damage reduction: " + item.damageReduction;
		}
		
		//icon.color = new Color32(255, 255, 255, 255);
		icon.color = new Color32(255, 255, 255, 255);
        icon.enabled = true;
		
	}
	
	public string GetName()
	{
		return name;
	}
	
	public string GetDescription()
    {
        return description;
    }
	
	public string GetStats() 
	{
		return stats;
	}

    public bool ContainsItem()
    {
        return item == null ? false : true;
    }

	
	public void ClearSlot() {
		
		item = null;
		
		icon.sprite = null;
		
		icon.enabled = false;
		
		icon.color = new Color32(0, 0, 0, 255);
		
	}

    public void Unselect()
    {
		this.selected = false;
        //icon.color = new Color32(255, 255, 255, 50);
		//icon.color = new Color(0x0, 0x0, 0x0, 0xBF);
		if (slotImage != null) {
			slotImage.color = normalColor;
		}
    }

    public void Highlight()
    {
		slotImage.color = highlightedColor;
    }
    public void Select()
    {
		this.selected = true;
    }
}
