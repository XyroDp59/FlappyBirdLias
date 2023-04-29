using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class bonusScript : MonoBehaviour
{
    public float deadzone = -45;
    private LogicScript logic;
    private int bonusValue;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        float r = Random.value - 0.5f;
        bonusValue = (int) (r / Mathf.Abs(r));
        Debug.Log(bonusValue);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (bonusValue == -1)
        {
            spriteRenderer.color = new Color(255, 0, 255, 255);
        }
        else if (bonusValue == 1)
        {
            spriteRenderer.color = new Color(255, 255, 0, 255);
        }
        //transform.localScale = new Vector3(transform.localScale.x * coinValue, transform.localScale.y * coinValue, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * logic.Vitesse() * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Debug.Log("bonus destroyed");
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bonus collision = " + collision.name);
        if (collision.gameObject.layer == 3)
        {
            logic.playerHadBonus = bonusValue;
            logic.scoreWhenBonus = logic.playerScore;
            if (bonusValue == 1)
            {
                logic.v0 *= 0.9f;
            }
            Debug.Log("bonus get");
            Destroy(gameObject);
        }
    }
}
