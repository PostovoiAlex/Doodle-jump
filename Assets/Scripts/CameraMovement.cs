using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Doodler doodler;
    [SerializeField] int speed;
    [SerializeField] float offsetY;
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] TMPro.TMP_Text bestScoreText;

    private int score;
    private int bestScore;
    

    private float newPos;

    private void Start()
    {
        if (doodler == null)
        {
            return;
        }

        doodler.OnJumped += OnJumped;
        doodler.OnDead += OnDead;

        bestScore = PlayerPrefs.GetInt("bestScore");

        bestScoreText.text = $"best score \n {bestScore.ToString()}";

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, newPos - offsetY, transform.position.z), Time.deltaTime * speed);

      
    }
    private void OnJumped(float obj)
    {
        newPos = obj;
        score = (int)transform.position.y;
        scoreText.text = score.ToString();

        //transform.position = new Vector3(transform.position.x, obj, transform.position.z);
    }

    private void OnDead()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);

        }
    }
}
