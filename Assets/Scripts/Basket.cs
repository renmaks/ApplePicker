using UnityEngine;

public class Basket : MonoBehaviour
{
    private AudioSource _hitSound;
    private GameManager _gameManager;
    private Vector2 leftBot;
    private Vector2 rightTop;
    private float x_left;
    private float x_right;

    private void Awake()
    {
        _hitSound = GetComponent<AudioSource>();
        _gameManager = Camera.main.GetComponent<GameManager>();
        leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        x_left = leftBot.x;
        x_right = rightTop.x;
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector2 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(mousePos3D.x, x_left, x_right);
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
