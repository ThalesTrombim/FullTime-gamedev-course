using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{

  [SerializeField] private float maxSpeed = 1;
  [SerializeField] private float jumpPower = 10;

  public int coinsCollected;
  public int health = 100;
  public int ammo;

  public Text coinsText;

  void Start()
  {
    coinsText = GameObject.Find("Coins").GetComponent<Text>();
  }

  void Update()
  {
    targetVelocity = new Vector2(Input.GetAxis("Horizontal")*maxSpeed, 0);

    if(Input.GetButtonDown("Jump") && grounded)
    {
      velocity.y = jumpPower;
    }
  }

  public void UpdateUI()
  {
    // Essa abordagem, faz com que o dev sempre tenha que lembrar de colocar a
    // referencia no Unity Editor
    coinsText.text = coinsCollected.ToString();
  }
}
