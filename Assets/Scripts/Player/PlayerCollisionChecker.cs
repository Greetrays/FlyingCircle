using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionChecker : MonoBehaviour, ITriggerCollision
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandle(collision);
    }

    public void CollisionHandle(Collider2D collision)
    {
        if (collision.TryGetComponent(out GameOverTrigger trigger))
        {
            SceneManager.LoadScene(0);
        }
    }
}
