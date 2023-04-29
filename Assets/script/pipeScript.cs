using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    public float pipeSpeed;
    public float deadzone = -45;
    private LogicScript logic;
    private Vector3 initScale;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        initScale = transform.localScale;
        if (logic.playerScore - logic.scoreWhenBonus < logic.maxBonusPipeNum && logic.scoreWhenBonus != 0)
        {
            if (logic.playerHadBonus == -1)
            {
                transform.localScale = new Vector3(initScale.x * 1.5f, initScale.y * 0.8f, initScale.z);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * logic.Vitesse() * Time.deltaTime;



        if (transform.position.x < deadzone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }
    }
}
