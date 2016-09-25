using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

    public Vector2 startWait, maneuverTime, maneuverWait;
    public float dodge, smoothing, tilt;
    private float targetManeuver, currentSpeed;
    private Rigidbody body;
    public Boundary boundary;

	void Start () {
        StartCoroutine(Evade());
        body = GetComponent<Rigidbody>();
        currentSpeed = body.velocity.z;
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
	
	void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(body.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        body.velocity = new Vector3(newManeuver, 0f, currentSpeed);
        body.position = new Vector3(
            Mathf.Clamp(body.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(body.position.z, boundary.zMin, boundary.zMax)
            );
        body.rotation = Quaternion.Euler(0f, -180f, body.velocity.x * -tilt);
    }
}
