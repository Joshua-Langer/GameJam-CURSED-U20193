using GJApp.Player;
using System.Collections;
using UnityEngine;

namespace GJApp.Level
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager l_levelMan = null;

        public float l_lifeTimer;

        void Awake()
        {
            if(l_levelMan == null)
            {
                l_levelMan = this;
            }
            else if (l_levelMan != this)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            FreezeLifeTime();
        }

        void FreezeLifeTime()
        {
            if (Time.timeScale == 1 && !PlayerManager.p_instance.p_HealItem)
            {
                l_lifeTimer -= Time.deltaTime;
            }
            else if(Time.timeScale == 0 || PlayerManager.p_instance.p_HealItem)
            {
                StartCoroutine("ProtectionOff");
                return;
            }
        }

        
        IEnumerator ProtectionOff()
        {
            yield return new WaitForSeconds(60);
            PlayerManager.p_instance.p_HealItem = false;
        }
        
    }
}
