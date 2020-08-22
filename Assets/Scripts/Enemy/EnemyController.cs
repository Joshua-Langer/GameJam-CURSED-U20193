using UnityEngine;

namespace GJApp.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public EnemySO e_enemySO;
        Rigidbody2D e_RB;
        Sprite e_sprite;
        SpriteRenderer e_spriteRender;
        Transform e_targetPlayer;
        float e_speed;
        float e_aggroRange = 5;
        int e_maxDistance;
        int e_minDistance;

        void Awake()
        {
            e_sprite = e_enemySO.sprite[Random.Range(0, e_enemySO.sprite.Length)];
            e_spriteRender = GetComponent<SpriteRenderer>();
            e_RB = GetComponent<Rigidbody2D>();
            e_speed = Random.Range(1f, 3f);
            e_targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

            InvokeRepeating("Tick", 0, 0.5f);
        }

        void Start()
        {
            e_spriteRender.sprite = e_sprite;
            e_maxDistance = 10;
            e_minDistance = 5;
        }

        void FixedUpdate()
        {
            
        }

        //Still buggy with enemy jumping to player slightly but enemies do move to player and hit them.
        void Tick()
        {
            if(e_targetPlayer != null && Vector2.Distance(transform.position, e_targetPlayer.transform.position) < e_aggroRange)
            {
                e_RB.velocity = Vector2.one * e_speed;
                transform.position = Vector2.MoveTowards(transform.position, e_targetPlayer.position, e_speed);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, e_aggroRange);
        }

    }
}
