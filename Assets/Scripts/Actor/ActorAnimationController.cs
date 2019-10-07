using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
class ActorAnimationController : MonoBehaviour
{
    private Animator m_Animator;
    private ActorMovement m_ActorMovement;

    void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
        m_ActorMovement = GetComponent<ActorMovement>();
    }

    void Update()
    {
        m_Animator.SetFloat("Speed", m_ActorMovement.Speed);
    }

    public void PlayAttackAnimation(string attackAnimationTrigger)
    {
        m_Animator.SetTrigger(attackAnimationTrigger);
    }
}

