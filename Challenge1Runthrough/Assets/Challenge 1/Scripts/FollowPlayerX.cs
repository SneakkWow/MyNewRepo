using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Logan Turney
 *Assignment 2
 *Cam position
 */
public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(15, 3, 4);
    private Quaternion rotation = Quaternion.Euler(0, -90, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 rotatedOffset = rotation * offset;
        transform.position = plane.transform.position + offset;

        //transform.rotation = plane.transform.rotation;
    }
}
