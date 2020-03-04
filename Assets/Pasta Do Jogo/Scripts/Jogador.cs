using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Vector3 inputMovimento;
    int velocidadeDeMovimento = 5;
    [SerializeField]
    Rigidbody meuRigibody;
    public Collider buraco;
  

    void Start()
    {
        meuRigibody = GetComponent<Rigidbody>();

    }
   
    void Update()
    {
        Movimentar();
       
    }

    private void FixedUpdate()
    {
        meuRigibody.MovePosition(transform.position + (new Vector3(inputMovimento.x, 0, inputMovimento.z) * velocidadeDeMovimento * Time.deltaTime));
    }

    public void Movimentar()
    {
        inputMovimento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        transform.LookAt(transform.position + new Vector3(inputMovimento.x, 0, inputMovimento.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        AdicionarBuraco(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FicarParado());
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RemoverBuraco(other);
    }
    void AdicionarBuraco(Collider outroCollider)
    {
        if(outroCollider.tag == "Buraco")
        {
            buraco = outroCollider.GetComponent<Collider>();
           
        }
    }
    void RemoverBuraco(Collider outroCollider)
    {
        if (outroCollider.tag == "Buraco")
        {
            buraco = null;
        }
        
    }
    IEnumerator FicarParado()
    {
        
        velocidadeDeMovimento = 0;
        yield return new WaitForSeconds(2.0f);
       
        velocidadeDeMovimento = 5;
    }
}
