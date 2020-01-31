using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float m_rotationDPS = 30;
  public float m_speed = 50;

  // Fixed update is called in sync with physics
  // Handles movement etc.
  private void FixedUpdate()
  {
    //literally just rotate by the horizontal axis, then add forward by the vertical axis!

    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Debug.Log(h + " horz " + v + " vert");

    transform.Rotate(new Vector3(0, 1, 0), m_rotationDPS * Time.deltaTime * h);
    transform.position += transform.forward * m_speed * Time.deltaTime * v;
  }
}
