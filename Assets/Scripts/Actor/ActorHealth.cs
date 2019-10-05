using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthChangedEvent : UnityEvent<float , float> { }

public class ActorHealth : MonoBehaviour
{
    [SerializeField]private int m_MaxHealth;
    private int m_CurrentHealth;

    [SerializeField]private UnityEvent OnDeath;
    [SerializeField]private HealthChangedEvent OnHealthChange;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        OnHealthChange.Invoke( m_CurrentHealth , m_MaxHealth );
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage( int damage )
    {
        m_CurrentHealth -= damage;
        OnHealthChange.Invoke( m_CurrentHealth , m_MaxHealth );

        if ( m_CurrentHealth <= 0 ) {
            OnDeath.Invoke();
        }
    }
}