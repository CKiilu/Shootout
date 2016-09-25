using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(asteroidExplosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
