using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private int acertos;
    private int erros;
    public static GameManager instance;
    public Text textPontuation;
    public Text textErros;

    // Variáveis do placar

    public bool fimJogo;
    public GameObject TelaPlacar;
    public Text textPrecision;
    public Text textTempoPlacar;

    // Variáveis de tempo

    private float timerGame; // Armazena o tempo do inicio do jogo até o fim
    public Text textTimer;

    void Start()
    {
        instance = this;
        acertos = 0;
        erros = 0;
        timerGame = 0;
        Time.timeScale = 1;
        fimJogo = false;
    }

    void Update() 
    {
        timerGame += Time.deltaTime;
        textTimer.text = Mathf.Round(timerGame).ToString();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.ShowPlacar();
        }
    }
    
    public void pontuar()
    {
        acertos += 1;
        textPontuation.text = acertos.ToString();
    }

    public void erro()
    {
        erros += 1;
        textErros.text = erros.ToString();
    }

    public void PlayAgain(string name_map)
    {
        SceneManager.LoadScene(name_map);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowPlacar()
    {
        fimJogo = true;
        calcular_desempenho();
        TelaPlacar.SetActive(true);
        Time.timeScale = 0;
    }

    public void calcular_desempenho()
    {
        float precision = ( (float) acertos / (erros+acertos)) * 100;
        if (erros == 0)
        {
            precision = 100f;
        }
        if (acertos == 0)
        {
            precision = 0f;
        }
        textPrecision.text = "Precisão = " + precision.ToString("0.00") + "%";
        textTempoPlacar.text = Mathf.Round(timerGame).ToString() + " s"; 
    }
}
