using UnityEngine;
using Random = UnityEngine.Random;

class ActorWeapon : MonoBehaviour
{
    [SerializeField] private WeaponHitArea m_WeaponHitArea = default;
    [SerializeField] private Transform m_WeaponEquipParent = default;

    private WeaponAsset m_Weapon = default;

    public void Attack()
    {
        m_Weapon.Attack(this.gameObject);
    }

    public void EquipWeapon(WeaponAsset weapon)
    {
        // Remove old weapon
        foreach(Transform child in m_WeaponEquipParent.transform) {
            Destroy(child.gameObject);
        }

        m_Weapon = weapon;

        Instantiate(m_Weapon.WeaponPrefab, m_WeaponEquipParent);
        m_WeaponHitArea.SetHitArea(Instantiate(m_Weapon.HitAreaPrefab));
    }

    public void ApplyDamage(ActorHealth actor)
    {
        int damage = Random.Range(m_Weapon.DamageMin, m_Weapon.DamageMax);
        actor.TakeDamage(damage);
    }
}
