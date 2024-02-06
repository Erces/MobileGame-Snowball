using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointSystem : MonoBehaviour
{
    public float point;
    public TMP_Text text;

    void Update(){
        point += Time.deltaTime;
        text.text = point.ToString("0");
      
       
    }

}
