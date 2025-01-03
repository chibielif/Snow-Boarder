using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool SFXHasPlayed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !SFXHasPlayed){
            SFXHasPlayed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0); //we're loading the scene with index number 0 = Level1
    }

}
