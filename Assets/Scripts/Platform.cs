using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Action<Platform> OnDestoyed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lose zone"))
        {
            Debug.Log("Destroyed");
            OnDestoyed?.Invoke(this);
        }
    }
}
