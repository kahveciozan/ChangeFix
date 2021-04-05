using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip correctSound, wrongSound, buttonSound;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void CorrectSound()
    {
        soundFX.clip = correctSound;
        soundFX.Play();
    }

    public void WrongSound()
    {
        soundFX.clip = wrongSound;
        soundFX.Play();
    }

    // Sound of Right and Left Buttons
    public void ButtonSound()
    {
        soundFX.clip = buttonSound;
        soundFX.Play();
    }


}
