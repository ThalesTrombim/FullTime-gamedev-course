using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.GetComponent<Enemy>())
    {
      collision.gameObject.GetComponent<Enemy>().health -= NewPlayer.Instance.attackPower;
    }
  }
}
