using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public bool destroySelf = true; // If true, this object destroys itself
    public bool destroyOther = true; // If true, the object it collides with is destroyed

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyOther)
        {
            Destroy(collision.gameObject); // Destroy the other object
        }

        if (destroySelf)
        {
            Destroy(gameObject); // Destroy this object
        }
    }
}
