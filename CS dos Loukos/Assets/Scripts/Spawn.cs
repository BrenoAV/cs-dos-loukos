using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float temporizadorSpawn;
    public float tempoSpawn;
    private bool podeContar;
    public GameObject[] inimigos = new GameObject[0];
    public static Spawn instance;
    private GameObject Alvo_Atual;
    private float[,] spawn_pos = new float[,]
    {
        {-5.12f, 0.65f}, {3.52f , 0.17f}, 
        {5.83f, -3.04f}, {-5.76f, -2.61f}, 
        {-1.82f, 1.34f}, {2.02f, -2.81f},
        {-2.81f, -2.80f}, {-0.84f, 1.62f}
    };
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Invoke("Spawn_Alvo", 0.4f); // Começa com um alvo
        podeContar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (podeContar)
            temporizadorSpawn += Time.deltaTime;
            
        // Spawn por tempo
        if(temporizadorSpawn >= tempoSpawn)
        {
            
            GameManager.instance.erro();
            Destroy(this.Alvo_Atual);
            Spawn_Alvo_Delay();
        }
    }

    public void Spawn_Alvo_Delay()
    {
        podeContar = false;
        temporizadorSpawn = 0.0f;
        Invoke("Spawn_Alvo" , 0.2f);
    }

    public void Spawn_Alvo()
    {
        int num_alvo = Random.Range(0, inimigos.Length);
        this.Alvo_Atual = Instantiate(inimigos[num_alvo], new Vector3(spawn_pos[num_alvo, 0], 
                                            spawn_pos[num_alvo, 1], 0.0f), 
                                            Quaternion.identity);
        podeContar = true;
        
    }
}
