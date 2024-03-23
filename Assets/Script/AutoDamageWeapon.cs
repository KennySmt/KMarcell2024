using UnityEngine;

public class AutoDamageWeapon : PeriodicWeapon
{
    [SerializeField] float damage = 10;
    protected override void Fire()
    {
        Target.Damage(damage);
    }
}
