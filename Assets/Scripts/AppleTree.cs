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
    private float _speed = 17f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

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

        if (pos.x < -_leftAndRightEdge) // Turn right
        {
            _speed = Mathf.Abs(_speed); 
        }
        else if (pos.x > _leftAndRightEdge) // Turn left
        {
            _speed = -Mathf.Abs(_speed);
        }

        if (Random.value < _chanceToChangeDirections) // Change direction
        {
            _speed *= -1;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(_speed, 0, 0);
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            if(_chanceToEnemyAppleDrop < 0.39f)
            _chanceToEnemyAppleDrop += _difficultyScale;

            if (_secondsBetweenApplesDrops > 0.27f)
                _secondsBetweenApplesDrops -= _difficultyScale;

            if (_chanceToEnemyAppleDrop >= 0.39f && _secondsBetweenApplesDrops <= 0.27f)
                StopCoroutine(nameof(DoCheck));

            yield return new WaitForSeconds(_timer);
        }
    }

}
