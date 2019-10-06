using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/Melee weapon")]
public class MeleeWeapon : WeaponAsset
{
    public override void Attack(GameObject actor)
    {
        var animationController = actor.GetComponent<ActorAnimationController>();
        animationController?.PlayAttackAnimation();
    }
}
