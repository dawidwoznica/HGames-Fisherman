using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FishermanController : MonoBehaviour
{
    private bool _isFishing;
    public FloatController FloatController;
    public FishingRodController FishingRodController;
    public FishController FishController;
    public GameObject FishingUI;


	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !_isFishing)
        {
            if(_isFishing)
                StopFishing();
            else if (!_isFishing)
                StartFishing();    
        }
	}

    public void Jerk()
    {
        StopFishing();
        FishController.GetFish();

    }

    void StartFishing()
    {
        _isFishing = true;
        FloatController.ShowFloat();
        FishingRodController.Throw();
        FishingUI.SetActive(true);
    }

    public void StopFishing()
    {
        _isFishing = false;
        FloatController.HideFloat();
        FishingRodController.ReelIn();
        FishingUI.SetActive(false);
    }
}
