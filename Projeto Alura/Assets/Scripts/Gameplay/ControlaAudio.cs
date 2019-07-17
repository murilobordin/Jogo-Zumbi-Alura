using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    private AudioSource meuAudioSource;
    [HideInInspector]
    public static AudioSource instancia;

    void Awake ()
    {
        meuAudioSource = GetComponent<AudioSource>();
        instancia = meuAudioSource;
    }
}
