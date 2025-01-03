using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }

        if(other.tag == "Player"){
            if (!finishEffect.isPlaying) { finishEffect.Play(); }
            if (!audioSource.isPlaying)  { audioSource.Play(); }

        Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0); //we're loading the scene with index number 0 = Level1
    }
}
