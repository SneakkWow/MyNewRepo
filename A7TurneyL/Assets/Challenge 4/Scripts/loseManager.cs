using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseManager : MonoBehaviour
{

    public SpawnManagerX SM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.tag == "Enemy")
        {
            SM.Lose();
        }
    }
}
