using System;
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

    public float Speed { get; private set; }
    private Quaternion m_Heading;

    private bool m_IsStunned = false;
    private bool m_AnimationLocked = false;

    public float KnockbackTime = 0.1f;

    void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        m_Heading = transform.rotation;
    }

    void Update()
    {
        // Gravity
        var movement = new Vector3();
        movement.y = -9.81f * Time.deltaTime;

        m_CharacterController.Move(movement);
    }

    public void LockMovement()
    {
        m_AnimationLocked = true;
    }

    public void UnlockMovement()
    {
        m_AnimationLocked = false;
    }

    public bool CanMove()
    {
        return m_IsStunned == false && m_AnimationLocked == false;
    }

    public void LookAt(Vector3 direction)
    {
        m_Heading = Quaternion.LookRotation(direction);
        transform.rotation = m_Heading;
    }

    public void Move(Vector3 direction, bool lookAt)
    {
        if (CanMove() == false)
            return;

        if (direction.sqrMagnitude <= 0.1) {
            // We don't have any input, start breaking
            Speed -= Break * Time.deltaTime;
        } else {
            // We are moving, start accelerating
            Speed += direction.magnitude * Acceleration * Time.deltaTime;

            if (lookAt) {
                m_Heading = Quaternion.LookRotation(direction);
                transform.rotation = m_Heading;
            }
        }

        // Can't go beyond max speed or below 0.
        Speed = Mathf.Clamp(Speed, 0f, MaxSpeed);

        // Running
        var movement = m_Heading * Vector3.forward * Speed * Time.deltaTime;

        m_CharacterController.Move(movement);
    }

    public void Knockback(Vector3 origin, float distance)
    {
        var direction = this.gameObject.transform.position - origin;
        StartCoroutine(KnockbackDistance(direction.normalized, distance, KnockbackTime));
    }

    private IEnumerator KnockbackDistance(Vector3 direction, float totalDistance, float knockbackTime)
    {
        float travelledDistance = 0f;
        float speed = totalDistance / knockbackTime;

        while (travelledDistance < totalDistance) {
            float distanceToTravel = speed * Time.deltaTime;

            // Don't overshoot
            if (travelledDistance + distanceToTravel > totalDistance)
                distanceToTravel = totalDistance - travelledDistance;

            travelledDistance += distanceToTravel;
            m_CharacterController.Move(direction * distanceToTravel);
            yield return 0;
        }
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
