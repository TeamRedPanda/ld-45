using UnityEngine;

public abstract class WeaponAsset : ScriptableObject
{
    public int DamageMin;
    public int DamageMax;

    public float HitKnockback;

    public GameObject WeaponPrefab;
    public GameObject HitAreaPrefab;

    public string AttackAnimationTrigger;

    public virtual void Attack(GameObject actor)
    {
        var animationController = actor.GetComponent<ActorAnimationController>();
        animationController?.PlayAttackAnimation(AttackAnimationTrigger);
    }

    public virtual void OnActivePhase(GameObject hitArea) { }
}
