using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
  public Image im;
  void Update()
  {
    im.CrossFadeAlpha(.2f,2f,false);
  }
  
}
