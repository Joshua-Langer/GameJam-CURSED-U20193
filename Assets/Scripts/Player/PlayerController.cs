using GJApp.UI;
using System;
using UnityEngine;

namespace GJApp.Player
{
    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Boundary p_boundary;
        Rigidbody2D p_RB;

        float p_acceleration = 4f;

        void Awake()
        {
            p_RB = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Controls();
        }

        void Controls()
        {
            float t_moveVertical = Input.GetAxis("Vertical");
            float t_moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 t_movement = new Vector2(t_moveHorizontal, t_moveVertical);
            p_RB.velocity = t_movement * p_acceleration;

            p_RB.position = new Vector2(Mathf.Clamp(p_RB.position.x, p_boundary.xMin, p_boundary.xMax), Mathf.Clamp(p_RB.position.y, p_boundary.yMin, p_boundary.yMax));
        }

        //COLLISION
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == "Exit" && PlayerManager.p_instance.p_HealItem)
            {
                GameManager.instance.NextLevel();
            }
            if(collision.collider.tag == "Enemy")
            {
                DamagePlayer();
            }
            if (collision.collider.tag == "Item") 
            {
                Destroy(collision.gameObject);
                HealPlayer();
            }
            if(collision.collider.tag == "Heal Item")
            {
                Destroy(collision.gameObject);
                PlayerManager.p_instance.p_HealItem = true;
            }
        }

        void HealPlayer()
        {
            PlayerManager.p_instance.p_health += 5;
            if (PlayerManager.p_instance.p_health >= 100)
            {
                PlayerManager.p_instance.p_health = 100;
            }
            PlayerHealthBar.SetHealthBarValue(PlayerHealthBar.GetHealthBarValue() + .05f);
        }

        void DamagePlayer()
        {
            PlayerManager.p_instance.p_health -= 10;
            PlayerHealthBar.SetHealthBarValue(PlayerHealthBar.GetHealthBarValue() - 0.10f);
            if(PlayerManager.p_instance.p_health <= 0)
            {
                OnPlayerDeath();
            }
        }

        void OnPlayerDeath()
        {
            Destroy(gameObject);
            GameManager.instance.StartCoroutine("Restart", 5);
        }
    }
}
