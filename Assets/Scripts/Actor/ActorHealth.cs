using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthChangedEvent : UnityEvent<float, float> { }

[System.Serializable]
public class HitReceivedEvent : UnityEvent<Vector3, float> { }

public class ActorHealth : MonoBehaviour
{
    [SerializeField] private int m_MaxHealth;
    private int m_CurrentHealth;

    public UnityEvent OnDeath;
    [SerializeField] private HealthChangedEvent OnHealthChange;
    [SerializeField] private HitReceivedEvent OnHitReceived;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        OnHealthChange.Invoke(m_CurrentHealth, m_MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InstantDeath()
    {
        m_CurrentHealth = 0;
        OnHealthChange.Invoke(m_CurrentHealth, m_MaxHealth);
        OnDeath.Invoke();
    }

    public void TakeDamage(int damage, Vector3 origin, float knockbackDistance)
    {
        m_CurrentHealth -= damage;
        DamagePopupController.Instance.ShowDamage(this.transform.position, damage, Color.red);
        OnHealthChange.Invoke(m_CurrentHealth, m_MaxHealth);
        OnHitReceived.Invoke(origin, knockbackDistance);

        if (m_CurrentHealth <= 0) {
            OnDeath.Invoke();
        }
    }
}