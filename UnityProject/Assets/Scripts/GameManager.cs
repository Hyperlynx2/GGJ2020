using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singleton. Call GameManager.get().
// responsible for managing one level only. one of these per level.
public class GameManager : MonoBehaviour
{
  public enum GAMESTATE
  {
    PLAYING,
    WON,
    LOST
  };

  public Texture m_youWonTexture;
  public Texture m_youLostTexture;

  public void Awake()
  {
    if(s_instance != null)
      throw new System.Exception("Two GameManagers in the scene!!!");
    s_instance = this;
  }

  public void Start()
  {
    // Do we want a "Ready? Go!" screen?
    m_gamestate = GAMESTATE.PLAYING;
  }

  public int m_menuSceneIndex;

  // We do different things with the input depending on the game state, so handle input here.
  private void FixedUpdate()
  {
    switch(m_gamestate)
    {
      case GAMESTATE.PLAYING:
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(Input.GetAxis("Arm Trap") > 0)
        {
          m_player.ArmTrap();
        }

        m_player.MovePlayer(v, h);
        break;

      case GAMESTATE.LOST:
      case GAMESTATE.WON:
        // OnGUI takes care of the visual differences.
        if(Input.GetAxis("Arm Trap") > 0)
        {
          UnityEngine.SceneManagement.SceneManager.LoadScene(m_menuSceneIndex, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        break;
    }
  }

  public void OnGUI()
  {
    switch(m_gamestate)
    {
      case GAMESTATE.LOST:
        GUI.DrawTexture(new Rect(0, 0,
          m_youLostTexture.width > Screen.width ? Screen.width : m_youLostTexture.width,
          m_youLostTexture.height > Screen.height ? Screen.height : m_youLostTexture.width), m_youLostTexture);
        break;
      case GAMESTATE.WON:
        GUI.DrawTexture(new Rect(0, 0,
          m_youWonTexture.width > Screen.width ? Screen.width : m_youWonTexture.width,
          m_youWonTexture.height > Screen.height ? Screen.height : m_youWonTexture.width), m_youWonTexture);
        break;
    }
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

  public void RegisterPlayer(Player player)
  {
    if(m_player != null)
      throw new System.Exception("Two players????");

    m_player = player;
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
    {
      Debug.Log("You win!");
      m_gamestate = GAMESTATE.WON;
    }
    else
      Debug.Log("Not all traps armed.");
  }

  public void OnPlayerKilled()
  {
    Debug.Log("Ouch!");
    m_gamestate = GAMESTATE.LOST;
  }

  private List<Trap> m_traps = new List<Trap> { };
  private static GameManager s_instance;

  private Player m_player;

  private GAMESTATE m_gamestate;

}
