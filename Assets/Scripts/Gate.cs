using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
  [SerializeField] private string requiredInventoryItemString;

  NewPlayer newPlayer;

  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.name == "Player")
    {
      if (newPlayer.inventory.ContainsKey(requiredInventoryItemString))
      {
        newPlayer.RemoveInventoryItem(requiredInventoryItemString);
        Destroy(gameObject);
      }
    }
  }
}
