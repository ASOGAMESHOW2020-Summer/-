using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 0.7f);
        Gizmos.DrawCube(transform.position, this.transform.localScale);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
