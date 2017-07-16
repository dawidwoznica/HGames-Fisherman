using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRodController : MonoBehaviour
{
    /// <summary>
    /// Fishing rod rotation.
    /// </summary>

    public void Throw()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ReelIn()
    {
        transform.rotation = Quaternion.Euler(0, 0, 45);
    }

}
