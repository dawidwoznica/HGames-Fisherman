using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
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
        if (_progressBar.value == GameManager.ProgressBarManager.MaxProgressValue)
        {
            FishermanController.GetFish();
        }
    }

    public void AddProgress()
    {
        _progressBar.value +=GameManager.ProgressBarManager.ProgressPossitiveValue;
        SetProgressColor();
    }

    public void DeleteProgress()
    {
        _progressBar.value -= GameManager.ProgressBarManager.ProgressNegativeValue;
        SetProgressColor();
    }

    void SetProgressColor()
    {
        FillImage.color = Color.Lerp(GameManager.ProgressBarManager.NoProgressColor, GameManager.ProgressBarManager.FullProgressColor, _progressBar.value / GameManager.ProgressBarManager.MaxProgressValue);
    }

    public void ResetProgress()
    {
        _progressBar.value = GameManager.ProgressBarManager.StartingValue;
    }
}
