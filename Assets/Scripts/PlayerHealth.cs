using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
    public float startingHealth;
    public float currentHealth;
    public float flashSpeed;
	public float flashRecovery;
	public float maxBrightness;
	public float comboHealthRecovery;

    private bool damaged;
    private Slider healthSlider;
    private Image damageImage;
	private Image recoveryImage;
	private GameObject player;
	private Animator playerAnimator;
	private PlayerController playerController;
	
	
	private void Awake()
	{
        currentHealth = startingHealth;
	}
	
	
    private void Start()
    {
        healthSlider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
		damageImage = GameObject.FindGameObjectWithTag("DamageImage").GetComponent<Image>();
		recoveryImage = GameObject.FindWithTag("RecoveryImage").GetComponent<Image>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerAnimator = player.GetComponent<Animator>();
		playerController = player.GetComponent<PlayerController>();
        healthSlider.value = startingHealth;
    }
	

    private void Update()
    {
        if (damaged)
		{
			Color newColour = damageImage.color;
			newColour.a = maxBrightness;
            damageImage.color = newColour;
		}
        else
		{
            float alphaColour = Mathf.Lerp(damageImage.color.a, Color.clear.a, flashSpeed * Time.deltaTime);
			Color newColour = damageImage.color;
			newColour.a = alphaColour;
			damageImage.color = newColour;
		}
        damaged = false;
    }

	
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
		playerAnimator.SetTrigger("takeDamage");
		
		if(currentHealth <= 0) {
			StartCoroutine(PauseAfterDeath());
		}
    }
	
	
	public void AddHealthFromPotion(GameObject potion) {
		Destroy(potion);
		
		// Deal with health
		HealthPotion healthPotion = potion.GetComponent<HealthPotion>();
		currentHealth += healthPotion.GetHealthRecovery();
		currentHealth = Mathf.Min(startingHealth, currentHealth);
		healthSlider.value = currentHealth;
		
		StartCoroutine(FlashGreen());
	}
	
	
	public void AddHealthFromCombo() {
		// Deal with health.
		currentHealth += comboHealthRecovery;
		currentHealth = Mathf.Min(startingHealth, currentHealth);
		healthSlider.value = currentHealth;
		
		StartCoroutine(FlashGreen());
	}
	
	
	private IEnumerator FlashGreen() {
		// Activate green indicator.
		Color newColour = recoveryImage.color;
		newColour.a = maxBrightness;
		recoveryImage.color = newColour;
		
		// Fade green indicator away.
		while (recoveryImage.color.a > 0.0f) {
			float alphaColour = recoveryImage.color.a - flashRecovery;
			newColour = recoveryImage.color;
			newColour.a = alphaColour;
			recoveryImage.color = newColour;
			yield return null;
		}
	}
	
	
	private IEnumerator PauseAfterDeath() {
		playerController.DisableInput();
		yield return new WaitForSecondsRealtime(4.0f);
		GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
		gameManager.isGameFinished = true;
		playerController.EnableInput();
	}
	
}
