using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaMenuRanking : ControlaMenu
{
    public void ReiniciarJogo()
    {
        StartCoroutine(MudarCena("game1"));
    }

    public void VoltaParaMenu()
    {
        StartCoroutine(MudarCena("menu"));
    }
}
