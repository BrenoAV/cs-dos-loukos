using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int acertos;
    private int erros;
    public static GameManager instance;
    public Text textPontuation;
    public Text textErros;

    // Variáveis de tempo

    private float timerGame; // Armazena o tempo do inicio do jogo até o fim
    public Text textTimer;
    void Start()
    {
        instance = this;
        acertos = 0;
        erros = 0;
        timerGame = 0;
    }

    void Update() 
    {
        timerGame += Time.deltaTime;
        textTimer.text = Mathf.Round(timerGame).ToString();
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
}
