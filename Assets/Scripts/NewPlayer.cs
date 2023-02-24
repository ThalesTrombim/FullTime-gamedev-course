using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{

  [SerializeField] private float maxSpeed = 1;
  [SerializeField] private float jumpPower = 10;

  public int coinsCollected;
  private int maxHealth = 100;
  public int health = 100;
  public int ammo;

  public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
  public Image inventoryImage;
  public Sprite keySprite;
  public Sprite keyGemSprite;

  public Sprite inventoryItemBlank;

  public Text coinsText;
  public Image healthBar;

  private Vector2 healthBarOrigSize;

  //Singleton instantation

  private static NewPlayer instance;
  public static NewPlayer Instance
  {
    get
    {
      if (instance == null) instance = GameObject.FindObjectOfType<NewPlayer>();
      return instance;
    }
  }

  void Start()
  {
    coinsText = GameObject.Find("Coins").GetComponent<Text>();
    healthBar = GameObject.Find("Health Bar").GetComponent<Image>();
    healthBarOrigSize = healthBar.rectTransform.sizeDelta;

    UpdateUI();
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
    coinsText.text = coinsCollected.ToString();

    healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health/(float)maxHealth), healthBar.rectTransform.sizeDelta.y);
  }
  
  public void AddInventoryItem(string inventoryName, Sprite image)
  {
    inventory.Add(inventoryName, image);

    inventoryImage.sprite = inventory[inventoryName];
  }

  public void RemoveInventoryItem(string inventoryName)
  {
    inventory.Remove(inventoryName);

    inventoryImage.sprite = inventoryItemBlank;
  }
}
