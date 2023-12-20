using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon {
    public enum Type{None, Hammer, Shotgun, Pistol, Rifle};

    public abstract int GetDamage();

    public abstract int GetAmmoPrice();

    public virtual int GetRangeRadius() {
        return 100;
    }    
    
    public virtual bool IsShooting() {
        return Input.GetMouseButtonDown(0);
    }

    public virtual Transform GetBulletSource(Transform models) {
        return null;
    }

    public virtual bool HasBullets() {
        return true;
    }

    public static Weapon FromType(Type weaponType) {
        switch (weaponType  ) 
        {
            case Type.None:
                return new _NoneWeapon();
            case Type.Hammer:
                return new _Hammer();
            case Type.Shotgun:
                return new _Shotgun();
            case Type.Pistol:
                return new _Pistol();
            case Type.Rifle:
                return new _Rifle();
            default:
                Debug.Assert(false, "Unexpected weapon type");
                return new _NoneWeapon();
        }
    }
}

public class _Hammer : Weapon
{
    public override int GetDamage() {
        return 100;
    }

    public override int GetAmmoPrice() {
        return 0;
    }

    public override int GetRangeRadius() {
        return 2;
    }
    
    public override bool HasBullets() {
        return false;
    }
}

public class _Shotgun : Weapon
{
    public override int GetDamage() {
        return 50;
    }

    public override int GetAmmoPrice() {
        return 5;
    }

    public override int GetRangeRadius() {
        return 10;
    }

    public override Transform GetBulletSource(Transform models) {
        return models.Find("ShotgunModel").Find("PartA").Find("BulletSource");
    }

    // TODO: implement?
    public static int getScaler(GameObject target)
    {
        return 1;
    }
}

public class _Pistol : Weapon
{
    public override int GetDamage() {
        return 25;
    }

    public override int GetAmmoPrice() {
        return 2;
    }

    public override Transform GetBulletSource(Transform models) {
        return models.Find("PistolModel").Find("BulletSource");
    }
}

public class _Rifle : Weapon
{
    public override int GetDamage() {
        return 10;
    }

    public override int GetAmmoPrice() {
        return 1;
    }

    public override bool IsShooting()
    {
        return Input.GetMouseButton(0);
    }
}

public class _NoneWeapon : Weapon
{
    public override int GetDamage() {
        Debug.Assert(false);
        return 0;
    }

    public override int GetAmmoPrice() {
        Debug.Assert(false);
        return 0;
    }

    public override bool IsShooting()
    {
        return false;
    }
}

