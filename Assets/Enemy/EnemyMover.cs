using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint>path =new List<WayPoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStar();
        StartCoroutine(FollowPath());
        
    }

    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
          WayPoint wayPoint = child.GetComponent<WayPoint>();
          if(wayPoint != null)
          {
           path.Add(wayPoint);
          }
          
        }
    }
    void ReturnToStar()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }
    IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in path)
        {
           
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent=0f;

            transform.LookAt(endPosition);
           
        while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
               
            }
            
        }
        FinishPath();
       
    }

}
