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
    public GameObject crosshair;

    public AudioClip hammerPickupAudio;
    public AudioClip pistolPickupAudio;
    public AudioClip shotgunPickupAudio;
    public AudioClip riflePickupAudio;

    void Start()
    {
        DataHolder.currentWeapon = Weapon.Type.None;
        HideWeapon(hammer);
        HideWeapon(pistol);
        HideWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
    }

    public void SetHammer()
    {
        DataHolder.currentWeapon = Weapon.Type.Hammer;
        ShowWeapon(hammer);
        HideWeapon(pistol);
        HideWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
        GetComponent<AudioSource>().PlayOneShot(hammerPickupAudio);
    }

    public void SetPistol()
    {
        DataHolder.currentWeapon = Weapon.Type.Pistol;
        HideWeapon(hammer);
        ShowWeapon(pistol);
        HideWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
        GetComponent<AudioSource>().PlayOneShot(pistolPickupAudio);
    }

    public void SetRifle()
    {
        DataHolder.currentWeapon = Weapon.Type.Rifle;
        HideWeapon(hammer);
        HideWeapon(pistol);
        ShowWeapon(rifle);
        HideWeapon(shotgun);
        Resume();
        GetComponent<AudioSource>().PlayOneShot(riflePickupAudio);
    }

    public void SetShotgun()
    {
        DataHolder.currentWeapon = Weapon.Type.Shotgun;
        HideWeapon(hammer);
        HideWeapon(pistol);
        HideWeapon(rifle);
        ShowWeapon(shotgun);
        Resume();
        GetComponent<AudioSource>().PlayOneShot(shotgunPickupAudio);
    }


    public void Resume()
    {
        DataHolder._weaponMenuOpen = false;
        radialMenu.SetActive(false);
        Time.timeScale = 1f;
        DataHolder._stopMouseFollowing = false;
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(DataHolder._activateCrosshair);
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
