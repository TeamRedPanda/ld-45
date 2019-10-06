using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ProjectileHitEvent : UnityEvent<ActorHealth> { }

public class ProjectileCollision : MonoBehaviour
{
    public ProjectileHitEvent OnHitEvent;

    void OnTriggerStay(Collider other)
    {
        var actorHealth = other.gameObject.GetComponentInParent<ActorHealth>();
        if (actorHealth) {
            OnHitEvent.Invoke(actorHealth);
        } else {
            Debug.Log($"Collided with wall? {other.gameObject.name}");
        }
    }
}