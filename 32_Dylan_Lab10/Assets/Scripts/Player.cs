using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    private int Score;
    [SerializeField] private Text ScoreText = null;
    [SerializeField] private Text Txt_HighScore = null;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        ScoreText.text = "Score : " + Score;
        if(transform.position.y >= 7 || transform.position.y <= -5)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            Txt_HighScore.text = Score.ToString();

        }
        if(Score <= -5)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
        if(other.gameObject.tag == "Extra")
        {
            Score += 3;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Point")
        {
            Score ++;
        }
        if(other.gameObject.tag == "Negative")
        {
            Score -= 4;
            Destroy(other.gameObject);
        }
    }
}
