using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _basketPrefab;

    public static readonly int BASKETS_COUNT = 3;

    private Vector3 _basketPosition = Vector3.up;
    private readonly float _basketYLevel = -12f;
    private List<GameObject> _baskets;

    private void Awake()
    {
        _baskets = new List<GameObject>();
    }

    private void Start()
    {
        for (int i = 0; i < BASKETS_COUNT; i++)
        {
            GameObject basket = Instantiate<GameObject>(_basketPrefab);
            basket.transform.position = _basketPosition * _basketYLevel;
            _baskets.Add(basket);
            basket.SetActive(false);
        }

        _baskets[_baskets.Count-1].SetActive(true);
    }

    public void AppleDestroyed()
    {
        DestroyCurrentBasket();
    }

    public void EnemyAppleDestroyed()
    {
        DestroyCurrentBasket();
    }

    private void DestroyCurrentBasket()
    {
        int basketIndex = _baskets.Count - 1;
        GameObject tBasketGO = _baskets[basketIndex];
        _baskets.RemoveAt(basketIndex);

        if (_baskets.Count == 0)
            SceneManager.LoadScene("_Lose_Screen");
        else
        {
            _baskets[_baskets.Count - 1].transform.position = tBasketGO.transform.position;
            _baskets[_baskets.Count - 1].SetActive(true);
        }

        Destroy(tBasketGO);

        UIManager.SendBasketDestroy(_baskets.Count);
    }

}
