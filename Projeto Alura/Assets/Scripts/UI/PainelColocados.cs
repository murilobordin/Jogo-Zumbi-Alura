using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelColocados : MonoBehaviour
{
    [SerializeField]
    private ControlaRanking ranking;
    [SerializeField]
    private GameObject prefabColocado;

    void Start()
    {
        var listaColocado = ranking.PegarColocados();
        for(int i = 0; i <= listaColocado.Count; i++)
        {
            if (i >= 5) break;
            var colocado = GameObject.Instantiate(prefabColocado, this.transform);
            colocado.GetComponent<MontaColocacao>().ConfiguraColocado(i, listaColocado[i].nome, listaColocado[i].ponto);
        }
    }
    
}
