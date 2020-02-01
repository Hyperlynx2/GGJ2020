using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singleton. Call GameManager.get()
public class GameManager : MonoBehaviour
{
  public GameManager()
  {
    s_instance = this;
  }

  public static GameManager get()
  {
    return s_instance;
  }

  // call from Traps on Start
  public void RegisterTrap(Trap trap)
  {
    m_traps.Add(trap);
  }

  public IReadOnlyCollection<Trap> GetTraps()
  {
    return m_traps;
  }

  private List<Trap> m_traps = new List<Trap> { };
  private static GameManager s_instance;

}
