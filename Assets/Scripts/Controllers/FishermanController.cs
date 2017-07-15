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
    public GameFinishController GameFinishController;
    public GameObject ProgressBar;
    public GameObject FishingPanel;
    public Image[] FishImages;
    public Text InfoText;
    private int _fishOwned;


    void Start()
    {
        _fishOwned = GameManager.FishermanManager.StartingNumberOfFish;
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

    public void GetFish()
    {
        StopFishing();
        FishController.DrawFish();
        FishImages[_fishOwned].gameObject.SetActive(true);
        FishImages[_fishOwned].sprite = FishController.Fish;
        
        _fishOwned++;

        if (_fishOwned == 3)
        {
            GameFinishController.FinishTheGame();
        }
    }

    void StartFishing()
    {
        ProgressBarController.ResetProgress();
        _isFishing = true;
        InfoText.text = GameManager.FishermanManager.UseArrowText;
        FloatController.ShowFloat();
        FishingRodController.Throw();
        StartCoroutine(WaitForWish());
    }

    public void StopFishing()
    {
        _isFishing = false;
        InfoText.text = GameManager.FishermanManager.PressSpaceText;
        FloatController.HideFloat();
        FishingRodController.ReelIn();
        ProgressBar.SetActive(false);
        FishingPanel.SetActive(false);
    }

    IEnumerator WaitForWish()
    {
        int randomTime = Random.Range(1, 5);
        yield return new WaitForSeconds(randomTime);
        ProgressBar.SetActive(true);
        FishingPanel.SetActive(true);
    }
}
