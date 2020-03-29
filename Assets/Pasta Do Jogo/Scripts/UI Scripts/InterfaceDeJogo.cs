using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceDeJogo : MonoBehaviour
{
    public float tempoDeIniciar, tempoDeFim;
    public UnityEngine.UI.Button botaoReiniciar;
    public Text textoDeQuantaAgua, textoTempoInicial, textoTempoParaOFim,textoDoBotao;
    public Cano canoo;

    // Start is called before the first frame update
    void Start()
    {
        botaoReiniciar = GameObject.Find("Botao reiniciar").GetComponent<UnityEngine.UI.Button>();
        textoDoBotao = GameObject.Find("Text").GetComponent<Text>();
        textoDeQuantaAgua = GameObject.Find("Texto Agua").GetComponent<Text>();
        textoTempoInicial = GameObject.Find("Texto Contagem").GetComponent<Text>();
        textoTempoParaOFim = GameObject.Find("Texto Para o FIm").GetComponent<Text>();

        textoDoBotao.enabled = false;
        botaoReiniciar.image.enabled = false;
        textoTempoParaOFim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ValoresNaTela();
        botaoReiniciar.onClick.AddListener(QuandoClicar);

    }
    void ValoresNaTela()
    {
        canoo.OlharTempoDeInicio(tempoDeIniciar);
        canoo.OlharTempoParaFim(tempoDeFim);

        textoDeQuantaAgua.text = "Quantidade de agua: \n " + canoo.aguaDoCano.ToString("F"); // agua do cano na tela

        textoTempoInicial.text = "Tempo para começar: \n" + canoo.OlharTempoDeInicio(tempoDeIniciar).ToString("F"); // tempo inicial na tela

        if (canoo.OlharTempoDeInicio(tempoDeIniciar) <= 0) // se o tempo inicial for 0 começar o tempo para acabar
        {
            textoTempoInicial.enabled = false;

            textoTempoParaOFim.enabled = true;

            textoTempoParaOFim.text = "Tempo para terminar: \n" + canoo.OlharTempoParaFim(tempoDeFim).ToString("F");
        
            if (canoo.OlharTempoParaFim(tempoDeFim) <= 0)
            {
                botaoReiniciar.image.enabled = true;
                textoDoBotao.enabled = true;
                textoDoBotao.text = "Aperte Para Reiniciar";
            }
        }
    }
    void QuandoClicar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Clicouiuuuoasdj");
    }
}
