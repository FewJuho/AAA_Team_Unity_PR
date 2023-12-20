using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLogic : MonoBehaviour
{
    private static float damageMultiplierStartTime;
    private static float jatpackStartTime;
    private static float shieldStartTime;

    public enum BonusType
    {
        Heals,
        Shields,
        Jetpacks,
        DamageUps
    }

    public static void GainBonus(BonusType bonusType, int amount)
    {
        switch (bonusType)
        {
            case BonusType.Heals:
                DataHolder._healsCount += amount;
                break;
            case BonusType.Shields:
                DataHolder._shieldsCount += amount;
                break;
            case BonusType.Jetpacks:
                DataHolder._jetpacksCount += amount;
                break;
            case BonusType.DamageUps:
                DataHolder._damageUpsCount += amount;
                break;
        }
    }

    public static bool ConsumeBonus(BonusType bonusType, int amount)
    {
        switch (bonusType)
        {
            case BonusType.Heals:
                int hpToAdd = DataHolder.maxHP - DataHolder.currentHP < 300 ? DataHolder.maxHP - DataHolder.currentHP : 300;
                if (DataHolder._healsCount >= amount && hpToAdd > 0)
                {
                    DataHolder.currentHP += (hpToAdd * amount);
                    DataHolder._healsCount -= amount;
                    Debug.Log("HP = " + DataHolder.currentHP);

                }
                break;
            case BonusType.Shields:
                if (DataHolder._shieldsCount >= amount)
                {
                    DataHolder.currentShield += (250 * amount);
                    DataHolder._shieldsCount -= amount;
                    shieldStartTime = Time.time;
                    DataHolder.shieldActivated = true;
                }
                break;
            case BonusType.Jetpacks:
                if (DataHolder._jetpacksCount >= amount)
                {
                    jatpackStartTime = Time.time;
                    DataHolder._jetpacksCount -= amount;
                    DataHolder.jatpackActivated = true;
                }
                break;
            case BonusType.DamageUps:
                if (DataHolder._damageUpsCount >= amount)
                {
                    DataHolder.damageMultiplier = 2.0f;
                    damageMultiplierStartTime = Time.time;
                    DataHolder._damageUpsCount -= amount;
                }
                break;
        }

        return true;
    }

    public static void UpdateDamageMultiplier()
    {
        if (DataHolder.damageMultiplier == 2.0f)
        {
            DataHolder.damageMultiplierTimeLeft = DataHolder.damageMultiplierDuration - (Time.time - damageMultiplierStartTime) > 0 ? DataHolder.damageMultiplierDuration - (Time.time - damageMultiplierStartTime) : 0f;
            if (DataHolder.damageMultiplierTimeLeft == 0f)
            {
                DataHolder.damageMultiplier = 1.0f;
            }
        }
    }

    public static void UpdateJatpack()
    {
        if (DataHolder.jatpackActivated)
        {
            DataHolder.jatpackTimeLeft = DataHolder.jatpackDuration - (Time.time - jatpackStartTime) > 0 ? DataHolder.jatpackDuration - (Time.time - jatpackStartTime) : 0f;
            if (DataHolder.jatpackTimeLeft == 0f)
            {
                DataHolder.jatpackActivated = false;
            }
        }
    }

    public static void UpdateShield()
    {
        // Debug.Log(DataHolder.shieldTimeLeft);
        if (DataHolder.shieldActivated)
        {
            DataHolder.shieldTimeLeft = DataHolder.shieldDuration - (Time.time - shieldStartTime) > 0 ? DataHolder.shieldDuration - (Time.time - shieldStartTime) : 0f;
            if (DataHolder.shieldTimeLeft == 0f)
            {
                DataHolder.shieldActivated = false;
            }
        }
    }
}
