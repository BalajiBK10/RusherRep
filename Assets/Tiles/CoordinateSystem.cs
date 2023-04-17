using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

  [ExecuteAlways]
  [RequireComponent(typeof(TextMeshPro))]
public class CoordinateSystem : MonoBehaviour
{
  [SerializeField] Color defaultColor = Color.white;
  [SerializeField] Color blockedColor = Color.gray;
   TextMeshPro lable;
   Vector2Int coordinate=new Vector2Int();
   WayPoint wayPoint;
  
   void Awake() 
   {
     lable = GetComponent<TextMeshPro>();
     lable.enabled = false;
     wayPoint = GetComponentInParent<WayPoint>();
     DisplayCooradinates();
   }

    // Update is called once per frame
    void Update()
    {
      if(!Application.isPlaying)
      {
        DisplayCooradinates();
        UpdateObjectName();
        lable.enabled = true;
      }   
      SetLableColor();
      ToggleLables();
    }
    void SetLableColor()
    {
      if(wayPoint.IsPlaceable)
      {
        lable.color=defaultColor;
      }
      else
      {
        lable.color=blockedColor;
      }
    }
    void ToggleLables()
    {
      if(Input.GetKeyDown(KeyCode.C))
      {
        lable.enabled =!lable.IsActive();
      }
    }

    void DisplayCooradinates()
    {
       coordinate.x =Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
       coordinate.y=Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
       lable.text = coordinate.x + "," +coordinate.y;
    } 
    void UpdateObjectName()
    {
      transform.parent.name = coordinate.ToString();
    }


}
