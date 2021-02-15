using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public AudioSource audioAk47;
    public AudioSource audioAcertou;

    void Update()
    {
        // Verifica o clique do mouse
        if(Input.GetMouseButtonDown(0) && !GameManager.instance.fimJogo)
        {
            audioAk47.Play(0);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Alvo")
                {
                    audioAcertou.Play();
                    GameManager.instance.pontuar();
                    Destroy(hit.collider.gameObject);
                    Spawn.instance.Spawn_Alvo_Delay();
                }
                    
            }
            else
            {
                GameManager.instance.erro();
            }
    
        }
    }
}
