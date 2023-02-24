using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
  [SerializeField] private float maxSpeed;

  private RaycastHit2D leftLedgeRaycastHit;
  private RaycastHit2D rightLedgeRaycastHit;

  [SerializeField] private Vector2 rayCastOffset;
  [SerializeField] private float raycastLength = 2;

  void Start()
  {
         
  }

  // Update is called once per frame
  void Update()
  {
    targetVelocity = new Vector2(maxSpeed, 0);

    rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, raycastLength);
    Debug.DrawRay(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down * raycastLength, Color.yellow);

    leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, raycastLength);
    Debug.DrawRay(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down * raycastLength, Color.yellow);
  }
}
