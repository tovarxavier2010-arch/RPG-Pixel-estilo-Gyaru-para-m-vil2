using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Gestor de audio (música y efectos de sonido)
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioMixerGroup masterGroup;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip mainTheme;
    [SerializeField] private AudioClip battleTheme;
    [SerializeField] private AudioClip victoryTheme;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMasterVolume(float volume)
    {
        masterGroup.audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void PlayAttackSFX()
    {
        Debug.Log("Sonido de ataque");
    }

    public void PlayHealSFX()
    {
        Debug.Log("Sonido de curación");
    }

    public void PlayVictorySFX()
    {
        PlayMusic(victoryTheme, false);
    }
}