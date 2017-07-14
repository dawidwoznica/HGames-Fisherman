using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class FishermanController : MonoBehaviour
{
    private bool _isFishing;
    public FloatController FloatController;
    public FishingRodController FishingRodController;
    public FishController FishController;
    public ProgressBarController ProgressBarController;
    public GameObject FishingUI;
    public Image[] FishImages;
    private int _fishOwned = 0;


    void Start()
    {
        StopFishing();
        foreach (Image image in FishImages)
        {
            image.gameObject.SetActive(false);
        }
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
        FishImages[_fishOwned].gameObject.SetActive(true);
        FishImages[_fishOwned].sprite = FishController.Fish;
        
        _fishOwned++;
    }

    void StartFishing()
    {
        ProgressBarController.ResetProgress();
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
        if (_fishOwned == 3)
        {
            // wygrana
        }
    }

    IEnumerator WaitForWish()
    {
        int randomTime = Random.Range(1, 5);
        yield return new WaitForSeconds(randomTime);
        FishingUI.SetActive(true);
    }
}
