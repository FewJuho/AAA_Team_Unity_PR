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
    public static string _helpText = "Welcome!\n" +
    "In this \"dev\" version you can:\n" +
    "1) lower your HP by pressing \"H\" on your keyboard\n" +
    "2) lower your Bullet count by pressing \"B\" on your keyboard";

    // Game settings
    public static int maxHP = 1200;
    public static int currentHP = 1200;
    public static int bulletCount = 10;
    public static string[] weaponTypes = {"Fi", "Se"};


}
