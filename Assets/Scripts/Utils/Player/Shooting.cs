using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damage = 42; // TODO: use different guns

    private Camera _camera;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) {
            return;
        }

        Debug.Assert(DataHolder.bulletCount >= 0);
        if (0 == DataHolder.bulletCount) {
            Debug.Log("ran out of bullets");
            return;
        }

        Debug.Log("Shoot");
        --DataHolder.bulletCount;

        Vector3 screen_center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screen_center);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            GameObject hitted_object = hit.transform.gameObject;
            Debug.Log("Hit " + hitted_object.name);

            Enemy enemy = hitted_object.GetComponent<Enemy>();
            if (null != enemy) {
                enemy.ReactToDamage(damage);
            }

            Debug.DrawLine(ray.origin, ray.GetPoint(10), Color.red, 5);
        }
    }
}
