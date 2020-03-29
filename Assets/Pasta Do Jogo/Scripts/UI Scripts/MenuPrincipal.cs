using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Button jogar, sair;
    public Button sim, nao;

    private void Start()
    {

        jogar = GameObject.Find("Play").GetComponent<Button>();
        sair = GameObject.Find("Sair").GetComponent<Button>();
    }
    private void Update()
    {
        jogar.onClick.AddListener(Jogar);
        sair.onClick.AddListener(Confirmacao);

    }
    public void Jogar()
    {
        SceneManager.LoadScene("JogoTeste");
    }
    public void Confirmacao()
    {
        sim = GameObject.Find("Sim").GetComponent<Button>();
        nao = GameObject.Find("Nao").GetComponent<Button>();
    }
    public void Sair()
    {
        Application.Quit();
    }
}
