﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorHealth : MonoBehaviour
{
    [SerializeField]private int m_MaxHealth;
    private int m_CurrentHealth;

    [SerializeField]private UnityEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
            m_CurrentHealth = m_MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ( m_CurrentHealth <= 0 ) {
            OnDeath.Invoke();
        }
    }

    public void TakeDamage( int damage )
    {
        m_CurrentHealth -= damage;
    }
}
