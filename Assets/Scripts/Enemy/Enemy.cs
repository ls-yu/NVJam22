using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isAwake = false;
    public EnemyAnimation anim;
    public GameObject player;
    public float moveSpeed = 0.5f;
    public float lightThreshold = 25f;
    // controls the random movement
    public float maxMoveTime = 3f;
    public float minMoveTime = 1f;
    private float moveTimer = 0.0f;
    private Vector3 direction;

    // for targeted movement toward player
    private bool nearPlayer = false;
    public float runSpeed = 0.7f;
    private bool touchingLight = false;

    // for taking damage
    public float health = 2.0f;
    public float damagePerSecond = 1.0f;
    private bool takingDamage = false;

    //attack
    public float attackCooldown = 0.5f;
    public float attackTimer = 0.0f;

    public GameObject attackSound;
    public GameObject wakeSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAwake){
            Move();
        }
        
    }

    public void WakeUp(){
        StartCoroutine(WakeSequence());
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("trigger");
        if (other.tag == "light"){
            touchingLight = true;
        }
        if (other.tag == "light" && !isAwake){
            WakeUp();
        }
        if (other.tag == "player"){
            nearPlayer = true;
            Debug.Log("near player");
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.tag == "light" && other.GetComponent<LightScript>().angle <= lightThreshold){
            if (!takingDamage){
                takingDamage = true;
                anim.TakeDamageAnimation();
            }
            health -= Time.deltaTime * damagePerSecond;
            Debug.Log("taking damage");
            if (health <= 0.0f){
                Debug.Log("death");
                anim.DeathAnimation();
                StartCoroutine(DeathSequence());
            }
        }
        if (other.tag == "light" && other.GetComponent<LightScript>().angle > lightThreshold){
            takingDamage = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.tag == "player"){
            nearPlayer = false;
            Debug.Log("not near player");
        }
        if (other.tag == "light"){
            takingDamage = false;
            touchingLight = false;
            anim.WakeUpAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        Debug.Log("collision");
        if (col.gameObject.tag == "player" && isAwake){
            attackTimer = attackCooldown;
            anim.AttackAnimation();
            Instantiate(attackSound, transform);
        }
        else if (col.gameObject.tag == "player" && !isAwake){
            WakeUp();
        }
        else if (col.gameObject.tag == "wall" || col.gameObject.tag == "fox"){
            direction *= -1.0f;
            Debug.Log(direction);
        }
    }

    private void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "player" && isAwake){
            if (attackTimer == attackCooldown){
                player.GetComponent<PlayerHealth>().TakeDamage(1);
            }
            attackTimer-=Time.deltaTime;
            if (attackTimer < 0.0f){
                anim.AttackAnimation();
                attackTimer = attackCooldown;
                player.GetComponent<PlayerHealth>().TakeDamage(1);
                Instantiate(attackSound, transform);
            }
        }
    }

    private void Move(){
        float speed;
        if (nearPlayer || touchingLight){
            direction = Vector3.Normalize(player.transform.position - transform.position);
            direction.z = 0.0f;
            speed = runSpeed;
        }
        else{
            speed = moveSpeed;
            moveTimer-= Time.deltaTime;
            if (moveTimer <= 0f){
                moveTimer = Random.Range(minMoveTime, maxMoveTime);
                int dir = Random.Range(0,4);
                if (dir == 0){ // left
                    direction = Vector3.left;
                }
                else if (dir == 1){// right
                    direction = Vector3.right;
                }
                else if (dir == 2){ // up
                    direction = Vector3.up;
                }
                else if (dir == 3){
                    direction = Vector3.down;
                }
            }
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, angle - 180);

        transform.position += Time.deltaTime * speed * direction;
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    IEnumerator WakeSequence(){
        yield return new WaitForSeconds(0.8f);
        if(isAwake == false){
            Instantiate(wakeSound, transform);
        }
        isAwake = true;
        anim.WakeUpAnimation();
    }
}
