using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    private Slider _progressBar;
    public Color FullProgressColor = Color.green;
    public Color NoProgressColor = Color.red;
    public Image FillImage;
    public int MaxProgressBarValue = 1;
    public FishermanController FishermanController;


	void Awake ()
	{
	    _progressBar = GetComponent<Slider>();
	}

    void Update()
    {
        if (_progressBar.value == MaxProgressBarValue)
        {
            FishermanController.Jerk();
        }
    }

    public void AddProgress()
    {
        _progressBar.value += 0.002f;
        SetProgressColor();
    }

    public void DeleteProgress()
    {
        _progressBar.value -= 0.003f;
        SetProgressColor();
    }

    void SetProgressColor()
    {
        FillImage.color = Color.Lerp(NoProgressColor, FullProgressColor, _progressBar.value / MaxProgressBarValue);
    }

    public void ResetProgress()
    {
        _progressBar.value = 0;
    }
}
