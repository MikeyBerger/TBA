using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJets : MonoBehaviour
{
    public Transform Jets;
    public Transform JetPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Jets, JetPoint.position, JetPoint.rotation);
    }
}
