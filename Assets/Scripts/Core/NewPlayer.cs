using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
  [Header("Attributes")]
  [SerializeField] private float attackDuration;
  public int attackPower = 25;
  [SerializeField] private float jumpPower = 10;
  [SerializeField] private float maxSpeed = 1;

  [Header("Inventory")]
  public int ammo;
  public int coinsCollected;
  public int health = 100;
  private int maxHealth = 100;

  [Header("References")]
  [SerializeField] private Animator animator; 
  [SerializeField] private GameObject attackBox;
  public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
  public Sprite inventoryItemBlank;
  private Vector2 healthBarOrigSize;
  public Sprite keySprite;
  public Sprite keyGemSprite;

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

    GameManager.Instance.coinsText = GameObject.Find("Coins").GetComponent<Text>();
    GameManager.Instance.healthBar = GameObject.Find("Health Bar").GetComponent<Image>();
    healthBarOrigSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
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

    animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    animator.SetFloat("velocityY", velocity.y);

    animator.SetBool("grounded", grounded);
  }

  public void UpdateUI()
  {
    GameManager.Instance.coinsText.text = coinsCollected.ToString();

    GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health/(float)maxHealth), GameManager.Instance.healthBar.rectTransform.sizeDelta.y);
  }
  
  public void AddInventoryItem(string inventoryName, Sprite image)
  {
    inventory.Add(inventoryName, image);

    GameManager.Instance.inventoryImage.sprite = inventory[inventoryName];
  }

  public void RemoveInventoryItem(string inventoryName)
  {
    inventory.Remove(inventoryName);

    GameManager.Instance.inventoryImage.sprite = inventoryItemBlank;
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
