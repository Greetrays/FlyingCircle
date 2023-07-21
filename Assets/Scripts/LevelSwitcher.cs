using UnityEngine;
using UnityEngine.Events;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private float _timeBetweenLevels;
    [SerializeField] private float _multiplier;
    [SerializeField, Min(1)] private int _maxLevel;

    private int _level;
    private float _elapsedTime;

    public UnityAction<int> Switched;

    private void Start()
    {
        _level = 1;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenLevels && _level <= _maxLevel)
        {
            Switched?.Invoke(_level);
            _level++;
            _elapsedTime = 0;
            _timeBetweenLevels *= _multiplier;
        }
    }    
}
