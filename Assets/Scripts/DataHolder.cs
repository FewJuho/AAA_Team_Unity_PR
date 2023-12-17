using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{

    // System settings
    public static int _currentLevel;
    public static int _openLevels = 1;
    public static bool _stopMouseFollowing = false;
    public static bool _globalPause = false;
    public static bool _weaponMenuOpen = false;
    public static bool _activateCrosshair = true;
    public static string _helpText = "Welcome!\n" +
    "In this \"dev\" version you can:\n" +
    "1) lower your HP by pressing \"H\" on your keyboard\n" +
    "2) lower your Bullet count by pressing \"B\" on your keyboard";

    // Game settings
    public static int maxHP = 1200;
    public static int currentHP = 1200;
    public static int maxShield = 500;
    public static int currentShield = 0;

    public static int bulletCount = 10;
    public static string[] weaponTypes = {"Fi", "Se"};
    public static bool jatpackActivated = false;
    public static float damageMultiplier = 1.0f;

    public static int _healsCount = 1;
    public static int _shieldsCount = 1;
    public static int _jetpacksCount = 1;
    public static int _damageUpsCount = 1;

    public static int jatpackDuration = 15;
    public static int damageMultiplierDuration = 15;
    public static float jatpackTimeLeft = 0f;
    public static float damageMultiplierTimeLeft = 0f;
}

public static class _Hammer
{
    public static int damage = 100;
    public static int ammoPrice = 0;
    public static int rangeRadius = 1;
}

public static class _Shotgun
{
    public static int damage = 50;
    public static int ammoPrice = 5;
    public static int rangeRadius = 10;

    public static int getScaler(GameObject target)
    {
        return 1;
    }
}

public static class _Pistol
{
    public static int damage = 25;
    public static int ammoPrice = 2;
    public static int rangeRadius = 10;
}

public static class _Rifle
{
    public static int damage = 10;
    public static int ammoPrice = 1;
    public static int rangeRadius = 10;
}

public static class _None
{
    public static int damage = 0;
    public static int ammoPrice = 0;
    public static int rangeRadius = 0;
}