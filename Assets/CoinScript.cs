using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CoinScript : MonoBehaviour
{

    public float deadzone = -45;
    private int coinValue = 0;
    private LogicScript logic;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        coinValue = Random.Range(1, 4);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(coinValue == 2)
        {
            spriteRenderer.color = new Color(255, 128, 255, 255);
        }
        else if (coinValue == 3)
        {
            spriteRenderer.color = new Color(255,0,250,255);
        }
        //transform.localScale = new Vector3(transform.localScale.x * coinValue, transform.localScale.y * coinValue, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * logic.Vitesse() * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Debug.Log("Coin destroyed");
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //coinValue *= 5;
            logic.addCoin(coinValue);
            Debug.Log("coin get");
            Destroy(gameObject);
        }

    }
}
