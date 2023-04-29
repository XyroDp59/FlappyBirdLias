using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_background : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bg_renderer;

    // Update is called once per frame
    void Update()
    {
        bg_renderer.material.mainTextureOffset += new Vector2 (speed * Time.deltaTime, 0);
    }
}
