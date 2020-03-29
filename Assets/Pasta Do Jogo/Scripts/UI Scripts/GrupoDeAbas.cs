using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrupoDeAbas : MonoBehaviour
{
    public List<BotaoAbas> botoesAbas;
    public Image abaIdle,abaPorCima,abaSelecionada;
    public BotaoAbas abaPrecionada;
    public void Inscrever(BotaoAbas botao)
    {
        if(botoesAbas == null)
        {
            botoesAbas = new List<BotaoAbas>();
        }
        botoesAbas.Add(botao);
    }
    public void QuandoEntrar(BotaoAbas botao)
    {
        ResetarAbas();
        if (abaPrecionada == null || botao != abaPrecionada)
        {
            botao.fundoDaAba.color = abaPorCima.color;
        }
    }
    public void QuandoSair(BotaoAbas botao)
    {
        ResetarAbas();

    }
    public void QuandoSelecionar(BotaoAbas botao)
    {
        abaPrecionada = botao;
        ResetarAbas();
        botao.fundoDaAba.color = abaSelecionada.color;
         
    }
    public void ResetarAbas()
    {
        foreach(BotaoAbas botao in botoesAbas)
        {
            if(abaPrecionada != null && botao == abaPrecionada) { continue; }
            botao.fundoDaAba.color = abaIdle.color;
        }
    }
}
