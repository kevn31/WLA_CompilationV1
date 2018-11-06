using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    // Scroll main texture based on time

    float scrollSpeed = 0.01f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;

        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
