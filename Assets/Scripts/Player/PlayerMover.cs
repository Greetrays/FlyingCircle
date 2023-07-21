using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(_speedX, 0);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _rigidbody.AddForce(new Vector2(0, _speedY));
        }
    }
}
