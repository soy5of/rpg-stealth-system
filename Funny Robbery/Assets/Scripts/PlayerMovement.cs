using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float _turnSpeed = 5f;
    [SerializeField]
    private AudioSource _audioSource;
    private bool isCrouched;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    Vector3 _playerPosition;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _playerPosition = transform.position;
        m_Rigidbody.MovePosition(_playerPosition);
        m_Rotation = transform.rotation;
        m_Rigidbody.MoveRotation(m_Rotation);
        isCrouched = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        bool stateWalking = !isWalking;

        if (isWalking != stateWalking)
        {
            stateWalking = isWalking;
            m_Animator.SetBool("IsWalking", isWalking);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _audioSource.Play();
            isCrouched = !isCrouched;
            m_Animator.SetBool("IsCrouched", isCrouched);
        }

        if (m_Movement != Vector3.zero)
        {
            if (horizontal > 0)
            {
                m_Rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 90f, 0f);
                m_Rotation = Quaternion.Slerp(transform.localRotation, m_Rotation, _turnSpeed * Time.deltaTime);
            }
            else if (horizontal < 0)
            {
                m_Rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y - 90f, 0f);
                m_Rotation = Quaternion.Slerp(transform.localRotation, m_Rotation, _turnSpeed * Time.deltaTime);
            }
            else if (vertical < 0)
            {
                m_Rotation = transform.rotation;
            }
            else if (vertical > 0)
            {
                m_Rotation = transform.rotation;
            }
            _playerPosition = transform.position + m_Rotation * Vector3.forward * m_Animator.deltaPosition.magnitude * Mathf.Sign(vertical);
        }
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(_playerPosition);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}

