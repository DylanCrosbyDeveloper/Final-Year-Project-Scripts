using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileAI : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent navAgent;
    public Transform playerTransform;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public Transform player;
    [Header("Layers")]
    public LayerMask GroundLayer;
    public LayerMask playerLayerMask;

    [Header("Patrol Settings")]
    public float patrolRadius = 10f;
    public Vector3 currentPatrolPoint;
    public bool hasPatrolPoint;

    [Header("Combat Settings")]
    public float attackCooldown = 1f;
    public bool isOnAttackCooldown;
    public float forwardShotForce = 10f;
    public float verticalShotForce = 5f;

    [Header("Detection Ranges")]
    public float visionRange = 20f;
    public float engagementRange = 10f;

    public bool isPlayerVisible;
    public bool isPlayerInRange;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, engagementRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (transform.position, visionRange);

    }

    private void DetectPlayer()
    {
        isPlayerVisible = Physics.CheckSphere(transform.position, visionRange, playerLayerMask);
        isPlayerInRange = Physics.CheckSphere(transform.position, engagementRange, playerLayerMask);
    }

    private void FireProjectile()
    {
        if (projectilePrefab == null || firePoint == null) return;
        {
            Rigidbody projectileRb = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.forward * forwardShotForce, ForceMode.Impulse);
            projectileRb.AddForce(transform.up * verticalShotForce, ForceMode.Impulse);

            Destroy(projectileRb.gameObject, 3f);
        }
    }

    private void FindPatrolPoint()
    {
        float randomX = Random.Range(-patrolRadius, patrolRadius);
        float randomZ = Random.Range(-patrolRadius, patrolRadius);

        Vector3 potentialPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(potentialPoint, -transform.up, 2f, GroundLayer))
        {
            currentPatrolPoint = potentialPoint;
            hasPatrolPoint = true;
        }
    }

    private IEnumerator AttackCooldownRoutine()
    {
        isOnAttackCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isOnAttackCooldown = false;
    }

    private void PerformPatrol()
    {
        if (!hasPatrolPoint)
            FindPatrolPoint();

        if(hasPatrolPoint)
            navAgent.SetDestination(currentPatrolPoint);

        if(Vector3.Distance(transform.position, currentPatrolPoint) < 1f)
            hasPatrolPoint = false;
        
    }

    private void PerformChase()
    {
        if(playerTransform != null)
        {
            navAgent.SetDestination(playerTransform.GetComponent<Transform>().position);
        }

       
    }

    private void PerformAttack()
    {
        navAgent.SetDestination(playerTransform.position);

        if (playerTransform != null) 
        {
            transform.LookAt(playerTransform.GetComponent<Transform>());

        }

        if (!isOnAttackCooldown)
        {
            FireProjectile();
            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private void UpdateBehaviourState()
    {
        if(!isPlayerVisible && !isPlayerInRange)
        {
            PerformPatrol();
        }
        else if(isPlayerVisible && !isPlayerInRange)
        {
            PerformChase();
        }
        else if(isPlayerVisible && isPlayerInRange)
        {
            PerformAttack();
        }
    }

    private void Awake()
    {
        if (playerTransform == null)
        {
            GameObject playerObj = GameObject.Find("Player");
            if (playerObj != null)
            {
                player = playerTransform.GetComponent<Transform>();
                player = playerObj.transform;
            }
        }

        if(navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        DetectPlayer();
        UpdateBehaviourState();
    }

    private void Start()
    {
        
    }
}
