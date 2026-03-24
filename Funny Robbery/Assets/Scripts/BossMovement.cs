using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    [SerializeField] 
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Transform[] _waypoints;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private float _waitTime = 10f; 
    [SerializeField]
    private EnemyDetectionSlider _vievOfMob;
    Animator m_Animator;
    GameObject player;
    int m_CurrentWaypointIndex;
    bool isWaiting = false;

    void Start()
    {
        SetRandomDestination();
        m_Animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(_vievOfMob.inZone == false && !isWaiting && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            StartCoroutine(Wait());
        }

        if (_vievOfMob.inZone == true)
        {
            StopCoroutine(Wait());
            _navMeshAgent.SetDestination(player.transform.position);
        }
    }

    private IEnumerator Wait()
    {
        isWaiting = true;
        _navMeshAgent.isStopped = true;
        m_Animator.SetBool("isWaiting", isWaiting);
        _audioSource.Stop();

        yield return new WaitForSeconds(_waitTime);

        SetRandomDestination();

        isWaiting = false;
        _navMeshAgent.isStopped = false;
        m_Animator.SetBool("isWaiting", isWaiting);
        _audioSource.Play();
    }

    private void SetRandomDestination()
    {
        m_CurrentWaypointIndex = Random.Range(0, _waypoints.Length);
        _navMeshAgent.SetDestination(_waypoints[m_CurrentWaypointIndex].position);
    }
}