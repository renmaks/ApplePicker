using UnityEngine;

public class Basket : MonoBehaviour
{
    private AudioSource _hitSound;

     private void Awake()
    {
        _hitSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
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

            GameManager gameManager = Camera.main.GetComponent<GameManager>();
            gameManager.AppleDestroyed();
        }
    }

}
