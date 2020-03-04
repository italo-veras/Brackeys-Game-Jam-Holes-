using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cano : MonoBehaviour
{
    public Transform[] spawnBuracos;   
    public Transform posicaoCano;
    public float aguaDoCano;
    public LayerMask maskBuraco;
    public List<GameObject> ListaDeBuracos;
    public Buraco buracos;
    float tempoEsperaInicial, tempoAcabar, tempoDeSpawnBuracos,pontuacao;
    private void Awake()
    {
        // mover a UI para outro script
    }
    void Start()
    {
        aguaDoCano = 180f;
        tempoEsperaInicial = 5.0f;
        tempoDeSpawnBuracos = 6.5f;
        tempoAcabar = 15.0f;
        StartCoroutine(Comecar());
        
    }

    void Update()
    {        
        AdicionarBuracoALista();
        
    }
    IEnumerator Comecar()
    {
        
        yield return new WaitForSeconds(tempoEsperaInicial);
        StartCoroutine(GerarBuracos());
        StartCoroutine(AcabarFase());
        StartCoroutine(ModificarAgua());
    }
    IEnumerator AcabarFase()
    {
        yield return new WaitForSeconds(tempoAcabar); // 90.0f
            
        pontuacao = aguaDoCano;
        Debug.Log(pontuacao);
        Debug.Log("PAROU TUDO");
        StopAllCoroutines();    
    }

    IEnumerator GerarBuracos()
    {
        while (true)
        {
            Instantiate(buracos.gameObject, spawnBuracos[Random.Range(0, spawnBuracos.Length)].position, Quaternion.identity);

            yield return new WaitForSeconds(tempoDeSpawnBuracos);
            
        }
      
    }
    void AdicionarBuracoALista()
    {
        // adicionando os buracos a lista //
        ListaDeBuracos.Clear();

        Collider[] temBuraco = Physics.OverlapBox(posicaoCano.position, posicaoCano.localScale/2 , Quaternion.identity, maskBuraco);

        for (int i = 0; i < temBuraco.Length; i++)
        {
            GameObject buracoAdicionar = temBuraco[i].gameObject;

            ListaDeBuracos.Add(buracoAdicionar);
        }
        
        
    } 
    
    IEnumerator ModificarAgua()
    {
        // se não tiver buracos parar a contagem // 
        while (true)
        {
            if (ListaDeBuracos.Count == 0)
            {
                aguaDoCano = aguaDoCano;
            }
            else if (ListaDeBuracos.Count > 1)
            {
                aguaDoCano = buracos.QuantoAguaVaza(aguaDoCano) / ListaDeBuracos.Count * ListaDeBuracos.Count;
            }
            else
            {
                aguaDoCano = buracos.QuantoAguaVaza(aguaDoCano);
            }

            yield return new WaitForFixedUpdate();

        }

    }
    public float OlharTempoDeInicio(float tempoDeInicio)
    {
        tempoDeInicio = tempoEsperaInicial;

        tempoDeInicio = tempoDeInicio - Time.time;

        if(tempoDeInicio < 0)
        {
            tempoDeInicio = 0;
        }
        return tempoDeInicio;
        
    }
    public float OlharTempoParaFim(float tempoParaOFim)
    {
        tempoParaOFim = tempoAcabar;

        tempoParaOFim = 5 + tempoParaOFim - Time.time;

        if (tempoParaOFim < 0)
        {
            tempoParaOFim = 0;
        }
        return tempoParaOFim;
    }
}
