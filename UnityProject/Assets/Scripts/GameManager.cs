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

  // Called by the exit tile. See if the player has won.
  public void OnExitTileReached()
  {
    bool allTrapsArmed = true;

    var it = m_traps.GetEnumerator();
    while(allTrapsArmed && it.MoveNext())
    {
      allTrapsArmed &= it.Current.IsArmed();
    }

    if(allTrapsArmed)
      Debug.Log("You win!");
    else
      Debug.Log("Not all traps armed.");
  }

  private List<Trap> m_traps = new List<Trap> { };
  private static GameManager s_instance;

}
