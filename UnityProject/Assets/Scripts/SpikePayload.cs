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
    Debug.Log("spike trap armed!");
    // TODO: move the spikes up and down, etc.
  }




}
