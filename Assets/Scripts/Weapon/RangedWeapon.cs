using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/Ranged weapon")]
public class RangedWeapon : WeaponAsset
{
    public GameObject ProjectilePrefab;

    public override void Attack(GameObject actor)
    {
        var animationController = actor.GetComponent<ActorAnimationController>();
        animationController?.PlayAttackAnimation();
    }

    public override void OnActivePhase(GameObject hitArea)
    {
        var position = hitArea.transform.position;
        var rotation = hitArea.transform.rotation;

        var projectile = Instantiate(ProjectilePrefab, position, rotation);

        var projectileDamage = projectile.GetComponent<ProjectileDamage>();
        projectileDamage.DamageMin = DamageMin;
        projectileDamage.DamageMax = DamageMax;
        projectileDamage.HitKnockback = HitKnockback;
    }
}