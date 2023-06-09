using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] audioSources;
    public AudioClip[] audioClips;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        // Singleton Pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void PlayClip(int clipIndex, int sourceIndex)
    {
        if (clipIndex < 0 || clipIndex >= audioClips.Length ||
            sourceIndex < 0 || sourceIndex >= audioSources.Length)
        {
            Debug.LogWarning("AudioManager: Invalid index");
            return;
        }

        AudioSource source = audioSources[sourceIndex];
        source.clip = audioClips[clipIndex];
        source.Play();

    }

    public void PlayMusicClip(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= audioClips.Length)
        {
            Debug.LogWarning("AudioManager: Invalid index");
            return;
        }

        audioSources[1].clip = audioClips[clipIndex];
        audioSources[1].Play();
    }



    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSources[1].isPlaying)
        {
            audioSources[1].Stop();
        }
    }

    public void PauseMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    public void UnpauseMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.UnPause();
        }
    }

}
