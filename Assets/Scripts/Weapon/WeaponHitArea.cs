using System;
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

    public GameObject HitArea { get; private set; }

    private bool m_IsActive = false;

    private List<ActorHealth> m_ActorsHit = new List<ActorHealth>();

    public void SetHitArea(GameObject area)
    {
        if (HitArea != null)
            Destroy(HitArea);

        HitArea = area;
        area.transform.SetParent(this.gameObject.transform, false);
    }

    public void EnableHitArea()
    {
        m_IsActive = true;

        // Reset the actors hit here, we're dealing a new blow.
        m_ActorsHit.Clear();
    }

    public void DisableHitArea()
    {
        m_IsActive = false;
    }

    void OnTriggerStay(Collider other)
    {
        var actorHealth = other.gameObject.GetComponentInParent<ActorHealth>();
        var alreadyHit = m_ActorsHit.Contains(actorHealth);
        if (actorHealth && m_IsActive && alreadyHit == false) {
            OnHitEvent.Invoke(actorHealth);
            m_ActorsHit.Add(actorHealth);
        }
    }
}

