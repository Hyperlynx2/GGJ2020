using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
  [System.Serializable]
  public struct LevelData
  {
    public string name;
    public int sceneBuildIndex;
  };

  public LevelData[] levels;

  public const float HEIGHT_OFFSET = 25F;
  public const float ELEMENT_HEIGHT = 50;
  public const float ELEMENT_WIDTH = 200;
  public const float SEPARATION = 5;

  public const string MENU_SCENE = "mainmenu";

  public void OnGUI()
  {
    //GUI.skin = skin;
    
    float heightOffset = HEIGHT_OFFSET;

    heightOffset += ELEMENT_HEIGHT *2;
      
    //god help you if you haven't got the labels and scenes right sized!
    for(int i = 0; i < levels.Length; ++i)
    {
      //TODO: change to be percentage of screen rather than absolute position.

      if(GUI.Button(new Rect(Screen.width /2 - ELEMENT_WIDTH/2, heightOffset, ELEMENT_WIDTH, ELEMENT_HEIGHT), levels[i].name))
      {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levels[i].sceneBuildIndex);
      }
        
      heightOffset += ELEMENT_HEIGHT + SEPARATION;
        
    }
  }
}
