using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource audioSourceHighClick;
    [SerializeField] AudioSource audioSourceLowClick;
    [SerializeField] AudioSource audioSourceEndMatchTone;
    [SerializeField] AudioSource audioSourceMaterReset;

    [Header("Audio Mixer")]
    [SerializeField] AudioMixer audioMixer;

    [Header ("Toggle Mute Button")]
    [SerializeField] Toggle muted;

    private float volume;

    private void Start()
    {
        muted.isOn = false;
    }

    public void PlayHighClick() { audioSourceHighClick.Play(); }

    public void PlayLowClick() { audioSourceLowClick.Play(); }

    public void PlayEndMatchTone() { audioSourceEndMatchTone.Play(); }

    public void PlayMasterResetTone() { audioSourceMaterReset.Play(); }

    public void MuteMasterVolume()
    {
        audioMixer.GetFloat("MasterVolume", out volume);
        if (muted.isOn) { audioMixer.SetFloat("MasterVolume", -80); }
        else if (!muted.isOn){ audioMixer.SetFloat("MasterVolume", 0); }
    }
}
