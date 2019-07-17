using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJogo : MonoBehaviour
{
    public void PausaOJogo()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RetornaOJogo()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    
    public void VoltarParaOMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
