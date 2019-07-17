using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.ObjectModel;
using System;

public class ControlaRanking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";
    private string caminhoParaSalvar;
    [SerializeField]
    private List<Colocado> listaColocados;

    private void Awake()
    {
        this.caminhoParaSalvar = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        if (File.Exists(caminhoParaSalvar))
        {
            var textoJson = File.ReadAllText(caminhoParaSalvar);
            JsonUtility.FromJsonOverwrite(textoJson, this);
        }
        else
        {
            listaColocados = new List<Colocado>();
        }
    }

    public void AlterarNome(string novoNome, Guid id)
    {
        foreach(var item in this.listaColocados)
        {
            if (item.id == id)
            {
                item.nome = novoNome;
                break;
            }
        }
        this.SalvarRanking();
    }

    public Guid AdicionarPontos(int ponto, string nome)
    {
        var id = Guid.NewGuid();
        var colocado = new Colocado(ponto, nome, id);
        this.listaColocados.Add(colocado);
        this.listaColocados.Sort();
        this.SalvarRanking();
        return id;
    }

    public ReadOnlyCollection<Colocado> PegarColocados()
    {
        return this.listaColocados.AsReadOnly();
    }

    private void SalvarRanking()
    {
        var textoJson = JsonUtility.ToJson(this);
        File.WriteAllText(caminhoParaSalvar, textoJson);
    }
}

[System.Serializable]
public class Colocado:IComparable
{
    public int ponto;
    public string nome;
    public Guid id;

    public Colocado(int ponto, string nome, Guid id)
    {
        this.ponto = ponto;
        this.nome = nome;
        this.id = id;
    }

    public int CompareTo(object obj)
    {
        var outroObjeto = obj as Colocado;
        return outroObjeto.ponto.CompareTo(this.ponto);
    }
}
