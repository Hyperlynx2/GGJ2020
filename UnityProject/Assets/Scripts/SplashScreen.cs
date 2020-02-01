using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
  public Texture m_splashImage;

  public Texture m_playButton;
  public Vector2 m_playButtonPos;
 
  public Texture m_exitButton;
  public Vector2 m_exitButtonPos;

  [SerializeField]
  [Range(0, 1)]
  public float m_buttonScale;

  public string m_mainMenuScene;

  public GUISkin m_guiSkin;

  // Update is called once per frame
  void OnGUI()
  {
    if(m_guiSkin != null)
      GUI.skin = m_guiSkin;

    GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), m_splashImage);

    if(GUI.Button(new Rect(m_playButtonPos.x * Screen.width,
      m_playButtonPos.y * Screen.height, m_playButton.width * m_buttonScale, m_playButton.height * m_buttonScale), m_playButton))
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(m_mainMenuScene);
    }

    if(GUI.Button(new Rect(m_exitButtonPos.x * Screen.width,
      m_exitButtonPos.y * Screen.height, m_exitButton.width * m_buttonScale, m_exitButton.height * m_buttonScale), m_exitButton))
    {
      Application.Quit();
    }
  }
}
