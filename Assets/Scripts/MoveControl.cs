using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] float speed = 5f;
    float direction = 0;

    //private void Update()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    rb2.velocity = new Vector2(moveHorizontal * speed, rb2.velocity.y);
    //    Debug.Log(moveHorizontal);
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A key pressed");
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key pressed");
            direction = 1;
        }
        else
        {
            direction = 0;
        }
        
    }

    private void FixedUpdate()
    {
        rb2.velocity = new Vector2 (direction * speed, rb2.velocity.y);
    }
}
