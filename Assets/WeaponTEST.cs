using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTEST : MonoBehaviour
{
    public GameObject hammer;
    public GameObject pistol;
    public GameObject rifle;
    public GameObject shotgun;
    public GameObject radialMenu;

    void Start()
    {
        HideWeapon(hammer);
        HideWeapon(pistol);
        HideWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
    }

    public void SetHammer()
    {
        ShowWeapon(hammer);
        HideWeapon(pistol);
        HideWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
    }

    public void SetPistol()
    {
        HideWeapon(hammer);
        ShowWeapon(pistol);
        HideWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
    }

    public void SetRifle()
    {
        HideWeapon(hammer);
        HideWeapon(pistol);
        ShowWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
    }

    public void SetShotgun()
    {
        HideWeapon(hammer);
        HideWeapon(pistol);
        HideWeapon(rifle);
        ShowWeapon(shotgun);
        Resume();
    }


    public void Resume()
    {
        DataHolder._globalPause = false;
        radialMenu.SetActive(false);
        Time.timeScale = 1f;
        DataHolder._stopMouseFollowing = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowWeapon(GameObject weapon)
    {
        weapon.SetActive(true);
    }

    void HideWeapon(GameObject weapon)
    {
        weapon.SetActive(false);
    }
}
