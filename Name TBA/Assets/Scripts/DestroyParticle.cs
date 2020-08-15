using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private float SDT;
    public float Limit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SDT++;

        if(SDT >= Limit)
        {
            Destroy(transform.gameObject);
        }
    }
}
