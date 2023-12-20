using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;

    void Start()
    {
        ShowWeapon(weapon1);
        HideWeapon(weapon2);
        HideWeapon(weapon3);
        HideWeapon(weapon4);
    }

    public void OnButtonUpClick()
    {
        ShowWeapon(weapon1);
        HideWeapon(weapon2);
        HideWeapon(weapon3);
        HideWeapon(weapon4);
    }

    public void OnButtonLeftClick()
    {
        ShowWeapon(weapon2);
        HideWeapon(weapon1);
        HideWeapon(weapon3);
        HideWeapon(weapon4);
    }

    public void OnButtonRightClick()
    {
        ShowWeapon(weapon3);
        HideWeapon(weapon1);
        HideWeapon(weapon2);
        HideWeapon(weapon4);
    }

    public void OnButtonDownClick()
    {
        ShowWeapon(weapon4);
        HideWeapon(weapon1);
        HideWeapon(weapon2);
        HideWeapon(weapon3);
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
