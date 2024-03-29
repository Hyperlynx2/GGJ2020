﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTile : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    GameManager.get().OnExitTileReached();
  }

  private void OnTriggerExit(Collider other)
  {
    GameManager.get().OnExitTileLeft();
  }

}
