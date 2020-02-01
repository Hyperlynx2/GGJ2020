using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePayload : BasePayload
{
  [SerializeField]
  private Transform m_spike;

  [SerializeField]
  private float m_disarmPosition;
  [SerializeField]
  private float m_armedPosition;


  public AudioClip[] m_activatedSounds;

  public override void PayloadActivated()
  {
    foreach (AudioClip clip in m_activatedSounds)
    {
      AudioManager.get().PlayOnce(clip);
    }

    LeanTween.moveLocalY(m_spike.gameObject, m_armedPosition, 0.05f);
    GameManager.get().OnPlayerKilled();
  }

  public override void PayloadArmed()
  {
    LeanTween.moveLocalY(m_spike.gameObject, m_disarmPosition, 1.0f);
  }
}
