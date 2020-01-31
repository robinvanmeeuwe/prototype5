  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class DifficultyButton : MonoBehaviour
{
    // connectie
    private Button button;
    private GameManager gameManager;

    // variable difficulty
    public int difficulty;
        
    // Start is called before the first frame update
    void Start()
    {
        // link gamemanager
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        // buttons difficulty
        button.onClick.AddListener(SetDifficulty);
    }

    // verschillende difficulties
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}