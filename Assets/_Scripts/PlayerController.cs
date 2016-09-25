using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed, tilt, fireRate;
    private float nextFire = 0f;
    private Rigidbody player;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    private AudioSource audioSource;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = fireRate + Time.time;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        player.velocity = movement * speed;
        player.position = new Vector3(
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(player.position.z, boundary.zMin, boundary.zMax)
            );
        player.rotation = Quaternion.Euler(0f, 0f, player.velocity.x * -tilt);
    }
}
