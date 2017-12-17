using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class soorma : MonoBehaviour
{
    // Invincibility timer
    float kInvincibilityDuration = 1.0f;
    float mInvincibleTimer;
    bool mInvincible;

    // References to other components and game objects
    Animator mAnimator;
    Rigidbody2D mRigidBody2D;
    List<GroundCheck> mGroundCheckList;

    // Damage effects
    float kDamagePushForce = 2.5f;

    // Wall kicking
    bool mAllowWallKick;
    Vector2 mFacingDirection;

    Vector2 facingDirection = Vector2.right;

    // Variables set in the inspector
    public float WalkSpeed = 3;
    public float RunSpeed = 140;
    public float JumpForce = 5000;
    public AudioSource jumpSound;

    // Booleans used to coordinate with the animator's state machine
    bool Running;
    bool Moving;
    bool Grounded;
    bool Falling;

    // References to other components (can be from other game objects!)
    Animator Animator;
    Rigidbody2D RigidBody2D;
    //AudioSource mJumpSound;

    [SerializeField]
    GameObject mDeathParticleEmitter;

    void Start()

    {
        // Get references to other components and game objects
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
       // mJumpSound = GetComponent<AudioSource>();





    }

    void Update()
    {
        MoveCharacter();
        CheckFalling();
        CheckGrounded();

        // Update animator's variables
        Animator.SetBool("isRunning", Running);
        Animator.SetBool("isMoving", Moving);
        Animator.SetBool("isGrounded", Grounded);
        Animator.SetBool("isFalling", Falling);
    }



    private void MoveCharacter()
    {


        // Check if we are running or not
        // TODO: Check if the player wants Mario to run (see input manager)
        //       and set the value of "Running" accordingly
        //       Use Input and the intellisence
        Running = Input.GetButton("run");


        // Determine movement speed
        float moveSpeed = Running ? RunSpeed : WalkSpeed;
        //Change value    (  IF   )    TRUE    :   FALSE   ;

        // Check for movement
        Moving = Input.GetButton("Horizontal"); //returns true or false if pressed.
        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        FaceDirection(new Vector2(direction, 0));

        // Check if we can jump
        if (Grounded && Input.GetButtonDown("Jump"))
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce);
            if (Input.GetButtonDown("Jump")) ;
                //mJumpSound.Play();





        }

    }

    private void CheckFalling()
    {
        Falling = RigidBody2D.velocity.y < 0.0f;
    }

    private void CheckGrounded()
    {
        Grounded = RigidBody2D.velocity.y == 0.0f;
    }

    void OnCollisionEnter2D(Collision2D col)

    {
        //if (col.gameObject.tag == "Fire")
        if ( col.gameObject.tag == "Fire" )
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverPage");
        }
        
    }

    public Vector2 GetDirection()
    {
        return facingDirection;
    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)  //Don't change look.
            return;

        facingDirection = direction;

        // Flip the sprite (NOTE: Vector3.forward is positive Z in 3D. The Sprite is on XY plane!)
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
    }
    public void Die()
    {
        Instantiate(mDeathParticleEmitter, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene("GameOverPage");
    }
    public void TakeDamage(int dmg)
    {
        if (!mInvincible)
        {
            Vector2 forceDirection = new Vector2(-mFacingDirection.x, 1.0f) * kDamagePushForce;
            mRigidBody2D.velocity = Vector2.zero;
            mRigidBody2D.AddForce(forceDirection, ForceMode2D.Impulse);
            mInvincible = true;
          //  mTakeDamageSound.Play();
            Die();
            SceneManager.LoadScene("GameOverPage");
            //Updatelife();
        }
    }



    /*void OnCollisionEnter2D(Collision2D Col)
    {
     if (Col.gameObject.tag == "enemy" || Col.gameObject.tag == "Fire" || Col.gameObject.tag == "death")
    {
           
            Destroy(gameObject);
    }*/
    //}
}
