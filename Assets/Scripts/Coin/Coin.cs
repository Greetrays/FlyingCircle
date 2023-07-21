using UnityEngine;

public class Coin : SpawnObject, ITriggerCollision
{
    [SerializeField] private float _speed;
    [SerializeField] private float _triggerDistance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) <= _triggerDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandle(collision);
    }

    public void CollisionHandle(Collider2D collision)
    {
        if (collision.TryGetComponent(out GameOverTrigger trigger) || collision.TryGetComponent(out PlayerCoin player) )
        {
            gameObject.SetActive(false);
        }
    }
}
