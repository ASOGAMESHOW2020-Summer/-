using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreasureBox : MonoBehaviour
{
    private Animator animator;
    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            animator = GetComponent<animator>();
            animator.SetBool("touch", true);
        }
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
