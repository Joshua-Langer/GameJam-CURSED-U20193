using UnityEngine;

namespace GJApp.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager p_instance = null;

        public int p_health = 100;
        public bool p_HealItem = false;

        void Awake()
        {
            if(p_instance == null)
            {
                p_instance = this;
            }
            else if (p_instance != this)
            {
                Destroy(gameObject);
            }
        }

    }
}
