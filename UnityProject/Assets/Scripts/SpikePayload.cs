using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePayload : BasePayload
{
  public override void PayloadActivated()
  {
    Debug.Log("Ouch!");
  }

  public override void PayloadArmed()
  {
    throw new System.NotImplementedException();
  }


  // TODO: move the spikes up and down, etc.

}
