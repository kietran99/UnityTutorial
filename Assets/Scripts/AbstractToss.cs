using UnityEngine;

public abstract class AbstractToss : MonoBehaviour
{
    [SerializeField] 
    protected float force = 1f;

    private Rigidbody2D rigidBody;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Toss();
    }

    protected void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }

    protected void Toss()
    {
        rigidBody.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
    } 

    protected void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) { HandlePlayerCollision(); }     
    }

    protected virtual void HandlePlayerCollision() => Destroy(gameObject);
}
