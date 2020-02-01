using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all different kinds of payload
public abstract class BasePayload: MonoBehaviour
{
  // player has armed the trap. Play the relevant anim.
  public abstract void PayloadArmed();

  // player stepped on the trigger! start the animation.
  public abstract void PayloadActivated();
}
