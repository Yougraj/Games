using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    // Start is called before the first frame update

    [SerializeField] [Range(0f, 5f)]float speed = 1f;
    void Start()
    {
        Debug.Log("Start here");
        StartCoroutine(PrintWayPointName());
        Debug.Log("Stop here");

    }
    IEnumerator PrintWayPointName()
    {
        foreach(WayPoint WayPoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = WayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f){
              travelPercent += Time.deltaTime * speed;
              transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
              yield return new WaitForEndOfFrame();
            } 
        }
    }
}
