using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameScript))]
public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _magnet;
    //Gamescript
    private GameScript _gameScript;

    //Variables to spawn powerup
    private int _counter, x;
    private bool _isRunning;
    //Powerup Spawn Point
    private Vector3 _spawnPoint;

    private void Start()
    {
        _gameScript = GetComponent<GameScript>();
    }
    private void FixedUpdate()
    {
        if(_gameScript.getScore() >= 10 && !_isRunning)
        {
            //Spawn Magnet PowerUp enabled
            _counter = Random.Range(0, 40);
            x = Random.Range(-6, 6);
            _spawnPoint = new Vector3(x, 6, 2);
            StartCoroutine(SpawnPowerUp(_counter));
        }
    }
    IEnumerator SpawnPowerUp(int seconds)
    {
        _isRunning = true;
        yield return new WaitForSeconds(seconds);
        Instantiate(_magnet, _spawnPoint, Quaternion.identity);
        _isRunning = false;
        yield return null;
    }
}
