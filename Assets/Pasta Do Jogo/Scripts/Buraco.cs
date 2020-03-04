using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    [SerializeField]
    private BoxCollider meuBox;
    void Start()
    {
        meuBox = this.GetComponent<BoxCollider>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
        }
    }
    public float QuantoAguaVaza(float quantaAgua)
    {
        float tempo = Time.deltaTime;

        quantaAgua = quantaAgua - tempo;

        return quantaAgua;

    }
}
