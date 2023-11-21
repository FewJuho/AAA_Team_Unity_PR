using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    public GameObject obj;

    private void Start()
    {
        Instantiate(obj, new Vector3(0, 5, 0), Quaternion.Euler(12f, -15f, 40f));
    }
}
