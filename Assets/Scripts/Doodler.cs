using System;
using UnityEngine;

public class Doodler : MonoBehaviour
{
    [SerializeField] Collider2D collider;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] int jumpForce;

    bool isJumped = false;

    public Action<float> OnJumped;

    private float maxPosY = -1;


    void FixedUpdate()
    {

        if (maxPosY < transform.position.y)
        {
            maxPosY = transform.position.y;
            OnJumped?.Invoke(transform.position.y);
        }

        if (isJumped && rb2D.velocity.y <=0)
        {

            EnableCollider();

            isJumped = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumped)
        {
            return;
        }

        rb2D.velocity = new Vector2(0, jumpForce);
        //rb2D.AddForce(Vector2.up * jumpForce);

        DisableCollider();

        isJumped=true;
    }

    private void DisableCollider()
    {
        collider.enabled = false;

    }

    private void EnableCollider()
    {
        collider.enabled = true; 
    }
    
}
