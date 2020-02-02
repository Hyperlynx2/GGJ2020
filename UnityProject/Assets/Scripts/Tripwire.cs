using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{
  // parent which this tripwire belongs to.
  Trap m_trap;

  // Start is called before the first frame update
  void Start()
  {
    m_trap = GetComponentInParent<Trap>();

    if(m_trap == null)
      Debug.LogError("Tripwire that's not on a trap?");
  }

  private void OnTriggerEnter(Collider other)
  {
    // TODO: LHF: only if it's the player?
    if(m_trap.IsArmed()) {
      if(other.gameObject.tag == "Player")
        m_trap.TripwireActivated();
    }
  }

}
