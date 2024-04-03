using UnityEngine;
using UnityEngine.UIElements;

public class MoveControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] Collider2D doodlerCollider;
    [SerializeField] float speed = 5f;
    [SerializeField] Doodler doodler;
    float direction = 0;

    private void Update()
    {

        //    float moveHorizontal = Input.GetAxis("Horizontal");
        //    rb2.velocity = new Vector2(moveHorizontal * speed, rb2.velocity.y);
        //    Debug.Log(moveHorizontal);

        if (Input.GetKey(KeyCode.A))
        {
            //    Debug.Log("A key pressed");
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //   Debug.Log("D key pressed");
            direction = 1;
        }
        else
        {
            direction = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("border"))
        {
            Debug.Log("Border");
            doodler.transform.position = new Vector2(doodler.transform.position.x * -1, doodler.transform.position.y); 
        }
    }



    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(direction * speed, rb2.velocity.y);
    }
}
