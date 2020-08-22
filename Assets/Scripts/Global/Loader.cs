using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJApp
{
    public class Loader : MonoBehaviour
    {
        public GameObject l_gameManager;

        void Awake()
        {
            if(GameManager.instance == null)
            {
                Instantiate(l_gameManager);
            }
        }
    }
}
