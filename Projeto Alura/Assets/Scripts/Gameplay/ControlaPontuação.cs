using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPontuação : MonoBehaviour
{
    public int pontuacao;
    [SerializeField]
    private int bonus = 15;

    public void Pontuar()
    {
        pontuacao++;
    }

    public int AtualizarPontuacao()
    {
        return pontuacao;
    }

    public void GanhaBonus()
    {
        pontuacao += bonus;
    }

    public void ZeraPontuacao()
    {
        pontuacao = 0;
    }
}
