using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMove : MonoBehaviour
{

    public float velocidade;
    public float min;
    public float max;
    public float espera;
    public float velocidade2 = 1f;
    public float limite;
    public float retorno;


    void Start()
    {
        StartCoroutine(Move(max));

    }

    IEnumerator Move(float destino)
    {
        while (Mathf.Abs(destino - transform.localPosition.y) > 0.2f)
        {
            Vector3 direcao = (destino == max) ? Vector3.up : Vector3.down;
            Vector3 velocidadeVetorial = direcao * velocidade;
            transform.localPosition = transform.localPosition + velocidadeVetorial * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(espera);

            destino = (destino == max) ? min : max;
            StartCoroutine(Move(destino));

           
        }

    void Update()
    {

        Vector3 velocidadeVetorial = Vector3.left * velocidade;
        transform.position = transform.position + velocidadeVetorial * Time.deltaTime;

        if (transform.position.x <= limite)
        {
            transform.position = new Vector3(retorno, transform.position.y, transform.position.z);

        }

    }

}





