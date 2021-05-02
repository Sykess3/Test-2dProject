using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawnedCount;

    private float _timeAfterLastSpawn;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int,int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;
        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawnedCount++;
            EnemyCountChanged(_spawnedCount, _currentWave.Count);
            _timeAfterLastSpawn = 0;
        }

        if (_spawnedCount >= _waves[_currentWaveNumber].Count)
        {
            _currentWave = null;
            if (_waves.Count > _currentWaveNumber + 1)
                AllEnemySpawned();
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawnedCount = 0;
        EnemyCountChanged.Invoke(0, _waves[_currentWaveNumber].Count);
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, Quaternion.identity)
            .GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Dying += OnEnemyDying;
        
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        
        _target.AddMoney(enemy.Reward);
    }
}


[System.Serializable]
public class Wave
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;

    public GameObject Template => _template;
    public int Count => _count;
    public float Delay => _delay;
}
