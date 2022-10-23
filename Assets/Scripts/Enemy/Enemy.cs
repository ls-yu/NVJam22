using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isAwake = false;
    public EnemyAnimation anim;
    public GameObject player;
    public float moveSpeed;
    public float lightThreshold;
    // controls the random movement
    public float maxMoveTime;
    public float minMoveTime;
    private float moveTimer = 0.0f;
    private Vector3 direction;

    // for targeted movement toward player
    private bool nearPlayer = false;

    // for taking damage
    public float health = 2.0f;
    public float damagePerSecond = 1.0f;

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

        //delete later, just debug purposes
        if (Input.GetKeyDown(KeyCode.W))
        {
            WakeUp();
        }
        
    }

    public void WakeUp(){
        isAwake = true;
        // TODO change the sprite/animation to awake
        anim.WakeUpAnimation();
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("trigger");
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
            health -= Time.deltaTime * damagePerSecond;
            if (health <= 0.0f){
                // TODO play death animation if applicable
                anim.DeathAnimation();
                StartCoroutine(DeathSequence());
                Destroy(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.tag == "player"){
            nearPlayer = false;
            Debug.Log("not near player");
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        Debug.Log("collision");
        if (col.gameObject.tag == "player" && isAwake){

            //TODO GameManager::GameOver();
        }
        else if (col.gameObject.tag == "player" && !isAwake){
            WakeUp();
        }
        if (col.gameObject.tag == "wall"){
            direction *= -1.0f;
            Debug.Log(direction);
        }
    }

    private void Move(){
        if (nearPlayer){
            direction = Vector3.Normalize(player.transform.position - transform.position);
            direction.z = 0.0f;
        }
        else{
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

        transform.position += Time.deltaTime * moveSpeed * direction;
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(0.09f);
    }
}
