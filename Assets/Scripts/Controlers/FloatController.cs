using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatController : MonoBehaviour
{
                 
    private Vector3 _startPosition;
    private Vector3 _currentPosition;

    void Start()
    {
        _startPosition = transform.position;
    }


    void Update()
    {
       Floating();
    }


    void Floating() /// <summary> let's make float float :P </summary>
    {
        _currentPosition = new Vector3(_startPosition.x, (_startPosition.y + GameManager.FloatManager.Amplitude * Mathf.Sin(GameManager.FloatManager.Speed * Time.time)), _startPosition.z); // setting Y position between amplitude(-0.2, 0.2) depending on time
        transform.position = _currentPosition;
    }



    public void ShowFloat()
    {
        gameObject.SetActive(true);
    }

    public void HideFloat()
    {
        gameObject.SetActive(false);
    }
	
}
