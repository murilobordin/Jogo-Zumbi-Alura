using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MontaColocacao : MonoBehaviour
{
    [SerializeField]
    private Text textoColocacao;
    [SerializeField]
    private Text textoNome;
    [SerializeField]
    private Text textoPontuacao;

    public void ConfiguraColocado(int colocacao, string nome, int pontuacao)
    {
        textoColocacao.text = colocacao.ToString();
        textoNome.text = nome;
        textoPontuacao.text = pontuacao.ToString();
    }
}
