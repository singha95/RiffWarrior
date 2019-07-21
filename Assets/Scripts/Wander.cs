using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
public class Wander : MonoBehaviour
{
    public float wanderRange;
	
    private EnemyController enemyController;
    private NavMeshAgent nav;
    private float checkRate;
    private float nextCheck;
    private Transform myTransform;
    private NavMeshHit navHit;
    private Vector3 wanderTarget;
	private Animator animator;
	private Vector3 currentPosition;
	
	
	private void Awake() {
		animator = GetComponent<Animator>();
		currentPosition = transform.position;
	}
	
	
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
		nav = transform.parent.GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.3f, 0.4f);
        myTransform = transform;
    }

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            WanderOrNot();
        }
		AnimateWalking();
    }
    void WanderOrNot()
    {
        if (enemyController.canWander == true && enemyController.canMove == true)
        {
            if (RandomWanderTarget(myTransform.position, wanderRange, out wanderTarget))
            {
                nav.SetDestination(wanderTarget);
            }
        }
    }
    bool RandomWanderTarget(Vector3 centre, float range, out Vector3 result)
    {
        Vector3 randomPoint = centre + Random.insideUnitSphere * wanderRange;
        if (NavMesh.SamplePosition(randomPoint, out navHit, 1.0f, NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = centre;
            return false;
        }
    }
	
	
	private void AnimateWalking() {
		float speed = Vector3.Distance(transform.position, currentPosition) / Time.deltaTime;
		animator.SetFloat("forward", speed);
		currentPosition = transform.position;
	}
}