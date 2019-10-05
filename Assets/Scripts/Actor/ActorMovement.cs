using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ActorMovement : MonoBehaviour
{
    private CharacterController m_CharacterController;

    public float Acceleration;
    public float Break;

    public float MaxSpeed = 10;

    private float m_CurrentSpeed;
    private Quaternion m_Heading;

    private bool m_IsStunned = false;

    void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        m_Heading = transform.rotation;
    }

    public bool CanMove()
    {
        return m_IsStunned == false;
    }

    public void Move(Vector3 direction, bool lookAt)
    {
        if (CanMove() == false)
            return;

        if (direction.sqrMagnitude <= 0.1) {
            // We don't have any input, start breaking
            m_CurrentSpeed -= Break * Time.deltaTime;
        } else {
            // We are moving, start accelerating
            m_CurrentSpeed += direction.magnitude * Acceleration * Time.deltaTime;

            if (lookAt) {
                m_Heading = Quaternion.LookRotation(direction);
                transform.rotation = m_Heading;
            }
        }

        // Can't go beyond max speed or below 0.
        m_CurrentSpeed = Mathf.Clamp(m_CurrentSpeed, 0f, MaxSpeed);

        // Running
        var movement = m_Heading * Vector3.forward * m_CurrentSpeed * Time.deltaTime;

        // Gravity
        movement.y = -9.81f * Time.deltaTime;

        m_CharacterController.Move(movement);
    }

    public void Stun(float seconds)
    {
        StartCoroutine(StunForDuration(seconds));
    }

    private IEnumerator StunForDuration(float seconds)
    {
        m_IsStunned = true;
        yield return new WaitForSeconds(seconds);
        m_IsStunned = false;
    }
}
