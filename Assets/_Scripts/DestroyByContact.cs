using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion, playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameObj != null)
        {
            gameController = gameObj.GetComponent<GameController>();
        } else
        {
            Debug.Log("Cannot find game controller.");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
        gameController.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
