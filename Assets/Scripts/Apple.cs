using UnityEngine;

public class Apple : MonoBehaviour
{
    private GameManager _gameManager;
    private readonly float _bottomY = -20f;

    private void Awake()
    {
        _gameManager = Camera.main.GetComponent<GameManager>();
    }

    void Update()
    {
        OutOfYBound(_bottomY);
    }

    private void OutOfYBound(float bottomBound)
    {
        if (transform.position.y <= bottomBound)
        {
            Destroy(gameObject);
            _gameManager.AppleDestroyed();
        }
    }

}
