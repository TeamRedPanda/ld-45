using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

class ProjectileDamage : MonoBehaviour
{
    public int DamageMin;
    public int DamageMax;

    public float HitKnockback;

    public void ApplyDamage(ActorHealth actor)
    {
        int damage = Random.Range(DamageMin, DamageMax);
        actor.TakeDamage(damage, this.gameObject.transform.position, HitKnockback);
        Destroy(this.gameObject);
    }
}
