using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;

    private Rigidbody2D rb;
    private Camera cam;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

    }
}
