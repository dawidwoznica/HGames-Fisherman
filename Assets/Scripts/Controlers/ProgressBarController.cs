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


	void Start ()
	{
	    _progressBar = GetComponent<Slider>();
	}


    public void AddProgress()
    {
        _progressBar.value += 0.002f;
        SetProgressColor();
    }

    public void DeleteProgress()
    {
        _progressBar.value -= 0.001f;
        SetProgressColor();
    }

    void SetProgressColor()
    {
        FillImage.color = Color.Lerp(NoProgressColor, FullProgressColor, _progressBar.value / MaxProgressBarValue);
    }

    
}
