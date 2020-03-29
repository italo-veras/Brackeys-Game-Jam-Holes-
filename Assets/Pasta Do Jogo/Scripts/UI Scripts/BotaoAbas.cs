using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class BotaoAbas : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
    public GrupoDeAbas grupoDeAbas;

    public Image fundoDaAba;

    public void OnPointerClick(PointerEventData eventData)
    {
        grupoDeAbas.QuandoSelecionar(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        grupoDeAbas.QuandoEntrar(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        grupoDeAbas.QuandoSair(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        fundoDaAba = GetComponent<Image>();
        grupoDeAbas.Inscrever(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
