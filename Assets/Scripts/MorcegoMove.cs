using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoMove : MonoBehaviour
{

    public float velocidadeHorizontal;
    public float min;
    public float max;
    public float espera;
    public float velocidadeVertical = 1f;


    void Start()
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            StartCoroutine(Move(max));
        }
        else
        {
            StartCoroutine(Move(min));
        }

    }

    IEnumerator Move(float destino)
    {
        while (Mathf.Abs(destino - transform.position.y) > 0.2f)
        {
            Vector3 direcao = (destino == max) ? Vector3.up : Vector3.down;
            Vector3 velocidadeVetorial = direcao * velocidadeVertical;
            transform.position = transform.position + velocidadeVetorial * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(espera);

        destino = (destino == max) ? min : max;
        StartCoroutine(Move(destino));

           
    }

    void Update()
    {
        Vector3 velocidadeVetorial = Vector3.left * velocidadeHorizontal;
        transform.localPosition = transform.localPosition + velocidadeVetorial * Time.deltaTime;
    }

}





