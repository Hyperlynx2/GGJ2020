using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
  public AudioClip m_armTrapSound;

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
    if(m_armed)
    {
      m_payload.PayloadActivated();
      m_armed = false;
    }
    else
    {
      Debug.Log("safe! trap not armed");
    }
  }

  // for convenience, so the player can raycast to see if they arm them.
  public Collider GetPayloadCollider()
  {
    return m_payload.GetComponent<Collider>();
  }

  // called by the player.
  public void ArmTrap()
  {
    if(!m_armed)
    {
      if (AudioManager.get())
        AudioManager.get().PlayOnce(m_armTrapSound);
      m_armed = true;
      m_payload.PayloadArmed();
    }
  }

  // So that we can count how many tiles are armed to see if you win
  public bool IsArmed()
  {
    return m_armed;
  }

  private BasePayload m_payload;

  private bool m_armed = false;

}
