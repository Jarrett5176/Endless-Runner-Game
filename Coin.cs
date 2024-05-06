using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
public class Coin : MonoBehaviour {
public AudioClip coinSound;
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            
        }

        // Check that the object we collided with is the player
        if (other.gameObject.tag == "Player") {
           AudioSource.PlayClipAtPoint(coinSound, transform.position);
        
                
        // Add to the player's score
        GameManager.inst.IncrementScore();
        
        // Destroy this coin object
        Destroy(gameObject);
    }}

    private void Start () {
        
	}

	private void Update () {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
	}
}