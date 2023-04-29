using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pipe;
    public float spawnRate;
    private float timer;
    public float offset;

    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) { 
            timer += Time.deltaTime; 
        } 
        else {
            SpawnPipe();
            timer = 0;
        }
    }


    void SpawnPipe()
    {
        float highest = transform.position.y + offset;
        float lowest = transform.position.y - offset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowest,highest), transform.position.z), transform.rotation);
    }
}


