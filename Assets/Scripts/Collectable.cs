using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  //[SerializeField] private bool isCoin;
  //[SerializeField] private bool isHealth;
  //[SerializeField] private bool isAmmo;

  enum ItemType { Coin, Health, Ammo };
  [SerializeField] private ItemType itemType;

  NewPlayer newPlayer;

  void Start()
  {
    if (itemType == ItemType.Coin)
    {
      Debug.Log("I'm coin");
    }

    newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.name == "Player")
    {
      // Somente desativa o gameobject associado a este script.
      //gameObject.SetActive(false);
      
      newPlayer.coinsCollected += 1;
      newPlayer.UpdateUI();

      // Destroi totalmente o gameObject associado a este script.
      Destroy(gameObject);
    }
  }
}
