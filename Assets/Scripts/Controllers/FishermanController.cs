using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class FishermanController : MonoBehaviour
{
    private int _fishOwned;
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


    void Start()
    {
        _fishOwned = GameManager.FishermanManager.StartingNumberOfFish;
        StopFishing();
        foreach (Image image in FishImages) // Deactive all fish images on UI
        {
            image.gameObject.SetActive(false);
        }
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) // fishing stance controlled by Space
        {
            if(_isFishing) // if is fishing the stop it
                StopFishing();
            else if (!_isFishing) // else start fishing
                StartFishing();    
        }
	}

    public void GetFish()
    {
        StopFishing(); // set fisherman in standing stance
        FishController.DrawFish(); // then draw random fish
        FishImages[_fishOwned].gameObject.SetActive(true); // turn on the UI image for the fish
        FishImages[_fishOwned].sprite = FishController.Fish; // and put sprite in it
        
        _fishOwned++; // add owned fish

        if (_fishOwned == 3) // and if there are 3 of them, finish the game
        {
            GameFinishController.FinishTheGame(); // finish the game
        }
    }

    void StartFishing()
    {
        /// <summary>
        /// Fishing stance.
        /// </summary>
        ProgressBarController.ResetProgress();
        _isFishing = true;
        InfoText.text = GameManager.FishermanManager.UseArrowText; // change player info text
        FloatController.ShowFloat(); // show the float
        FishingRodController.Throw(); // and rotate the fishing rod
        StartCoroutine(WaitForWish()); 
    }

    public void StopFishing()
    {
        /// <summary>
        /// Standing stance.
        /// </summary>
        _isFishing = false;
        InfoText.text = GameManager.FishermanManager.PressSpaceText;
        FloatController.HideFloat(); // hide float
        FishingRodController.ReelIn(); // put fishing rod to the starting position
        ProgressBar.SetActive(false); // hide progress bard
        FishingPanel.SetActive(false); // and fishing panel
    }

    IEnumerator WaitForWish()
    {
        int randomTime = Random.Range(1, 6); // draw random wait time value 
        yield return new WaitForSeconds(randomTime); // wait for the fish
        ProgressBar.SetActive(true); // then show progress bar
        FishingPanel.SetActive(true); // and fishing panel
    }

}
