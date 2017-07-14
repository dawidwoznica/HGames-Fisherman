using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyController : MonoBehaviour
{
    private RectTransform _rect;
    public ProgressBarController ProgressBarController;
    private bool _triggered;


    void Start()
    {
        _rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_rect.anchoredPosition.y < 150)            
                _rect.anchoredPosition += Vector2.up * Time.deltaTime * 200;                    
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_rect.anchoredPosition.y > -57)
                _rect.anchoredPosition += Vector2.down * Time.deltaTime *200; 
        }

        if (!_triggered)
        {
            ProgressBarController.DeleteProgress();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        _triggered = true;
        ProgressBarController.AddProgress();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _triggered = false;
    }

}
