using System;
using UnityEngine;

namespace GJApp.Camera
{
    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }
    public class SmoothFollow : MonoBehaviour
    {
        public Transform c_target;
        [SerializeField] Boundary c_boundary;

        void Awake()
        {
            
            if(c_target == null)
            {
                c_target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            
        }

        void FixedUpdate()
        {
            transform.position = new Vector3(c_target.position.x, c_target.position.y, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, c_boundary.xMin, c_boundary.xMax), Mathf.Clamp(transform.position.y, c_boundary.yMin, c_boundary.yMax), transform.position.z);
        }
    }
}