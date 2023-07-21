using UnityEngine;

public class Enemy : SpawnObject, ITriggerCollision
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandle(collision);
    }

    public void CollisionHandle(Collider2D collision)
    {
        if (collision.TryGetComponent(out GameOverTrigger trigger))
        {
            gameObject.SetActive(false);
        }
    }
}
