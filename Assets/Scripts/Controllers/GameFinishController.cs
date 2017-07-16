using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishController : MonoBehaviour
{
    private Animator _animmator;
    public Image[] OwnedFishImages; // owned fish images
    public FishermanController FishermanController;

    void Awake()
    {
        _animmator = GetComponent<Animator>();
    }

    public void FinishTheGame()
    {
        _animmator.SetTrigger("GameFinished"); // start the animation for summary screen
        for (int i = 0; i < 3; i++)
        {
            OwnedFishImages[i].sprite = FishermanController.FishImages[i].sprite; // copy sprites to the summary screen
        }
    }
    
}
