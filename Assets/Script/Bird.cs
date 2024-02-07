using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpPower = 1.5f;
    public float rotationSpeed = 10f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//merefensikan rigidbody2d
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jika burung bertubrukan dengan collider objek, maka skrip ini akan mengirimkan sinyal ke seluruh skrip yang
        //mensubscribe kalo game sudah gameover
        Actions.OnGameOver?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PipeLine"))
        {
            Actions.OnScored?.Invoke(1);
        }
    }
}
