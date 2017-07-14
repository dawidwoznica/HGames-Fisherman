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

    void Start()
    {
        StopFishing();
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
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
        StartCoroutine(WaitForWish());
    }

    public void StopFishing()
    {
        _isFishing = false;
        FloatController.HideFloat();
        FishingRodController.ReelIn();
        FishingUI.SetActive(false);
    }

    IEnumerator WaitForWish()
    {
        int randomTime = Random.Range(1, 5);
        yield return new WaitForSeconds(randomTime);
        FishingUI.SetActive(true);
    }
}
