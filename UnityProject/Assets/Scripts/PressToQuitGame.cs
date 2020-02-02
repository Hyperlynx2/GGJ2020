﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToQuitGame : MonoBehaviour
{
  public string m_quitButtonAxis;

  // Start is called before the first frame update
  void Start()
  {
    DontDestroyOnLoad(this);
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetAxis(m_quitButtonAxis) > 0)
    {
      Application.Quit();
    }
  }
}
