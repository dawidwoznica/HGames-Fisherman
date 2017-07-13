using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatController : MonoBehaviour
{
    private float _amplitude = 0.2f;          
    private float _speed = 1;                 
    private Vector3 _StartPosition;
    private Vector3 _CurrentPosition;

    void Start()
    {
        _StartPosition = transform.position;
    }


    void Update()
    {
       Floating();
    }


    void Floating() /// <summary> let's make float float :P </summary>
    {
        _CurrentPosition = new Vector3(_StartPosition.x, (_StartPosition.y + _amplitude * Mathf.Sin(_speed * Time.time)), _StartPosition.z); // setting Y position between amplitude(-0.2, 0.2) depending on time
        transform.position = _CurrentPosition;
    }



    public void ShowFloat()
    {
        gameObject.SetActive(true);
    }

    public void HideFlow()
    {
        gameObject.SetActive(false);
    }
	
}
