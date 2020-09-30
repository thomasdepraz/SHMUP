using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private List<GameObject> bullets;
    public float bulletSpeed;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
        }
    }

    private void Shoot()
    {
       
    }
}
