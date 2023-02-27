using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
  [SerializeField] private string loadSceneString;

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
      SceneManager.LoadScene(loadSceneString);
      NewPlayer.Instance.SetSpawnPosition();
    }
  }
}
