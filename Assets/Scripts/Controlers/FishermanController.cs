using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanController : MonoBehaviour
{


    private bool _isFishing;
    public FloatController _floatController;
    public FishingRodController _fishingRodController;

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
            _floatController.ShowFloat();
            _fishingRodController.Throw();
        }

	    if (Input.GetKeyDown(KeyCode.Escape) && _isFishing)
	    {
            _isFishing = false;
            _floatController.HideFloat();
            _fishingRodController.ReelIn();
        }
	}
}
