using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyController : MonoBehaviour
{
    private RectTransform _accuracyBarRect;
    private bool _isTriggered;
    private bool _upBlocked;
    private bool _downBlocked;
    public ProgressBarController ProgressBarController;


    void Awake()
    {
        _accuracyBarRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        /// <summary>
        /// In the Update function:
        /// Setting UpArrow to move slowly 'accuracy' bar up( I put there '* 200' because it was moving too slow), limited by the boundary collision.
        /// Situation looks the same in the DownArrow case.
        /// 
        /// and if isn't triggered then DeleteProgress()
        /// </summary>

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!_upBlocked)
                _accuracyBarRect.anchoredPosition += Vector2.up * Time.deltaTime * 200;                    
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!_downBlocked)
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


    /// <summary>
    /// Both OnCollision functions switch values of bools if collider hits one of the boundaries.
    /// </summary>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UpperBoundary")
            _upBlocked = true;
        else if (other.gameObject.tag == "LowerBoundary")
            _downBlocked = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "UpperBoundary")
            _upBlocked = false;
        else if (other.gameObject.tag == "LowerBoundary")
            _downBlocked = false;
    }

}
