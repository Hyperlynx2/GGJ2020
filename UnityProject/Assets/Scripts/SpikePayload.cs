using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePayload : BasePayload
{
  public override void PayloadActivated()
  {
    // TODO: move spikes, play sound.

    GameManager.get().OnPlayerKilled();
  }

  public override void PayloadArmed()
  {
    Debug.Log("spike trap armed!");
    // TODO: move the spikes up and down, etc.
  }

}
