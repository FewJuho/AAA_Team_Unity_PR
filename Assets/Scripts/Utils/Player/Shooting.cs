using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    private bool isShootingAvailable = true;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _gunNozzle;
    [SerializeField] Vector3 targetPoint;
    public AudioClip hammerPunchAudio;
    public AudioClip pistolPunchAudio;
    public AudioClip shotgunPunchAudio;
    public AudioClip riflePunchAudio;
    public AudioClip lowBulletsAudio;

    void Start()
    {
        _camera = GetComponent<Camera>();
        var models = this.transform.Find("CanvasFirstPerson").transform.Find("Weapon_Models");
    }

    void Update()
    {
        if (DataHolder._stopMouseFollowing) {
            return;
        }

        if (!isShootingAvailable) {
            return;
        }

        var currentWeapon = Weapon.FromType(DataHolder.currentWeapon);

        if (!currentWeapon.IsShooting()) {
            return;
        }

        Debug.Assert(DataHolder.bulletCount >= 0);
        if (DataHolder.bulletCount < currentWeapon.GetAmmoPrice()) {
            GetComponent<AudioSource>().PlayOneShot(lowBulletsAudio);
            return;
        }

        if (DataHolder.currentWeapon == Weapon.Type.Hammer) {
            GetComponent<AudioSource>().PlayOneShot(hammerPunchAudio);
        }

        if (DataHolder.currentWeapon == Weapon.Type.Pistol)
        {
            GetComponent<AudioSource>().PlayOneShot(pistolPunchAudio);
        }

        if (DataHolder.currentWeapon == Weapon.Type.Rifle)
        {
            GetComponent<AudioSource>().PlayOneShot(riflePunchAudio);
        }

        if (DataHolder.currentWeapon == Weapon.Type.Shotgun)
        {
            GetComponent<AudioSource>().PlayOneShot(shotgunPunchAudio);
        }

        Debug.Log("Shoot");
        DataHolder.bulletCount -= currentWeapon.GetAmmoPrice();
        StartCoroutine(ShootingCooldown(currentWeapon.GetFireRateTime()));

        Vector3 screen_center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(targetPoint);

        RaycastHit hit;

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f)) {
            return;
        }

        GameObject hitted_object = hit.transform.gameObject;
        Debug.Log("Try to hit " + hitted_object.name + " at distance " + hit.distance.ToString());

        if (currentWeapon.HasBullets()) {
            targetPoint = hit.point;
            GameObject bullet = GameObject.Instantiate(_bullet, _gunNozzle.position, _gunNozzle.rotation);
            bullet.transform.Rotate(90.0f, 0.0f, 0.0f);
            bullet.GetComponent<LaserBullet>().GetPoint(targetPoint);
        }

        if (currentWeapon.GetRangeRadius() < hit.distance) {
            Debug.Log("Hitted object is too far away");
            return;
        }

        Enemy enemy = hitted_object.GetComponent<Enemy>();
        if (null != enemy) {
            enemy.ReactToDamage(currentWeapon.GetDamage() * (int)DataHolder.damageMultiplier);
        }
    }

    IEnumerator ShootingCooldown(float cooldown) {
        isShootingAvailable = false;
        yield return new WaitForSeconds(cooldown);
        isShootingAvailable = true;
    }
}