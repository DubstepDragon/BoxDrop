using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject sphere;

    public float spawnTime = 2.0f;
    private float spawnTimeInit;

    
    // Start is called before the first frame update
    void Start()
    {
        spawnTimeInit = spawnTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0.0f)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            SpawnSphere();
            spawnTime = spawnTimeInit;
        }

        
    }


    void SpawnSphere()
    {
        Vector3 pos = RandomCircle(transform.position, Random.Range(1, 10), Random.Range(0, 360));
        GameObject new_inst = Instantiate(sphere, pos, sphere.transform.rotation);
        new_inst.transform.localScale = sphere.transform.localScale;
        new_inst.transform.parent = this.transform;
    }

    Vector3 RandomCircle(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z;
        return pos;
    }
}
