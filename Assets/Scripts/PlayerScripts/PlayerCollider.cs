using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag.Equals("Question")){
            print("Ini Soal");
        }
        
    }

    // Start is called before the first frame update
    
}
