using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 distance;    // Start is called before the first frame update
    public GameObject player; 
    void Start()
    {
        distance = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distance;
    }
}
