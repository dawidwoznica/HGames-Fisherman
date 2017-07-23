using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderResizer : MonoBehaviour {

	
	void Awake() {
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<RectTransform>().rect.width,
            gameObject.GetComponent<RectTransform>().rect.height);
    }
	
}
