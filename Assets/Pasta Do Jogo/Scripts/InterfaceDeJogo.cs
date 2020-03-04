using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class InterfaceDeJogo : MonoBehaviour
{
    public float tempoDeIniciar, tempoDeFim;
    public Text textoDeQuantaAgua, textoTempoInicial, textoTempoParaOFim;
    public Cano canoo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ValoresNaTela();
    }
    void ValoresNaTela()
    {
        canoo.OlharTempoDeInicio(tempoDeIniciar);
        canoo.OlharTempoParaFim(tempoDeFim);

        textoDeQuantaAgua.text = "Quantidade de agua: \n " + canoo.aguaDoCano.ToString("F"); // agua do cano na tela

        textoTempoInicial.text = "Tempo para começar: \n" + canoo.OlharTempoDeInicio(tempoDeIniciar).ToString("F"); // tempo inicial na tela

        textoTempoParaOFim.enabled = false;
        if (canoo.OlharTempoDeInicio(tempoDeIniciar) <= 0) // se o tempo inicial for 0 começar o tempo para acabar
        {
            textoTempoInicial.enabled = false;
            textoTempoParaOFim.enabled = true;

            textoTempoParaOFim.text = "Tempo para terminar: \n" + canoo.OlharTempoParaFim(tempoDeFim).ToString("F");

        }
    }
}
