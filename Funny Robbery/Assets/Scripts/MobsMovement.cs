using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobsMovement : MonoBehaviour
{
    [SerializeField] 
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Transform[] _waypoints;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private float _waitTime = 10f; 
    Animator m_Animator;
    int m_CurrentWaypointIndex;
    bool isWaiting = false;

    void Start()
    {
        _navMeshAgent.SetDestination(_waypoints[0].position);
        m_Animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    void Update()
    {
        if(!isWaiting && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        isWaiting = true;
        _navMeshAgent.isStopped = true;
        m_Animator.SetBool("isWaiting", isWaiting);
        _audioSource.Stop();

        yield return new WaitForSeconds(_waitTime);

        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _waypoints.Length;
        _navMeshAgent.SetDestination(_waypoints[m_CurrentWaypointIndex].position);

        isWaiting = false;
        _navMeshAgent.isStopped = false;
        m_Animator.SetBool("isWaiting", isWaiting);
        _audioSource.Play();
    }
}
