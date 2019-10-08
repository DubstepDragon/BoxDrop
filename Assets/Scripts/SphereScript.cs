using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public Vector3 rotVec;

    public GameObject pointer;

    [HideInInspector]
    public Vector3 pointerPos;

    public float onOffTimer = 3.0f;
    private float onOffTimerinit;

    Collider coll;
    MeshRenderer mesh;
    MeshRenderer pointerMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        onOffTimerinit = onOffTimer;
        coll = GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
        pointerMesh = pointer.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onOffTimer > 0.0f)
        {
            onOffTimer -= Time.deltaTime;
        }
        else
        {
            onOffTimer = onOffTimerinit;
            OnOff();
        }

        pointerPos = pointer.transform.position;
        transform.Rotate(rotVec, Space.Self);

        
    }

    public void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "BackWall")
        {
            //decrease score
        }

    }

    public void OnOff()
    {
        coll.enabled = !coll.enabled;
        mesh.enabled = !mesh.enabled;
        pointerMesh.enabled = !pointerMesh.enabled;
    }
}
