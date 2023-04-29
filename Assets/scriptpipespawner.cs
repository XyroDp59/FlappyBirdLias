using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptpipespawner : MonoBehaviour
{   
    // Start is called before the first frame update

    public GameObject pipe;
    public GameObject coin;
    public GameObject bonus;
    private LogicScript logic;
    public float spawnRate;
    private float timer;
    private bool hasCoinSpawned;
    public float offset;
    public float coinProbability;
    public float bonusProbability;
    


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
            
        if (timer < spawnRate / logic.Vitesse())
        {
            timer += Time.deltaTime;
            if (timer - (spawnRate / logic.Vitesse() / 2) >= 2 * Time.deltaTime && !hasCoinSpawned)
            {
                float r = Random.value;
                if  (r <= bonusProbability)
                {
                    SpawnObject(bonus);
                    Debug.Log("bonus spawned");
                }
                else if (r <= coinProbability)
                {
                    SpawnObject(coin);
                    Debug.Log("coin spawned");
                }
                hasCoinSpawned = true;
            }
        }
        else
        {

            SpawnObject(pipe);
            timer = 0;
            hasCoinSpawned = false;
        }
        
        
    }


    void SpawnObject(GameObject obj)
    {
        float highest = transform.position.y + offset;
        float lowest = transform.position.y - offset;

        Instantiate(obj, new Vector3(transform.position.x, Random.Range(lowest, highest), transform.position.z), transform.rotation);
    }
}


