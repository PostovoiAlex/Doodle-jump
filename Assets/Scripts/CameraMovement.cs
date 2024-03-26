using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Doodler doodler;
    [SerializeField] int speed;
    [SerializeField] float offsetY;

    private float newPos;

    private void Start()
    {
        if (doodler == null)
        {
            return;
        }

        doodler.OnJumped += OnJumped;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, newPos - offsetY, transform.position.z), Time.deltaTime * speed);
    }
    private void OnJumped(float obj)
    {
        newPos = obj;
        //transform.position = new Vector3(transform.position.x, obj, transform.position.z);
    }
}
