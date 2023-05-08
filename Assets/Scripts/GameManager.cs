using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    private bool gameOverInvoked = false;

    private int customerCount=0;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TextMeshProUGUI customerCountText;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverInvoked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && !gameOverInvoked)
        {
            print("GameOver");
            gameOverCanvas.SetActive(true);
            Invoke("GameOver", 4.0f);
            gameOverInvoked=true;
        }


    }


    public void SetGameOver(bool isGameOver)
    {
        gameOver = isGameOver;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }

    public void AddCustomer()
    {
        customerCount++;
        customerCountText.text = "Customers: " + customerCount;
    }
}
