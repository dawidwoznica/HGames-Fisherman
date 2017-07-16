using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Vector3 _startingPosition;


	void Start ()
	{
	    _startingPosition = transform.position;
	}
	
	void Update ()
	{
	    float newPosition = Mathf.Repeat(Time.time * GameManager.WaterManager.ScrollSpeed, GameManager.WaterManager.WaterSizeX);
	    transform.position = _startingPosition + Vector3.left * newPosition;
	}

}
