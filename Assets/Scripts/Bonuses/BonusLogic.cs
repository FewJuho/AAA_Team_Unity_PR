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
                if (DataHolder._healsCount >= amount)
                {
                    int hpToAdd = DataHolder.maxHP - DataHolder.currentHP < 300 ? DataHolder.maxHP - DataHolder.currentHP : 300;
                    if (hpToAdd > 0) {
                        DataHolder.currentHP += (hpToAdd * amount);
                        DataHolder._healsCount -= amount;
                        Debug.Log("HP = " + DataHolder.currentHP);
                        return true;
                    }
                    return false;
                }
                break;
            case BonusType.Shields:
                if (DataHolder._shieldsCount >= amount)
                {
                    DataHolder.currentShield += (250 * amount);
                    DataHolder._shieldsCount -= amount;
                    return true;
                }
                break;
            case BonusType.Jetpacks:
                if (DataHolder._jetpacksCount >= amount)
                {
                    jatpackStartTime = Time.time;
                    DataHolder._jetpacksCount -= amount;
                    DataHolder.jatpackActivated = true;
                    return true;
                }
                break;
            case BonusType.DamageUps:
                if (DataHolder._damageUpsCount >= amount)
                {
                    DataHolder.damageMultiplier = 2.0f;
                    damageMultiplierStartTime = Time.time;
                    DataHolder._damageUpsCount -= amount;
                    return true;
                }
                break;
        }

        return false;
    }

    // Âûחûגאועסÿ ג ךאזהמל ךאהנו
    public static void UpdateDamageMultiplier()
    {
        if (Time.time - damageMultiplierStartTime < DataHolder.damageMultiplierDuration && DataHolder.damageMultiplier == 2.0f)
        {
            DataHolder.damageMultiplier = 2.0f;
        }
        else
        {
            DataHolder.damageMultiplier = 1.0f;
        }
        DataHolder.damageMultiplierTimeLeft = Time.time - damageMultiplierStartTime > 0? Time.time - damageMultiplierStartTime : 0f;
    }

    public static void UpdateJatpack()
    {
        if (DataHolder.jatpackTimeLeft < DataHolder.jatpackDuration && DataHolder.jatpackActivated)
        {
            DataHolder.jatpackActivated = true;
        }
        else
        {
            DataHolder.jatpackActivated = false;
        }
        DataHolder.jatpackTimeLeft = Time.time - jatpackStartTime > 0 ? Time.time - jatpackStartTime : 0f;
    }

    public static void UpdateShield()
    {
        if (DataHolder.shieldTimeLeft < DataHolder.shieldDuration && DataHolder.shieldActivated)
        {
            DataHolder.shieldActivated = true;
        }
        else
        {
            DataHolder.shieldActivated = false;
        }
        DataHolder.shieldTimeLeft = Time.time - shieldStartTime > 0 ? Time.time - shieldStartTime : 0f;
    }
}
