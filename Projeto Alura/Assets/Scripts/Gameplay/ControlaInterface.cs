using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour{

    private ControlaJogador scriptControlaJogador;
    private ControlaPontuação scriptControlaPontuacao;
    public Slider SliderVidaJogador;
    [SerializeField]
    private int quantidadeDeZumbisMortos;
    [SerializeField]
    private Text TextoQuantidadeDeZumbisMortos;
    public Text TextoChefeAparece;

	// Use this for initialization
	void Start () {
        scriptControlaJogador = GameObject.FindWithTag("Jogador")
                                .GetComponent<ControlaJogador>();
        scriptControlaPontuacao = GameObject.FindObjectOfType(typeof(ControlaPontuação)) as ControlaPontuação;

        SliderVidaJogador.maxValue = scriptControlaJogador.statusJogador.Vida;
        AtualizarSliderVidaJogador();
        Time.timeScale = 1;
        PegarDados();
    }

    private void Update()
    {
        if(scriptControlaPontuacao==null)
            scriptControlaPontuacao = GameObject.FindObjectOfType(typeof(ControlaPontuação)) as ControlaPontuação;
    }

    private void PegarDados()
    {
        if(SceneManager.GetActiveScene().name == "game2")
        {
            int vidaSalva = scriptControlaJogador.statusJogador.PegarVidaAtual();
            scriptControlaJogador.statusJogador.Vida = vidaSalva;
            AtualizarSliderVidaJogador();
            AtualizarQuantidadeDeZumbisMortos();
        }
        else
        {
            scriptControlaJogador.statusJogador.SalvaAVidaInicial();
        }
    }

    public void AtualizarSliderVidaJogador ()
    {
        SliderVidaJogador.value = scriptControlaJogador.statusJogador.Vida;
    }

    public void AtualizarQuantidadeDeZumbisMortos()
    {
        quantidadeDeZumbisMortos = scriptControlaPontuacao.AtualizarPontuacao();
        TextoQuantidadeDeZumbisMortos.text = string.Format("x {0}", quantidadeDeZumbisMortos);
    }

    public void GameOver ()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void PassouDeFase()
    {
        scriptControlaJogador.statusJogador.SalvaAVidaAtual();
        scriptControlaPontuacao.GanhaBonus();
        SceneManager.LoadScene("game2");
    }


    public void AparecerTextoChefeCriado ()
    {
        StartCoroutine(DesaparecerTexto(2, TextoChefeAparece));
    }

    IEnumerator DesaparecerTexto (float tempoDeSumico, Text textoParaSumir)
    {
        textoParaSumir.gameObject.SetActive(true);
        Color corTexto = textoParaSumir.color;
        corTexto.a = 1;
        textoParaSumir.color = corTexto;
        yield return new WaitForSeconds(1);
        float contador = 0;
        while (textoParaSumir.color.a > 0)
        {
            contador += Time.deltaTime / tempoDeSumico;
            corTexto.a = Mathf.Lerp(1, 0, contador);
            textoParaSumir.color = corTexto;
            if(textoParaSumir.color.a <= 0)
            {
                textoParaSumir.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
