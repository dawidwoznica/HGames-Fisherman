using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyController : MonoBehaviour
{
    private RectTransform _accuracyBarRect;
    private bool _isTriggered;
    public ProgressBarController ProgressBarController;


    void Awake()
    {
        _accuracyBarRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        /// <summary>
        /// In the Update function:
        /// Setting UpArrow to move slowly 'accuracy' bar to the max const value. ( I put there '* 200' because it was moving too slow).
        /// Situation looks the same in the DownArrow case.
        /// 
        /// and if isn't triggered then DeleteProgress()
        /// </summary>

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_accuracyBarRect.anchoredPosition.y < 164)
                _accuracyBarRect.anchoredPosition += Vector2.up * Time.deltaTime * 200;                    
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_accuracyBarRect.anchoredPosition.y > -64)
                _accuracyBarRect.anchoredPosition += Vector2.down * Time.deltaTime * 200; 
        }

        if (!_isTriggered)
        {
            ProgressBarController.DeleteProgress();
        }
    }

    void OnTriggerStay2D(Collider2D other) // while 'fish' is in the 'accuracy bar' 
    {
        _isTriggered = true; // set trigger on true
        ProgressBarController.AddProgress(); // and AddProgress() to on the slider (progress bar)
    }

    void OnTriggerExit2D(Collider2D other) // while is not
    {
        _isTriggered = false; // set trigger to false and DeleteProgress() in Update()
    }

}
