using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;
   public float life = 1;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    

    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            
            LifeCounter();
        }
	}
    public void LifeCounter(){
        life--;
      
            Die();
        }
    
    public void Die ()
    {
        life--;
        if (life < 0){
        alive = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }else {
        alive = true;
        GameManager.inst.LoseLife();
    }}

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}