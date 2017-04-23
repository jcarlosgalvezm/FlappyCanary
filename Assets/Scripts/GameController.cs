using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public GameObject gameOverText;
    public GameObject sumPauseButton;
    public Text timeText;
    public bool gameOver = false;
    public bool gamePaused = false;
    public float scrollSpeed = -1.5f;
    public int nextLevel = 5;
    public Text scoreText;
    public int score;
    private float time;

    private void Awake()
    {
        gameOver = false;

        if (GameController.instance == null)
            GameController.instance = this;

        else if (GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController instanciado por segunda vez");
        }

    }

    private void Update()
    {
        if (gameOver)
            return;

        time += 1 * Time.deltaTime;
        timeText.text = "Tiempo: " + (int) time;
    }

    public void BirdScored() {

        if (gameOver)
           return;
        else { 
            score++;
            scoreText.text = "Puntos: " + score;
            SoundSystem.instance.PlayCoin();
        }
    }
	
    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        sumPauseButton.SetActive(false);

    }

    private void OnDestroy()
    {
        if (GameController.instance == this)
            GameController.instance = null;
    }

}
