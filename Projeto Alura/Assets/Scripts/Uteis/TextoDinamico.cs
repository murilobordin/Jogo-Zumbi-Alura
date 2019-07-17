using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDinamico : MonoBehaviour
{
    private Text texto;

    void Start()
    {
        texto = GetComponent<Text>();
    }

    
    public void AtualizarTexto(string novoTexto)
    {
        texto.text = novoTexto;
    }
}
