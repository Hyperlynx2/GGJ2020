using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float m_rotationDPS = 30;
  public float m_speed = 50;

  private Rigidbody m_body = null;

  private void Start()
  {
    m_body = gameObject.GetComponent<Rigidbody>();
  }

  // Fixed update is called in sync with physics
  // Handles movement etc.
  private void FixedUpdate()
  {
    //literally just rotate by the horizontal axis, then add forward by the vertical axis!
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    // TODO: Too lazy to remove - do it later RON
    MovePlayer(v, h);
  }

  public void MovePlayer(float v, float h) 
  {
    if(v+h != 0) {
      Vector3 moveDirection = Vector3.zero;
      moveDirection.z = v;
      moveDirection.x = h;
      moveDirection.Normalize();

      Quaternion rot = Quaternion.RotateTowards(m_body.rotation, 
                                                Quaternion.LookRotation(moveDirection), 
                                                Time.deltaTime * m_rotationDPS);
      m_body.MoveRotation(rot);
      m_body.MovePosition(m_body.position + moveDirection * m_speed * Time.deltaTime);
    }
  }

}