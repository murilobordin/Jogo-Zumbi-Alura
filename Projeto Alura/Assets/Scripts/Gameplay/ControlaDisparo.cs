using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaDisparo : MonoBehaviour
{
    private float coolDown;
    [SerializeField]
    private float tempoParaDisoarar;

    public ReservaExtensivel reservaDeBalas;
    public GameObject CanoDaArma;
    [SerializeField]
    private AudioClip somDoTiro;

    private void Update()
    {
        if (coolDown >= 0)
            coolDown -= Time.deltaTime;
    }

    public void Atirar()
    {
        if (this.reservaDeBalas.TemObjeto() && coolDown <= 0)
        {
            var bala = this.reservaDeBalas.PegarObjeto();
            bala.transform.position = CanoDaArma.transform.position;
            bala.transform.rotation = CanoDaArma.transform.rotation;
            ControlaAudio.instancia.PlayOneShot(somDoTiro);
            coolDown = tempoParaDisoarar;
        }
    }
}
