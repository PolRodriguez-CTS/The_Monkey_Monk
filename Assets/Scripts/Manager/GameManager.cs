using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseCanvas;
    private int numberCoins = 0;
    private int numberPoints = 0;
    private int numberBanana = 0;
    public Text coinsText;
    public Text pointsText;
    public Text bananaText;
    private SoundManager _soundManager;
    public int pollitoPoints = 100;
    public int coinsPoints = 50;

    private WinCondition _winCondition;

    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
        _winCondition = FindObjectOfType<WinCondition>().GetComponent<WinCondition>();
    }

    void Start()
    {
        coinsText.text = "x " + numberCoins.ToString();
        pointsText.text = "x " + numberPoints.ToString();
        bananaText.text = "x " + numberPoints.ToString();
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Pause") && !_winCondition.hasWinned)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if(isPaused)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            _soundManager.ResumeBGM();
        }
        else
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            _soundManager.PauseBGM();
        }
    }

    public void AddCoins()
    {
        numberCoins ++;
        coinsText.text = "x " + numberCoins.ToString();
    }

    public void AddBanana()
    {
        numberBanana ++;
        bananaText.text = "x " + numberBanana.ToString();
    }

    public void RemoveBanana()
    {
        numberBanana --;
        bananaText.text = "x " + numberBanana.ToString();
    }

    public void AddPoints(int pointsToAdd)
    {
        numberPoints += pointsToAdd;
        pointsText.text = "x " +numberPoints.ToString();
    }
}
