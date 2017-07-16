using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    private Slider _progressBar;
    public Image FillImage;
    public FishermanController FishermanController;


	void Awake ()
	{
	    _progressBar = GetComponent<Slider>();
	}

    void Update()
    {
        if (_progressBar.value == GameManager.ProgressBarManager.MaxProgressValue) // if progress bar value reach the MaxProgressValue
        {
            FishermanController.GetFish(); // then fisherman will get the fish ;)
        }
    }

    public void AddProgress()
    {
        _progressBar.value +=GameManager.ProgressBarManager.ProgressPossitiveValue; // increase the progress by a specified value set in ProgressBarManager

        SetProgressColor();
    }

    public void DeleteProgress()
    {
        _progressBar.value -= GameManager.ProgressBarManager.ProgressNegativeValue; // same but reduce the progress

        SetProgressColor();
    }

    void SetProgressColor()
    {
        // setting the color for progress bar
        FillImage.color = Color.Lerp(GameManager.ProgressBarManager.NoProgressColor, GameManager.ProgressBarManager.FullProgressColor, _progressBar.value / GameManager.ProgressBarManager.MaxProgressValue);
        // depends on the progress bar filling
        // starting from NoProgressColor ending at FullProgressColor, set in ProgressBarManager
    }

    public void ResetProgress()
    {
        _progressBar.value = GameManager.ProgressBarManager.StartingValue; // reset progress to starting value set in ProgressBarManager
    }

}
