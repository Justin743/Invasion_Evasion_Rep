using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI gameOverText;
    

    private PlayerController playerController;
    private SpawnManager spawnManager;

    private int roundNum;
    private int health;
    private int score;
    public Button restartButton;
    


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        //sets score to 0 at start 
        score = 0;
        ScoreText.text = "Score : " + score;
        updateScore(0);

        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateRoundNumber();
        
    }
    public void UpdateHealth()
    {
        health = playerController.health;
        healthText.text = "Health : " + health;
    }
    public void UpdateRoundNumber()
    {
        roundNum = spawnManager.waveNum;
        roundText.text = "Round " + roundNum;
    }

    //Update score method
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "Score : " + score;
    }

    public void gameOver() { 
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void restartGame() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
