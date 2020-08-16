using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    public Transform Particles;
    //public Transform ParticlePoint;
    private Transform Player;
    private float ParticleTimer;
    public float ParticleLimit;
    public bool IsSpawning = true;

    IEnumerator StopSpawning()
    {
        Instantiate(Particles, transform.position, transform.rotation);
        yield return new WaitForSeconds(ParticleLimit);
        IsSpawning = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        /*
        if (IsSpawning)
        {
            StartCoroutine(StopSpawning());
        }
        */
        Instantiate(Particles, transform.position, transform.rotation);
        transform.position = Player.position;
    }
}
