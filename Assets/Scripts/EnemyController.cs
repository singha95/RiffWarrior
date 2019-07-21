using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public float runSpeed;
	public int health;
	public bool canMove;
    public bool canWander;
	public string enemyName;
    public float DetectRange;
	public Difficulty difficulty;
	public enum Difficulty{Easy, Medium, Hard};

    private GameObject guitar; 
	private SkinnedMeshRenderer skinnedMeshRend;
	private Color damageColor = new Color(255, 0, 0, 0.5f);
	private Color normalColor;
	private Animator animator;
    //private Animator PopupAni;
	private Slider healthBar;
	private int maxHealth;
    private GameObject player;
    private EnemyDetection enemyDetection;
    private NavMeshAgent nav;
    private NavMeshHit hit;
	private Color defaultColour;
	private Canvas healthCanvas;
    private bool guitarMoved = false;
    //private GameObject PopUpParent;
    //private bool SeesPlayer;



    private void Awake() {
		animator = GetComponent<Animator>();
        //PopupAni = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Animator>();
		skinnedMeshRend = GetComponentInChildren<SkinnedMeshRenderer>();
		defaultColour = skinnedMeshRend.material.color;
		healthCanvas = GetComponentInChildren<Canvas>();
	}
    

    private void Start() {
		player = GameObject.FindWithTag("Player");
        DetectRange = 70.0f;
        enemyDetection = player.GetComponent<EnemyDetection>();
		healthBar = gameObject.transform.Find("EnemyHealth/HealthBar").gameObject.GetComponent<Slider>();
        if (gameObject.transform.Find("guitar"))
        {
            guitar = gameObject.transform.Find("guitar").gameObject;
        }
		maxHealth = health;
		healthBar.maxValue = maxHealth;
		healthBar.minValue = 0;
		healthBar.value = maxHealth;
		gameObject.transform.Find("EnemyHealth/EnemyName").gameObject.GetComponent<Text>().text = enemyName;
		gameObject.transform.Find("EnemyHealth").gameObject.SetActive(false);
        nav = transform.parent.GetComponent<NavMeshAgent>();
        //PopUpParent = GameObject.FindGameObjectWithTag("PopUpParent");
        canMove = true;
        canWander = true;
        //SeesPlayer = false;
		
		// Warp position to nav mesh.
        if (nav.enabled && !nav.isOnNavMesh) {
            var position = transform.position;
            NavMesh.SamplePosition(position, out hit, 10.0f,1);
            position = hit.position;
            nav.Warp(position);
        }
    }

	
    private void FixedUpdate() {
        float distance = (transform.position - player.transform.position).magnitude;
        if (canMove == true && enemyDetection.currentTarget == null) {
			gameObject.transform.Find("EnemyHealth").gameObject.SetActive(false);
            nav.enabled = true;
            if (distance <= DetectRange) {
                //SeesPlayer = true;
           
                //Vector2 CanvasPos = transform.position;
                //PopUpParent.transform.position = CanvasPos;
                //PopupAni.SetBool("InRange", true);
                canWander = false;
                ChasePlayer(player.transform);

            } else {
                //SeesPlayer = false;
                //print(distance);
                //PopupAni.SetBool("InRange", false);
                canWander = true;
            }
        } else {
			if (enemyDetection.currentTarget != null) {
				enemyDetection.currentTarget.transform.Find("EnemyHealth").gameObject.SetActive(true);
                if (this.guitar != null && !this.guitarMoved)
                {
                    this.guitarMoved = true;
                    Debug.Log("SFSD");
                    guitar.transform.Translate(new Vector3(0, 0, 3));
                }
                //PopupAni.SetBool("InRange", false);
            }
            
			canWander = false;
            nav.enabled = false;
        }
	}
	
	
    private void ChasePlayer(Transform playerTransform) {
        // Go to player's position
        nav.SetDestination(playerTransform.position);
    }
	

	public IEnumerator Death() {
		gameObject.tag = "Untagged";
		healthCanvas.gameObject.SetActive(false);
		animator.SetBool("isDead", true);
		yield return new WaitForSeconds(3.0f);
		Destroy(gameObject.transform.parent.gameObject);
	}


	public IEnumerator TakeDamage() {
		animator.SetTrigger("takeDamage");
		yield return new WaitForSeconds(0.1f);
		skinnedMeshRend.material.SetColor("_Color", damageColor); 
		skinnedMeshRend.material.SetColor("_Color", defaultColour);
		yield return new WaitForSeconds(0.1f);
		skinnedMeshRend.material.SetColor("_Color", damageColor);
		yield return new WaitForSeconds(0.1f);
		skinnedMeshRend.material.SetColor("_Color", defaultColour);
	}
	
	
	public IEnumerator Attack() {
		animator.SetTrigger("attack");
		yield return new WaitForSeconds(0.1f);
	}

	
	public void InitiateCombat() {
		animator.SetBool("isInCombat", true);
	}
	
	
	public int GetHealth() {
		return health;
	}
	
	
	public void DecrementHealth() {
		health--;
		healthBar.value = Mathf.Max(0.0f, health);
	}
	
	
	public void ResetMaterialColour() {
		skinnedMeshRend.material.SetColor("_Color", defaultColour);
	}
	
	
	public Difficulty GetDifficulty() {
		return difficulty;
	}

}

