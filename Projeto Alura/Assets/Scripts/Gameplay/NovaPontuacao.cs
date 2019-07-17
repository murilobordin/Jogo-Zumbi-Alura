using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovaPontuacao : MonoBehaviour
{
    [SerializeField]
    private Text textoPontuacao;
    [SerializeField]
    private Text textoNome;

    [SerializeField]
    private ControlaPontuação pontuacao;
    [SerializeField]
    private ControlaRanking ranking;
    private Guid id;
    
    void Start()
    {
        int pontuacaoAtual = PegarPontuacao();
        string nomeSalvo = GetNome();
        textoNome.text = nomeSalvo;
        textoPontuacao.text = pontuacaoAtual.ToString();
        id = ranking.AdicionarPontos(pontuacaoAtual, nomeSalvo);
    }

    private string GetNome()
    {
        if (PlayerPrefs.HasKey("UltimoNome"))
        {
            return PlayerPrefs.GetString("UltimoNome");
        }
        return "nome";
    }

    private int PegarPontuacao()
    {
        pontuacao = GameObject.FindObjectOfType(typeof(ControlaPontuação)) as ControlaPontuação;
        int pontuacaoAtual = -1;
        if (pontuacao != null)
        {
            pontuacaoAtual = pontuacao.AtualizarPontuacao();
        }

        return pontuacaoAtual;
    }

    public void AlteraNome(string nome)
    {
        ranking.AlterarNome(nome, this.id);
        PlayerPrefs.SetString("UltimoNome", nome);
    }
}
