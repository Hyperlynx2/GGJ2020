using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    GameManager.get().RegisterTrap(this);

    m_payload = GetComponentInChildren<BasePayload>();
    if(m_payload == null)
      Debug.LogError("Trap missing payload!");
  }

  // called by the tripwire.
  public void TripwireActivated()
  {
    // LHF: TODO: double check that the collider is the player?
    m_armed = false;

    m_payload.PayloadActivated();
  }

  // called by the player.
  public void TrapArmed()
  {
    m_armed = true;
    m_payload.PayloadArmed();
  }

  // So that we can count how many tiles are armed to see if you win
  public bool IsArmed()
  {
    return m_armed;
  }

  private BasePayload m_payload;

  private bool m_armed = false;

}
