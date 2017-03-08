using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject obstaculo;
    public float espera;
    public float tempoDestruicao;
    public static GameController instancia = null;

    void Awayke ()
    {
        if (instancia == null)
        {
            instancia = this;
        }

        else if (instancia != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


	void Start () {
        StartCoroutine(GerarObstaculos());
	}

    IEnumerator GerarObstaculos()
    {
        while (true)
        {
            Vector3 pos = new Vector3(3f, Random.Range(0.07f, 0.016f), 0f);
            GameObject obj = Instantiate(obstaculo, pos, Quaternion.identity) as GameObject;
            Destroy(obj, tempoDestruicao);
            yield return new WaitForSeconds(espera);
        }
    }

	void Update () {
		
	}
}
