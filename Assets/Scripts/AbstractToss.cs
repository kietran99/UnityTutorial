using UnityEngine;

public abstract class AbstractToss : MonoBehaviour
{    
    [SerializeField] 
    protected float force = 1f;

    private Rigidbody2D rigidBody;

    protected virtual void Start()
    {
        // TODO make rigidBody references to RigidBody2D component attaching to this game object
        // TODO Invoke Toss()      
    }    

    protected void Toss()
    {
        // TODO Toss this game object along the y-axis
    } 

    protected void OnTriggerEnter2D(Collider2D other) 
    {
        //TODO Detect colliding with the player
    }

    protected virtual void HandlePlayerCollision()
    {
        // TODO Destroy this game object on player collision
    }

    protected void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
