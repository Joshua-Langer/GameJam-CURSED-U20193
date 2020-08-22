using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJApp.Enemy
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
    public class EnemySO : ScriptableObject
    {
        public Sprite[] sprite;
    }
}
