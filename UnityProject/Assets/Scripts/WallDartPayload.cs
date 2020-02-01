using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDartPayload : BasePayload
{
  [SerializeField]
  private GameObject m_moveObject;
  private bool m_PlayerInKillzone;

  public override void PayloadActivated()
  {
    // TODO: move spikes, play sound.

    LeanTween.moveLocalZ(m_moveObject, -5.0f, 0.05f);

    if(m_PlayerInKillzone)
      GameManager.get().OnPlayerKilled();
  }

  public override void PayloadArmed()
  {
    LeanTween.moveLocalZ(m_moveObject, 0.0f, 2.0f);
  }

  private void OnTriggerStay(Collider other) 
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
