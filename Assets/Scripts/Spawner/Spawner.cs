using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int X = 1;
    private const int Y = 1;

    [SerializeField] private SpawnObject _template;
    [SerializeField] private PlayerCoin _target;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _offset;
    [SerializeField] Transform _topBorder;
    [SerializeField] Transform _bottomBorder;
    [SerializeField] private LevelSwitcher _levelSwither;

    private Pool<SpawnObject> _poolGen;
    private int _level;
    private float _positionScreenX => _camera.ViewportToWorldPoint(new Vector2(X, Y)).x;
    private float _delay;
    private float _elapsedTime;

    private void OnEnable()
    {
        _levelSwither.Switched += OnSwitched;
    }

    protected void Start()
    {
        _level = 1;
        _poolGen = new Pool<SpawnObject>(_template, transform);
        _delay = Random.Range(_minDelay, _maxDelay);
    }

    private void OnDisable()
    {
        _levelSwither.Switched -= OnSwitched;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delay)

        {
            _elapsedTime = 0;
            _delay = Random.Range(_minDelay, _maxDelay);
            Spawn();
        }
    }

    private void OnSwitched(int level)
    {
        _level = level;
    }

    protected void Spawn()
    {
        for (int i = 0; i < _level; i++)
        {
            SpawnObject newSpawnObject = _poolGen.GetFreeElement();
            newSpawnObject.SetTarget(_target);
            Vector2 randomPosition = new Vector2(_positionScreenX + i, Random.Range(_topBorder.position.y - _offset, _bottomBorder.position.y + _offset));
            newSpawnObject.gameObject.SetActive(true);
            newSpawnObject.transform.position = randomPosition;
        }
    }
}
