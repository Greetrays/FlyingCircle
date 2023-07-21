using UnityEngine;
using UnityEngine.Events;

public class PlayerCoin : MonoBehaviour
{
    private int _coinCount;

    public event UnityAction<int> Chached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coinCount++;
            Chached?.Invoke(_coinCount);
        }
    }
}
