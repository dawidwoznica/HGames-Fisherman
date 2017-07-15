using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarManager : MonoBehaviour {

	public int MaxProgressValue = 1;
    public float ProgressPossitiveValue = 0.003f;
    public float ProgressNegativeValue = 0.002f;
    public Color FullProgressColor = Color.green;
    public Color NoProgressColor = Color.red;
    public int StartingValue = 0;

}
