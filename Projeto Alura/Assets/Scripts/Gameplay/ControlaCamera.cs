using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

    private GameObject jogador;
    private Vector3 distCompensar;

	// Use this for initialization
	void Start () {
        jogador = GameObject.FindWithTag("Jogador");
        distCompensar = transform.position - jogador.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = jogador.transform.position + distCompensar;
	}
}
