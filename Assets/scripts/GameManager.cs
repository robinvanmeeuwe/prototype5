using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public List<GameObject> targets;

    // Dit zorgt ervoor dat we de tekst kunnen aanklikken.
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    
    public bool isGameActive;
    
    public Button restartButton;

    public GameObject titleScreen;
    
    // Dit zet de spawn rate naar 1 seconde
    private float spawnRate = 1.0f;
    
    private int score;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    IEnumerator SpawnTarget()
    {
        // alleeen spawn wanneer game actief is
        while(isGameActive)
        {
            yield return  new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            Debug.Log("spawn");
        }
    }

    // score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // restart button
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        
      
        isGameActive = false;
    }

    // restart
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
 
        isGameActive = true;

        // verschillende difficulties
        spawnRate /= difficulty;
        
        // start spawnscript
        StartCoroutine(SpawnTarget());
        
    
        score = 0;
        UpdateScore(0);
        
        // verwijderen title screen
        titleScreen.gameObject.SetActive(false);
    }
}