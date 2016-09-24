using UnityEngine;
using System.Collections;

public class Boltmover : MonoBehaviour {

    public float speed;
    private Rigidbody bolt;

    void Start()
    {
        bolt = GetComponent<Rigidbody>();

        bolt.velocity = transform.forward * speed;
    }
}
