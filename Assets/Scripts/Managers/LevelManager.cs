using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public FishermanController FishermanController;


    public void PrepareGame()
    {
        FishermanController.StopFishing(); 
    }
}
