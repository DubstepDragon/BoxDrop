using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Wall_script : MonoBehaviour
{
    public Player_controller player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            player.LoseScore(1);
            Destroy(other.gameObject);
        }
    }
}
