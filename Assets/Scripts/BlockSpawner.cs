using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;

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
        if(spawnTime > 0.0f)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            SpawnBlock();
            spawnTime = spawnTimeInit;
        }
    }

    void SpawnBlock ()
    {
        Vector3 pos = RandomCircle(transform.position, Random.Range(1, 5), Random.Range(0, 360));
        GameObject new_inst = Instantiate(block, pos, block.transform.rotation);
        new_inst.transform.localScale = block.transform.localScale;
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
