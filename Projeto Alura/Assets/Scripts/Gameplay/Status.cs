using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaInicial = 100;
    public int Vida;
    public float Velocidade = 5;

    void Awake ()
    {
        Vida = VidaInicial;
    }

    private void Start()
    {
        
    }

    public void SalvaAVidaAtual()
    {
        PlayerPrefs.SetInt("VidaJogador", Vida);
    }

    public void SalvaAVidaInicial()
    {
        PlayerPrefs.SetInt("VidaJogador", VidaInicial);
    }

    public int PegarVidaAtual()
    {
        return PlayerPrefs.GetInt("VidaJogador");
    }
}
