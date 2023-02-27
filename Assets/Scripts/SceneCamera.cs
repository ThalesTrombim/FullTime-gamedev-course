using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
  [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
  void Start()
  {
    cinemachineVirtualCamera.Follow = NewPlayer.Instance.transform;    
  }

  // Update is called once per frame
  void Update()
  {
        
  }
}
