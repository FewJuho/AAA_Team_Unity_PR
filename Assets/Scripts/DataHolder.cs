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
    public static string _helpText = "Welcome!\n";

    // Game settings
    public static int maxHP = 1200;
    public static int currentHP = 1200;
    public static int maxEnemiesCount = 10;
    public static int spawnedEnemiesCount = 0;

    public static int AnkleGrabberDamage = 150;
    public static int bulletCount = 100;
    public static int killedEnemiesCount = 0;
    public const int bulletCountAtCrate = 10;
    public static string[] weaponTypes = {"Fi", "Se"};
    public static bool jatpackActivated = false;
    public static bool shieldActivated = false;
    public static float damageMultiplier = 1.0f;

    public static int _healsCount = 1;
    public static int _shieldsCount = 1;
    public static int _jetpacksCount = 1;
    public static int _damageUpsCount = 1;

    public static int jatpackDuration = 15;
    public static int damageMultiplierDuration = 15;
    public static int shieldDuration = 7;
    public static float jatpackTimeLeft = 0f;
    public static float damageMultiplierTimeLeft = 0f;
    public static float shieldTimeLeft = 0f;
    public static Weapon.Type currentWeapon = Weapon.Type.None;
}
