using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _timeTurnVolume;

    private AudioSource _audioSource;
    private Coroutine runCoroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void PlayAudio()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public void SignalizationOn(bool isEntered, bool isDoorOpened)
    {
        if(isEntered || isDoorOpened)
        {
            PlayAudio();
            _audioSource.loop = true;
            RunChangeVolume(StartCoroutine(ChangeVolume(1)));
        }
        else
        {
            RunChangeVolume(StartCoroutine(ChangeVolume(0)));
            _audioSource.loop = false;
        }
    }

    private IEnumerator ChangeVolume(int target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, Time.deltaTime / _timeTurnVolume);
            yield return null;
        }
    }

    private void RunChangeVolume(Coroutine coroutine)
    {
        if(runCoroutine != null)
            StopCoroutine(runCoroutine);
        runCoroutine = coroutine;
    }
    
}
