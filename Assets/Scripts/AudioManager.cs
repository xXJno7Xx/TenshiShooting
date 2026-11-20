using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        //_audioSource.Play();
        //Debug.Log("SOUND");
    }

    public void StopMusic()
    {
        _audioSource.Stop();
        //Debug.Log("SOUND");
    }
}
