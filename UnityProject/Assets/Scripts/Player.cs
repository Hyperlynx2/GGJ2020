using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float m_rotationDPS = 30;
  public float m_speed = 50;

  // should be the width of a tile
  public float m_trapArmRange = 1;

  // Fixed update is called in sync with physics
  // Handles movement etc.
  private void FixedUpdate()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    if (Input.GetAxis("Arm Trap") > 0)
    {
      Ray armTrapRay = new Ray(transform.position, transform.forward);

      foreach (Trap trap in GameManager.get().GetTraps())
      {
        RaycastHit dummy;
        if(trap.GetPayloadCollider().Raycast(armTrapRay, out dummy, m_trapArmRange))
        {
          trap.ArmTrap();
          break; //LHF: naughty - I should use a different control structure instead.
        }
      }
    }

    transform.Rotate(new Vector3(0, 1, 0), m_rotationDPS * Time.deltaTime * h);
    transform.position += transform.forward * m_speed * Time.deltaTime * v;
  }

}