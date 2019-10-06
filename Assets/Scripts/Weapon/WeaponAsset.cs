using UnityEngine;

public abstract class WeaponAsset : ScriptableObject
{
    public int DamageMin;
    public int DamageMax;

    public float HitKnockback;

    public GameObject WeaponPrefab;
    public GameObject HitAreaPrefab;

    public abstract void Attack(GameObject actor);

    public virtual void OnActivePhase(GameObject hitArea) { }
}
