using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerMover _target;

    private float _startTargetPosotionX;

    private void Start() => _startTargetPosotionX = _target.transform.position.x;

    private void Update()
    {
        float offsetX = _target.transform.position.x - _startTargetPosotionX;
        transform.position = new Vector3(offsetX, transform.position.y, transform.position.z);
    }
}
