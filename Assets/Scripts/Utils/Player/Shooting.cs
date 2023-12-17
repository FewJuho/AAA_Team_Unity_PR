using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;


    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        var currentWeapon = Weapon.FromType(DataHolder.currentWeapon);

        if (!currentWeapon.IsShooting()) {
            return;
        }

        Debug.Assert(DataHolder.bulletCount >= 0);
        if (DataHolder.bulletCount < currentWeapon.GetAmmoPrice()) {
            Debug.Log("ran out of bullets");
            // Do nothing now
            // TODO: add sound effect?
            return;
        }

        Debug.Log("Shoot");
        DataHolder.bulletCount -= currentWeapon.GetAmmoPrice();

        Vector3 screen_center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screen_center);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) {
            return;
        } 
        
        GameObject hitted_object = hit.transform.gameObject;
        Debug.Log("Try to hit " + hitted_object.name + " at distance " + hit.distance.ToString());

        if (currentWeapon.GetRangeRadius() < hit.distance) {
            Debug.Log("Hitted object is too far away");
            return;
        }

        Enemy enemy = hitted_object.GetComponent<Enemy>();
        if (null != enemy) {
            enemy.ReactToDamage(currentWeapon.GetDamage());
        }
    }
}
