using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GJApp.Board
{
    public class BoardManager : MonoBehaviour
    {
        [Serializable]
        public class Count
        {
            public int c_minimum;
            public int c_maximum;

            public Count(int min, int max)
            {
                c_minimum = min;
                c_maximum = max;
            }
        }

        public int b_columns;
        public int b_rows;
        public Count b_wallCount = new Count(30, 45);
        public Count b_itemCount = new Count(8, 15);
        public GameObject b_exit;
        public GameObject b_healItem;
        public GameObject[] b_floorTiles;
        public GameObject[] b_wallTiles;
        public GameObject[] b_itemTiles;
        public GameObject[] b_enemyTiles;
        public GameObject[] b_outerWallTiles;
        public Transform b_boardContainer;
        private List<Vector3> b_gridPos = new List<Vector3>();

        void InitializeList()
        {
            b_gridPos.Clear();
            for(int x = 1; x < b_columns - 1; x++)
            {
                for(int y = 1; y < b_rows - 1; y++)
                {
                    b_gridPos.Add(new Vector3(x, y, 0f));
                }
            }
        }

        void BoardSetup()
        {
            b_boardContainer = new GameObject("Game Board").transform;

            for(int x = -1; x < b_columns + 1; x++)
            {
                for(int y = -1; y < b_rows + 1; y++)
                {
                    GameObject toInstantiate = b_floorTiles[Random.Range(0, b_floorTiles.Length)];
                    if(x == -1 || x == b_columns || y == -1 || y == b_rows)
                    {
                        toInstantiate = b_outerWallTiles[Random.Range(0, b_outerWallTiles.Length)];
                    }
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(b_boardContainer);
                }
            }
        }

        Vector3 RandomPosition()
        {
            int t_randomIndex = Random.Range(0, b_gridPos.Count);
            Vector3 t_randomPos = b_gridPos[t_randomIndex];
            b_gridPos.RemoveAt(t_randomIndex);
            return t_randomPos;
        }

        void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
        {
            int t_objectCount = Random.Range(minimum, maximum + 1);
            for(int i = 0; i < t_objectCount; i++)
            {
                Vector3 t_randomPosition = RandomPosition();
                GameObject t_tileChoice = tileArray[Random.Range(0, tileArray.Length)];
                Instantiate(t_tileChoice, t_randomPosition, Quaternion.identity);
            }
        }

        public void SetupScene(int level)
        {
            BoardSetup();
            InitializeList();
            LayoutObjectAtRandom(b_wallTiles, b_wallCount.c_minimum, b_wallCount.c_maximum);
            LayoutObjectAtRandom(b_itemTiles, b_itemCount.c_minimum, b_itemCount.c_maximum);
            int t_enemyCount = (int)Mathf.Log(level, 2f);
            LayoutObjectAtRandom(b_enemyTiles, t_enemyCount, t_enemyCount);
            Instantiate(b_healItem, new Vector3(b_columns - 25, b_rows - 18, 0f), Quaternion.identity);
            Instantiate(b_exit, new Vector3(b_columns - 1, b_rows - 1, 0f), Quaternion.identity);
        }
    }
}
