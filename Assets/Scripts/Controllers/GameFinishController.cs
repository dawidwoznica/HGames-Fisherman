using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishController : MonoBehaviour
{
    private Animator _animmator;
    private AudioSource _gameFinishSound;
    public Image[] OwnedFishImages; // owned fish images
    public FishermanController FishermanController;
    public FishController FishController;
    public AccuracyController AccuracyController;
    public FishingRodController FishingRodController;
    public ProgressBarController ProgressBarController;
    public FloatController FloadController;


    void Awake()
    {
        _animmator = GetComponent<Animator>();
        _gameFinishSound = GetComponent<AudioSource>();
    }

    public void FadeOut()
    {
        _animmator.SetTrigger("GameFinished"); // start the animation for summary screen
        for (int i = 0; i < 3; i++)
        {
            OwnedFishImages[i].sprite = FishermanController.FishImages[i].sprite; // copy sprites to the summary screen
        }

        // turn off all the scripts
        FishermanController.enabled = false;
        FishController.enabled = false;
        AccuracyController.enabled = false;
        FishingRodController.enabled = false;
        ProgressBarController.enabled = false;
        FloadController.enabled = false;

        _gameFinishSound.Play();
    }
    
}
