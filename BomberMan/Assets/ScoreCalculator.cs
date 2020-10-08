using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
  public GameObject GameObject;
  void Update()
  {
    GameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("score").ToString();
  }
  
}
