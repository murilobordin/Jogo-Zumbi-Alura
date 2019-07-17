using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{

    
    private enum ARMA { PISTOLA,MPSMG}
    [SerializeField]
    private ARMA arma;
    [SerializeField]
    private ControlaDisparo[] armas;
    private ControlaDisparo armaAtiva;
    [SerializeField]
    public GameObject BotaoArma;

    private void Start()
    {
        armaAtiva = armas[(int)arma];

        #if UNITY_ANDROID
                BotaoArma.SetActive(true);
        #endif
    }
    private void Update()
    {
        var toquesNaTela = Input.touches;
        foreach(var toque in toquesNaTela)
        {
            if(toque.phase == TouchPhase.Began)
            {
                armaAtiva.Atirar();
            }
        }
        TrocaStatus();
    }

    void TrocaArma(ARMA status)
    {
        arma = status;
        armaAtiva = armas[(int)status];
    }

    public void TrocaStatus()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (arma == ARMA.PISTOLA)
            {
                TrocaArma(ARMA.MPSMG);
                armas[(int)ARMA.PISTOLA].gameObject.SetActive(false);
                armas[(int)ARMA.MPSMG].gameObject.SetActive(true);
            }
            else if(arma == ARMA.MPSMG)
            {
                TrocaArma(ARMA.PISTOLA);
                armas[(int)ARMA.PISTOLA].gameObject.SetActive(true);
                armas[(int)ARMA.MPSMG].gameObject.SetActive(false);
            }
        }
    }

    public void BotaoDaArma()
    {
        if (arma == ARMA.PISTOLA)
        {
            TrocaArma(ARMA.MPSMG);
            armas[(int)ARMA.PISTOLA].gameObject.SetActive(false);
            armas[(int)ARMA.MPSMG].gameObject.SetActive(true);
        }
        else if (arma == ARMA.MPSMG)
        {
            TrocaArma(ARMA.PISTOLA);
            armas[(int)ARMA.PISTOLA].gameObject.SetActive(true);
            armas[(int)ARMA.MPSMG].gameObject.SetActive(false);
        }
    }

    
}
