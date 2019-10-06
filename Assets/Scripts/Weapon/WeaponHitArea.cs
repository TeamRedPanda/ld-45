﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WeaponHitEvent : UnityEvent<ActorHealth> { }

class WeaponHitArea : MonoBehaviour
{
    public WeaponHitEvent OnHitEvent;

    private GameObject m_HitArea;

    private bool m_IsActive = false;

    public void SetHitArea(GameObject area)
    {
        if (m_HitArea != null)
            Destroy(m_HitArea);

        m_HitArea = area;
        area.transform.SetParent(this.gameObject.transform);
    }

    public void EnableHitArea()
    {
        m_IsActive = true;
    }

    public void DisableHitArea()
    {
        m_IsActive = false;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        var actorHealth = other.gameObject.GetComponentInParent<ActorHealth>();
        if (actorHealth && m_IsActive)
            OnHitEvent.Invoke(actorHealth);
    }
}

