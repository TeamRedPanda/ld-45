using UnityEngine;
using Random = UnityEngine.Random;

class ActorWeapon : MonoBehaviour
{
    [SerializeField] private WeaponHitArea m_WeaponHitArea = default;
    [SerializeField] private Transform m_WeaponEquipParent = default;

    [SerializeField] private WeaponAsset m_PreEquippedWeapon = default;

    private WeaponAsset m_Weapon = default;

    void Awake()
    {
        if (m_PreEquippedWeapon)
            EquipWeapon(m_PreEquippedWeapon);
    }

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

        // Instantiate if this has a weapon model.
        if (m_Weapon.WeaponPrefab)
            Instantiate(m_Weapon.WeaponPrefab, Vector3.zero, Quaternion.identity, m_WeaponEquipParent);

        // Instantiate if this has a weapon hit area (ranged weapons don't)
        if (m_Weapon.HitAreaPrefab)
            m_WeaponHitArea.SetHitArea(Instantiate(m_Weapon.HitAreaPrefab, Vector3.zero, Quaternion.identity));
    }

    public void ApplyDamage(ActorHealth actor)
    {
        int damage = Random.Range(m_Weapon.DamageMin, m_Weapon.DamageMax);
        actor.TakeDamage(damage);
    }
}
