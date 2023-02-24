using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
  [SerializeField] private string requiredInventoryItemString;

  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject == NewPlayer.Instance.gameObject)
    {
      if (NewPlayer.Instance.inventory.ContainsKey(requiredInventoryItemString))
      {
        NewPlayer.Instance.RemoveInventoryItem(requiredInventoryItemString);
        Destroy(gameObject);
      }
    }
  }
}
