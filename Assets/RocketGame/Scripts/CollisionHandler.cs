using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _levelLoadDelay = 2f;
    [SerializeField] private AudioClip _success;
    [SerializeField] private AudioClip _crash;
    [SerializeField] private ParticleSystem _successParticles;
    [SerializeField] private ParticleSystem _crashParticles;
    private AudioSource _audioSource;
    private bool isTransitioning;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        isTransitioning = false; // Başlangıçta isTransitioning değeri false olarak ayarlanmalı
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly.");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("You picked up fuel.");
                break;
            default:
                Debug.Log("default");
                StartCrashSequence();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_crash);
        _crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", _levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_success);
        _successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", _levelLoadDelay);
    }
}
