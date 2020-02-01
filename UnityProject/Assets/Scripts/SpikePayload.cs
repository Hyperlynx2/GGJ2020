using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePayload : BasePayload
{
  public AudioClip[] m_activatedSounds;

  public override void PayloadActivated()
  {
    foreach (AudioClip clip in m_activatedSounds)
    {
      AudioManager.get().PlayOnce(clip);
    }

    GameManager.get().OnPlayerKilled();
  }

  public override void PayloadArmed()
  {
    Debug.Log("spike trap armed!");
    // TODO: move the spikes up and down, etc.
  }

}
