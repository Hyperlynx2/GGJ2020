using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float m_rotationDPS = 30;
  public float m_speed = 50;

  // should be the width of a tile
  public float m_trapArmRange = 1;

  private Rigidbody m_body = null;

  private Vector3 m_desiredDirection;

  private void Start()
  {
    m_body = gameObject.GetComponent<Rigidbody>();
    GameManager.get().RegisterPlayer(this);
    m_desiredDirection = transform.forward;
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

  public void Update()
  {
    Quaternion rot = Quaternion.RotateTowards(m_body.rotation,
                                              Quaternion.LookRotation(m_desiredDirection),
                                              Time.deltaTime * m_rotationDPS);
    m_body.MoveRotation(rot);
  }


  public void MovePlayer(float v, float h) 
  {
    if(v+h != 0) {
      m_desiredDirection = Vector3.zero;
      m_desiredDirection.z = v;
      m_desiredDirection.x = h;
      m_desiredDirection.Normalize();

      m_body.MovePosition(m_body.position + m_desiredDirection * m_speed * Time.deltaTime);
    }
  }

}