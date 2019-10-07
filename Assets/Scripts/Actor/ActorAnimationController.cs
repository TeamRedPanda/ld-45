using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ActorAnimationController : MonoBehaviour
{
    private Animator m_Animator;

    void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void PlayAttackAnimation()
    {
        m_Animator.SetTrigger("Attack");
    }
}

