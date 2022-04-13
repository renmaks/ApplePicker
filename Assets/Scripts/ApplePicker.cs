using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    ////[Header("Set in Inspector")]
    ////[SerializeField] private GameObject basketPrefab;

    ////private int numBaskets = 3;
    ////private float basketBottomY = -14f;
    ////private float basketspacingY = 2f;
    ////private List<GameObject> basketList;
    //[SerializeField] private GameObject hp;
    //private Text hpCount;


    //void Start()
    //{
    ////    basketList = new List<GameObject>();

    ////    for (int i = 0; i < numBaskets; i++)
    ////    {
    ////        GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
    ////        Vector3 pos = Vector3.zero;
    ////        pos.y = basketBottomY + (basketspacingY * i);
    ////        tBasketGO.transform.position = pos;
    ////        basketList.Add(tBasketGO);
    ////    }

    //    hpCount = hp.GetComponent<Text>();
    //    hpCount.text = "HP: " + basketList.Count;
    //}

    //public void AppleDestroyed ()
    //{
    //    // Удалить все упавшие яблоки
    //    //GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
    //    //foreach(GameObject tGO in tAppleArray)
    //    //{
    //    //    Destroy(tGO);
    //    //}

    //    //// Удалить одну корзину
    //    //// Получить индекс последней корзины в basketList
    //    //int basketIndex = basketList.Count - 1;
    //    //// Получить ссылку на этот игровой объект Basket
    //    //GameObject tBasketGO = basketList[basketIndex];
    //    //// Исключить корзину из списка и удалить сам игровой объект
    //    //basketList.RemoveAt(basketIndex);
    //    //Destroy(tBasketGO);

    //    hpCount = hp.GetComponent<Text>();
    //    hpCount.text = "HP: " + basketList.Count;

    //    // Если корзин не осталось, перезапустить игру
    //    //if (basketList.Count == 0)
    //    //{
    //    //    SceneManager.LoadScene("_Lose_Screen");
    //    //}
    //}

    //public void EnemyAppleDestroyed ()
    //{
    //    //int basketIndex = basketList.Count - 1;
    //    //GameObject tBasketGO = basketList[basketIndex];
    //    //basketList.RemoveAt(basketIndex);
    //    //Destroy(tBasketGO);

    //    hpCount = hp.GetComponent<Text>();
    //    hpCount.text = "HP: " + basketList.Count;

    //    //if (basketList.Count == 0)
    //    //{
    //    //    SceneManager.LoadScene("_Lose_Screen");
    //    //}
    //}

}
