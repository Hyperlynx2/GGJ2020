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

  // Update is called once per frame
  void OnGUI()
  {
    GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), m_splashImage);

    if(GUI.Button(new Rect(m_playButtonPos.x, m_playButtonPos.y, m_playButton.width * m_buttonScale, m_playButton.height * m_buttonScale), m_playButton))
      UnityEngine.SceneManagement.SceneManager.LoadScene(m_mainMenuScene);

    if(GUI.Button(new Rect(m_exitButtonPos.x, m_exitButtonPos.y, m_exitButton.width * m_buttonScale, m_exitButton.height * m_buttonScale), m_exitButton))
      Application.Quit();
  }
}
