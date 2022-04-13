using UnityEngine;

public class Basket : MonoBehaviour
{
    private AudioSource _hitSound;
    private GameManager _gameManager;

    private Vector2 _leftBot;
    private Vector2 _rightTop;

    private float _xLeft;
    private float _xRight;
    private readonly float _xLimit = 2f;

    private void Awake()
    {
        _hitSound = GetComponent<AudioSource>();
        _gameManager = Camera.main.GetComponent<GameManager>();
        _leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        _rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        _xLeft = _leftBot.x;
        _xRight = _rightTop.x;
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector2 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(mousePos3D.x, _xLeft + _xLimit, _xRight - _xLimit);
        transform.position = pos;
    }

     private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Apple"))
        {
            _hitSound.Play();

            Destroy(collidedWith);

            UIManager.SendApplePick();
        }

        if (collidedWith.CompareTag("Enemy"))
        {
            Destroy(collidedWith);
            _gameManager.AppleDestroyed();
        }
    }
}
