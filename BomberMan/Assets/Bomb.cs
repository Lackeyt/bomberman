using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
  public float countdown = 2f;  //2 second timer

  // Update is called once per frame
  void Update()
  {
    countdown -= Time.deltaTime;  //decriment timer

    if(countdown <= 0f)   //if time = 0, bomb explodes
    {
      FindObjectOfType<MapDestruct>().Explode(transform.position);
      Destroy(gameObject);
    }

    Destroy(this, 2.1f);
  }
}
