using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
   
    public SphereScript VecDir;
    private bool inSphere = false;
    private Rigidbody rb;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inSphere)
        {
            var heading = VecDir.pointerPos - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            var dir = new Vector3(direction.x, direction.y, 0);
            rb.velocity += dir * speed;
        }
        if(transform.position.y < -15)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sphere")
        {
            inSphere = true;   
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            inSphere = false;
        }
    }
}
