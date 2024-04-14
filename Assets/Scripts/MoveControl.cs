using UnityEngine;
using UnityEngine.UIElements;

public class MoveControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] float speed = 5f;
    [SerializeField] Doodler doodler;
    float direction = 0;

    private Camera mainCamera;
    private float cameraWidth;
    private float cameraLeftBorder;
    private float cameraRightBorder;
    private float borderOffset = 1f;



    private void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;

        Vector3 cameraPosition = mainCamera.transform.position;

        cameraLeftBorder = cameraPosition.x - cameraWidth;
        cameraRightBorder = cameraPosition.x + cameraWidth;

    }



    private void Update()
    {

        //    float moveHorizontal = Input.GetAxis("Horizontal");
        //    rb2.velocity = new Vector2(moveHorizontal * speed, rb2.velocity.y);
        //    Debug.Log(moveHorizontal);

        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        //Doodler teleport
        if(doodler.transform.position.x <= cameraLeftBorder)
        {
            doodler.transform.position = new Vector2(cameraRightBorder - borderOffset, doodler.transform.position.y);
        }
        else if(doodler.transform.position.x >= cameraRightBorder)
        {
            doodler.transform.position = new Vector2(cameraLeftBorder + borderOffset, doodler.transform.position.y);
        }
        
    }



    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(direction * speed, rb2.velocity.y);
    }
}
