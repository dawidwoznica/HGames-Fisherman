using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishController : MonoBehaviour
{
    private Animator _anim;
    public FishermanController FishermanController;
    public Image[] OwnedFishImages;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    public void FinishTheGame()
    {
        _anim.SetTrigger("GameOver");
        for (int i = 0; i < 3; i++)
        {
            OwnedFishImages[i].sprite = FishermanController.FishImages[i].sprite;
        }
    }
    
}
