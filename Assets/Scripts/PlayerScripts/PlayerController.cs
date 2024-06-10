using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    public float movementSpeed, jumpForce;
    public bool isFacingRight, isJump;
    Rigidbody2D rb;
    public float radius;
    public Transform groundChecker;
    public LayerMask whatIsGround;
    Animator anim;
    string run_Parameter = "run";
    string idle_Parameter = "idle";
    string jump_Parameter = "jump";
    string land_Parameter = "land";
    private bool hasAnsweredQuestion = false;
    public GameObject QuestionPanel;
    public YouWinScreen YouWinScreen;
    public GameObject LoseScreenUI;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
    }
    private void FixedUpdate(){

    }
    void Movement(){
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * movementSpeed, rb.velocity.y);

        if (move !=0){
            anim.SetTrigger(run_Parameter);
        } else {
            anim.SetTrigger(idle_Parameter);
        }

        if (move > 0 && !isFacingRight){
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        } else {
            if (move < 0 && isFacingRight){
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            }
        }
    }

    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.velocity = Vector2.up * jumpForce;
        }
        if (!IsGrounded() && !isJump){
            anim.SetTrigger(jump_Parameter);
            isJump = true;
        } else {
            if (IsGrounded() && isJump){
            anim.SetTrigger(land_Parameter);
            isJump = false;
        }}
    }

    bool IsGrounded(){
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
    }
    
    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Number")){
            GameGoal.singleton.CollectNumber();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Question")){
            if (GameGoal.singleton.NumberCollected >= GameGoal.singleton.NumberNeeded){
                if (collision.CompareTag("Question")){
                    QuestionPanel.SetActive(true);
                    hasAnsweredQuestion = true;
                    
                }
            } else {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } else if (collision.CompareTag("Goal")){
            if (GameGoal.singleton.EnterHouse && hasAnsweredQuestion){
                print("YOU WIN UHHUY");
                YouWinScreen.Setup();
            } else {
                print("KUMPULIN DULU ANGKANYA WEH");
            }
        }
    }

    public void StartNew(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AnswerTrue(){
        QuestionPanel.SetActive(false);
    }

    void PlayerLose(){
        LoseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MoveToMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}





        

