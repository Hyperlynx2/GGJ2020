using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikePayload : BasePayload
{
  [SerializeField]
  private GameObject m_movingObject;
  private bool m_PlayerInKillzone;
  
  public override void PayloadActivated()
  {
    // TODO: Play sound.


    // Check if the player is within the payload
    LeanTween.moveLocalZ(m_movingObject, -0.35f, 0.05f);
    if(m_PlayerInKillzone)
      GameManager.get().OnPlayerKilled();
  }

  public override void PayloadArmed()
  {
    LeanTween.moveLocalZ(m_movingObject, 1.5f, 0.5f);
  }

    private void OnTriggerEnter(Collider other) 
  {
    if(other.tag == "Player")
    {
      m_PlayerInKillzone = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if(other.tag == "Player")
    {
      m_PlayerInKillzone = false;
    }
  }
}
