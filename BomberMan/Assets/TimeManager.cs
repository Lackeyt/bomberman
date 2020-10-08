using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
  public int countdownTime;
  public Text countdownText;

  private void Start()
  {
    StartCoroutine(Countdown());
  }
  IEnumerator Countdown()
  {
    while(countdownTime >= 0)
    {
      countdownText.text = countdownTime.ToString();

      yield return new WaitForSeconds(1f);

      countdownTime--;
    }

    FindObjectOfType<GameManager>().GameOver();

  }
}
