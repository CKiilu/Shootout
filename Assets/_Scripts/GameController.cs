using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject hazard, player;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait, spawnWait, waveWait;

    void Start()
    {
        StartCoroutine(spawnWaves());
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (player)
        {
            for (int x = 0; x < hazardCount; x++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
