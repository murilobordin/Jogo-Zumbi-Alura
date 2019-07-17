using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    
    void Awake()
    {
        var outrosObjetos = GameObject.FindGameObjectsWithTag(this.tag);
        foreach(var instancia in outrosObjetos)
        {
            if (instancia != this.gameObject)
            {
                GameObject.Destroy(instancia.gameObject);
            }
        }
    }
}
