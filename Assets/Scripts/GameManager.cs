using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private Player player;
    private Spawner spawner;

    public GameObject playButton;
    public GameObject gameOver;
    public GameObject youWin; // Nueva referencia para la pantalla de victoria
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        youWin.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    // Nueva función para manejar la victoria del jugador
    public void Victory()
    {
        playButton.SetActive(true); // Activar el botón de jugar
        youWin.SetActive(true); // Mostrar la pantalla de victoria
        Pause();
    }

    public void IncreaseScore()
    {
        score = score + 25;
        scoreText.text = score.ToString();

        // Verificar si el jugador ha alcanzado los 1000 puntos
        if(score >= 1000)
        {
            Victory();
        }
    }

}
