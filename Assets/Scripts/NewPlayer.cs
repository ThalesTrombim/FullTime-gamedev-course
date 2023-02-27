using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{

  [SerializeField] private float maxSpeed = 1;
  [SerializeField] private float jumpPower = 10;

  [SerializeField] private GameObject attackBox;
  [SerializeField] private float attackDuration;

  public int attackPower = 25;

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

  private void Awake()
  {
    if (GameObject.Find("New Player")) Destroy(gameObject);
  }

  void Start()
  {
    DontDestroyOnLoad(gameObject);

    gameObject.name = "New Player";

    coinsText = GameObject.Find("Coins").GetComponent<Text>();
    healthBar = GameObject.Find("Health Bar").GetComponent<Image>();
    healthBarOrigSize = healthBar.rectTransform.sizeDelta;
    UpdateUI();

    SetSpawnPosition();
  }

  void Update()
  {
    targetVelocity = new Vector2(Input.GetAxis("Horizontal")*maxSpeed, 0);

    if(Input.GetButtonDown("Jump") && grounded)
    {
      velocity.y = jumpPower;
    }

    if(targetVelocity.x < -.01)
    {
      transform.localScale = new Vector2(-1, 1);
    }
    else if(targetVelocity.x > 0.1)
    {
      transform.localScale = new Vector2(1, 1);
    }

    if(Input.GetButtonDown("Fire1"))
    {
      StartCoroutine("ActivateAttack");
    }

    if(health <= 0)
    {
      Die();
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

  public IEnumerator ActivateAttack()
  {
    attackBox.SetActive(true);
    yield return new WaitForSeconds(attackDuration);
    attackBox.SetActive(false);
  }

  public void Die()
  {
    SceneManager.LoadScene("SampleScene");
  }

  public void SetSpawnPosition()
  {
    transform.position = GameObject.Find("Spawn Location").transform.position;
  }
}
