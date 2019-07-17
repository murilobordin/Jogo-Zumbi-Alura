using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlaVolume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    public void MudarVolumeMusica(float volume)
    {
        this.mixer.SetFloat("VolumeMusica", volume);
    }

    public void MudarVolumeSfx(float volume)
    {
        this.mixer.SetFloat("VolumeSFX", volume);
    }
}
