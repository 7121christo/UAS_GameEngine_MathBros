using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllers : MonoBehaviour
{
    public float movementSpeed;
    public bool isFacingRight;
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        if (!ThereIsGround()){
            if (isFacingRight){
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            } else {
                transform.eulerAngles = Vector2.zero;
                isFacingRight = true;
            }
        }
    }

    bool ThereIsGround(){
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}