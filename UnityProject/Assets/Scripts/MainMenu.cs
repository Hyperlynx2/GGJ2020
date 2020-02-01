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

  [Range(0,1)]
  public float m_buttonScale;

  public const float HEIGHT_OFFSET = 25F;
  public const float ELEMENT_HEIGHT = 50;
  public const float ELEMENT_WIDTH = 200;
  public const float SEPARATION = 5;

  public const string MENU_SCENE = "mainmenu";

  public void OnGUI()
  {
    
    if (m_backgroundImage != null)
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), m_backgroundImage);

    float heightOffset = HEIGHT_OFFSET;

    heightOffset += ELEMENT_HEIGHT *2;
      
    foreach(LevelData levelData in levels)
    {
      //TODO: change to be percentage of screen rather than absolute position.

      if(GUI.Button(new Rect(Screen.width * m_widthOffset - levelData.buttonImage.width/ 2,
        heightOffset,
        levelData.buttonImage.width * m_buttonScale,
        levelData.buttonImage.height * m_buttonScale), levelData.buttonImage))
      {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelData.sceneBuildIndex);
      }
        
      heightOffset += ELEMENT_HEIGHT + SEPARATION;
        
    }
  }
}
