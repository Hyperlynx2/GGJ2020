using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float m_rotationDPS = 30;
  public float m_speed = 50;

  // should be the width of a tile
  public float m_trapArmRange = 1;

  private Rigidbody m_body = null;

  private void Start()
  {
    m_body = gameObject.GetComponent<Rigidbody>();
    GameManager.get().RegisterPlayer(this);
  }

  // called by GameManager when it's time to arm a trap.
  public void ArmTrap()
  {
    Ray armTrapRay = new Ray(transform.position, transform.forward);

    foreach(Trap trap in GameManager.get().GetTraps())
    {
      RaycastHit dummy;
      if(trap.GetPayloadCollider().Raycast(armTrapRay, out dummy, m_trapArmRange))
      {
        trap.ArmTrap();
        break; //LHF: naughty - I should use a different control structure instead.
      }
    }
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