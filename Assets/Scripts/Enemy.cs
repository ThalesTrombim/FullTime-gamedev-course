using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
  [SerializeField] private float maxSpeed;

  private int direction = 1;
  private RaycastHit2D leftLedgeRaycastHit;
  private RaycastHit2D rightLedgeRaycastHit;

  private RaycastHit2D rightWallRaycastHit;
  private RaycastHit2D leftWallRaycastHit;

  [SerializeField] private LayerMask rayCastLayerMask;

  [SerializeField] private Vector2 rayCastOffset;
  [SerializeField] private float raycastLength = 1;

  [SerializeField] private int attackPower = 10;

  void Start()
  {
         
  }

  // Update is called once per frame
  void Update()
  {
    targetVelocity = new Vector2(maxSpeed*direction, 0);

    rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, raycastLength);
    Debug.DrawRay(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down * raycastLength, Color.yellow);
    if(rightLedgeRaycastHit.collider == null) direction = -1;

    leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, raycastLength);
    Debug.DrawRay(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down * raycastLength, Color.yellow);
    if (leftLedgeRaycastHit.collider == null) direction = 1;

    rightWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, raycastLength, rayCastLayerMask);
    Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right * raycastLength, Color.blue);
    if (rightWallRaycastHit.collider != null) direction = -1;

    leftWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, raycastLength, rayCastLayerMask);
    Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left * raycastLength, Color.blue);
    if (leftWallRaycastHit.collider != null) direction = 1;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject == NewPlayer.Instance.gameObject)
    {
      NewPlayer.Instance.health -= attackPower;
      NewPlayer.Instance.UpdateUI();
    }
  }
}
