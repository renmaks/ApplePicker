using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _enemyAppleFrefab;

    
    private readonly float _leftAndRightEdge = 10f;
    private readonly float _chanceToChangeDirections = 0.01f;
    private readonly float _difficultyScale = 0.09f;
    private readonly float _timer = 3.5f;

    private float _secondsBetweenApplesDrops = 1f;
    private float _chanceToEnemyAppleDrop = 0.03f;
    private float _speed = 15f;

    private void Start()
    {
        Invoke(nameof(DropApple), 2f);
        StartCoroutine(nameof(DoCheck));
    }

    private void DropApple()
    {
        if(Random.value < _chanceToEnemyAppleDrop)
        {
            GameObject enemyApple = Instantiate(_enemyAppleFrefab);
            enemyApple.transform.position = transform.position;
            Invoke(nameof(DropApple), _secondsBetweenApplesDrops);
        }
        else
        {
            GameObject apple = Instantiate(_applePrefab);
            apple.transform.position = transform.position;
            Invoke(nameof(DropApple), _secondsBetweenApplesDrops);
        }
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += _speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -_leftAndRightEdge)
        {
            _speed = Mathf.Abs(_speed); // Turn right
        }
        else if (pos.x > _leftAndRightEdge) // Turn left
        {
            _speed = -Mathf.Abs(_speed);
        }

    }

     private void FixedUpdate()
    {
        if (Random.value < _chanceToChangeDirections)
        {
            _speed *= -1; // Change direction
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            if(_chanceToEnemyAppleDrop < 0.39f)
            _chanceToEnemyAppleDrop += _difficultyScale;

            if (_secondsBetweenApplesDrops > 0.3f)
                _secondsBetweenApplesDrops -= _difficultyScale;

            yield return new WaitForSeconds(_timer);
        }
    }

}
