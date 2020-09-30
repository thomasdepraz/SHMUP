using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 5f)]
    public float speed = 1f;
    private Camera cam;
    public Vector2 direction;
    private void Start()
    {
        cam = Camera.main;
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        direction = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        if(direction.magnitude > 0.1f)
        { 
            gameObject.transform.position += (Vector3)direction.normalized * (speed * direction.magnitude) * Time.fixedDeltaTime;
        }
    }
}
