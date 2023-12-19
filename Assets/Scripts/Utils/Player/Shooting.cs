using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _gunNozzle;
    [SerializeField] Vector3 targetPoint;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (DataHolder._stopMouseFollowing || DataHolder.currentWeapon == Weapon.Type.None) {
            return;
        }

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
        Ray ray = _camera.ScreenPointToRay(targetPoint);

        RaycastHit hit;

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f)) {
            return;
        }


        targetPoint = hit.point;
        GameObject hitted_object = hit.transform.gameObject;
        Debug.Log("Try to hit " + hitted_object.name + " at distance " + hit.distance.ToString());
        GameObject bullet = GameObject.Instantiate(_bullet, _gunNozzle.position, _gunNozzle.rotation);
        bullet.GetComponent<LaserBullet>().GetPoint(targetPoint);

        // if (currentWeapon.GetRangeRadius() < hit.distance) {
        //     Debug.Log("Hitted object is too far away");
        //     return;
        // }

        Enemy enemy = hitted_object.GetComponent<Enemy>();
        if (null != enemy) {
            enemy.ReactToDamage(currentWeapon.GetDamage());
        // =======


        // Debug.DrawLine(ray.origin, ray.GetPoint(10), Color.red, 5);

        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f))
        // {
        // targetPoint = hit.point;
        // GameObject hitted_object = hit.transform.gameObject;
        // Debug.Log("Hit " + hitted_object.name);
        // GameObject bullet = GameObject.Instantiate(_bullet, _gunNozzle.position, _gunNozzle.rotation);
        // bullet.GetComponent<LaserBullet>().GetPoint(targetPoint);

        // Enemy enemy = hitted_object.GetComponent<Enemy>();
        // if (null != enemy)
        // {
        // enemy.ReactToDamage(damage);
        // }

        // Debug.DrawLine(ray.origin, ray.GetPoint(10), Color.red, 5);

        // Debug.Log("Shoot");
        // —DataHolder.bulletCount;
        // }
        // »»»> dev
        }
    }
}