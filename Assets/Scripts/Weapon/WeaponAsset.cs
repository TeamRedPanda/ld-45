using UnityEngine;

public abstract class WeaponAsset : ScriptableObject
{
    public int DamageMin;
    public int DamageMax;

    public float HitLock;
    public float HitKnockBack;

    public GameObject WeaponPrefab;
    public GameObject HitAreaPrefab;

    public abstract void Attack(GameObject actor);
}

[CreateAssetMenu(menuName = "Gladiator/Melee weapon")]
public class MeleeWeapon : WeaponAsset
{
    public override void Attack(GameObject actor)
    {
        throw new System.NotImplementedException();
    }
}

[CreateAssetMenu(menuName = "Gladiator/Ranged weapon")]
public class RangedWeapon : WeaponAsset
{
    public GameObject ProjectilePrefab;

    public override void Attack(GameObject actor)
    {
        throw new System.NotImplementedException();
    }
}