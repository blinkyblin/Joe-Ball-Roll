using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Control : MonoBehaviour
{
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    [SerializeField] private Transform player;
   
    // Update is called once per frame
    private void Update()
    {
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);  
    }
}
