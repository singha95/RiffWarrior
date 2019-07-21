using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPortal : MonoBehaviour
{
	
	public Color pulseColourStart;
	public Color pulseColourEnd;
	public float pulseDuration;
	public GameObject gameManager;
	
	private new Light light;
	private GameManager gameManagerScript;
	
	
	private void Awake()
	{
		light = transform.GetChild(0).GetComponent<Light>();
		gameManagerScript = gameManager.GetComponent<GameManager>();
	}
	
	
    void OnTriggerEnter(Collider other)
    {
        gameManagerScript.EndGame();
    }
	
	
	private void Update()
	{
		Pulse();
	}
	
	
	private void Pulse() 
	{
		light.color = Color.Lerp(
			pulseColourStart, 
			pulseColourEnd,
			Mathf.PingPong(Time.time, pulseDuration));
	}
	
}
