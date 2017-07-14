using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FishermanController : MonoBehaviour
{


    private bool _isFishing;
    public FloatController FloatController;
    public FishingRodController FishingRodController;
    public GameObject FishingUI;

    // Use this for initialization
    void Start ()
	{
	    _isFishing = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !_isFishing)
        {
            _isFishing = true;
            FloatController.ShowFloat();
            FishingRodController.Throw();
            FishingUI.SetActive(true);
        }

	    if (Input.GetKeyDown(KeyCode.Escape) && _isFishing)
	    {
            _isFishing = false;
            FloatController.HideFloat();
            FishingRodController.ReelIn();
            FishingUI.SetActive(false);
        }
	}
}
