using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_background : MonoBehaviour
{
    private LogicScript logic;
    public float speed;

    [SerializeField]
    private Renderer bg_renderer;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        speed = speed * 0.02f;
    }
    // Update is called once per frame
    void Update()
    {
        bg_renderer.material.mainTextureOffset += new Vector2 (logic.Vitesse() * speed * Time.deltaTime, 0);
    }
}
