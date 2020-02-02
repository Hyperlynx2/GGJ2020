using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
  [System.Serializable]
  public struct LevelData
  {
    public Texture buttonImage;
    public int sceneBuildIndex;
  };

  public Texture m_backgroundImage;

  public LevelData[] levels;

  [Range(0,1)]
  public float m_widthOffset;

  [Range(0, 1)]
  public float m_heightOffset;

  [Range(0,1)]
  public float m_buttonScale;

  public GUISkin m_guiSkin;

  public const float SEPARATION = 5;

  public const string MENU_SCENE = "mainmenu";

  public void OnGUI()
  {

    if(m_guiSkin != null)
      GUI.skin = m_guiSkin;
    
    if (m_backgroundImage != null)
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), m_backgroundImage);

    float heightOffset = m_heightOffset * Screen.height;
      
    foreach(LevelData levelData in levels)
    {
      //TODO: change to be percentage of screen rather than absolute position.

      if(GUI.Button(new Rect((Screen.width - levelData.buttonImage.width * m_buttonScale) * m_widthOffset,
        heightOffset,
        levelData.buttonImage.width * m_buttonScale,
        levelData.buttonImage.height * m_buttonScale), levelData.buttonImage))
      {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelData.sceneBuildIndex);
      }
        
      heightOffset += levelData.buttonImage.height * m_buttonScale + SEPARATION;
        
    }
  }
}
