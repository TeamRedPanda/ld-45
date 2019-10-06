using UnityEngine;

[CreateAssetMenu(menuName = "Gladiator/Ranged weapon")]
public class RangedWeapon : WeaponAsset
{
    public GameObject ProjectilePrefab;

    public override void Attack(GameObject actor)
    {
        throw new System.NotImplementedException();
    }
}