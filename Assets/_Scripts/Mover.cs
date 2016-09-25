using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;
    private Rigidbody obj;

    void Start()
    {
        obj = GetComponent<Rigidbody>();

        obj.velocity = transform.forward * speed;
    }
}
