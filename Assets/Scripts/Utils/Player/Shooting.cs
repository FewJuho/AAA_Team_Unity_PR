using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damage = 42; // TODO: use different guns

    private Camera _camera;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _gunNozzle;
    [SerializeField] Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Assert(DataHolder.bulletCount >= 0);
            if (0 == DataHolder.bulletCount)
            {
                Debug.Log("ran out of bullets");
                return;
            }

            Ray ray = _camera.ScreenPointToRay(targetPoint);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f))
            {
                targetPoint = hit.point;
                GameObject hitted_object = hit.transform.gameObject;
                Debug.Log("Hit " + hitted_object.name);
                GameObject bullet = GameObject.Instantiate(_bullet, _gunNozzle.position, _gunNozzle.rotation);
                bullet.GetComponent<LaserBullet>().GetPoint(targetPoint);

                Enemy enemy = hitted_object.GetComponent<Enemy>();
                if (null != enemy)
                {
                    enemy.ReactToDamage(damage);
                }

                Debug.DrawLine(ray.origin, ray.GetPoint(10), Color.red, 5);

                Debug.Log("Shoot");
                --DataHolder.bulletCount;
            }
        }
    }
}
