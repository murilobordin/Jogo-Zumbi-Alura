using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaJogador : MonoBehaviour, IMatavel, ICuravel
{

    private Vector3 direcao;
    [SerializeField]
    private LayerMask mascaraChao;
    [SerializeField]
    private GameObject textoGameOver;
    [SerializeField]
    private ControlaInterface scriptControlaInterface;
    private ControlaPontuação pontuacao;
    [SerializeField]
    private AudioClip somDeDano, somDeColeta;
    private MovimentoJogador meuMovimentoJogador;
    private AnimacaoPersonagem animacaoJogador;
    public Status statusJogador;
    [SerializeField]
    private UnityEvent aoTomarDano;
    [SerializeField]
    private UnityEvent aoAcabarAVida;

    private void Start()
    {
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        statusJogador = GetComponent<Status>();
        pontuacao = GameObject.FindObjectOfType(typeof(ControlaPontuação)) as ControlaPontuação;
    }

    // Update is called once per frame
    void Update()
    {
        
        animacaoJogador.Movimentar(this.meuMovimentoJogador.Direcao.magnitude);
    }

    void FixedUpdate()
    {
        meuMovimentoJogador.Movimentar(statusJogador.Velocidade);

        meuMovimentoJogador.RotacaoJogador();
    }

    public void TomarDano (int dano)
    {
        statusJogador.Vida -= dano;
        aoTomarDano.Invoke();
        if(statusJogador.Vida <= 0)
        {
            aoAcabarAVida.Invoke();
        }        
    }

    public void Morrer ()
    {
        scriptControlaInterface.GameOver();
    }

    public void CurarVida (int quantidadeDeCura)
    {
        statusJogador.Vida += quantidadeDeCura;
        ControlaAudio.instancia.PlayOneShot(somDeColeta);
        if (statusJogador.Vida > statusJogador.VidaInicial)
        {
            statusJogador.Vida = statusJogador.VidaInicial;
        }
        scriptControlaInterface.AtualizarSliderVidaJogador();
    }

    public void EfeitosDeDano()
    {
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(somDeDano);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PontoDeChegada")
        {
            scriptControlaInterface.PassouDeFase();
        }
    }
}
