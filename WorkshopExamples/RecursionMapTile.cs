//using JetBrains.Annotations;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Numerics;
//using UnityEngine;
//namespace DSA
//{
//    [RequireComponent(typeof(MeshFilter))]
//    [RequireComponent(typeof(MeshRenderer))]
//    public class Workshop03 : MonoBehaviour
//    {
//        private bool[,] m_cave = new bool[64, 64];

//        #region Properties

//        public Vector2Int Size => new Vector2Int(m_cave.GetLength(0), m_cave.GetLength(1));

//        #endregion

//        #region DO NOT MODIFY FUNCTIONS WITHIN THIS REGION

//        void Start()
//        {
//            // DO NOT MODIFY THIS FUNCTION
//            GenerateCave();
//            CreateCaveMesh();
//        }

//        protected void CreateCaveMesh()
//        {
//            // DO NOT MODIFY THIS FUNCTION

//            List<Vector3> vertices = new List<Vector3>();
//            List<int> walls = new List<int>();
//            List<int> floor = new List<int>();

//            // add floor and move floor in Z
//            AddQuad(new RectInt(0, 0, m_cave.GetUpperBound(0) + 1, m_cave.GetUpperBound(1) + 1), vertices, floor);
//            vertices = vertices.ConvertAll(v => v + Vector3.forward * 0.1f);

//            // create walls
//            List<RectInt> wallRects = new List<RectInt>();
//            GetWallRects(new RectInt(0, 0, Size.x, Size.y), wallRects);
//            foreach (RectInt r in wallRects)
//            {
//                AddQuad(r, vertices, walls);
//            }

//            // create mesh
//            Mesh mesh = new Mesh();
//            mesh.subMeshCount = 2;
//            mesh.vertices = vertices.ToArray();
//            mesh.uv = vertices.ConvertAll(v => (Vector2)v * 0.25f).ToArray();
//            mesh.SetTriangles(floor.ToArray(), 0);
//            mesh.SetTriangles(walls.ToArray(), 1);
//            mesh.RecalculateBounds();
//            mesh.RecalculateNormals();

//            // assign mesh
//            GetComponent<MeshFilter>().mesh = mesh;
//        }

//        private void AddQuad(RectInt r, List<Vector3> vertices, List<int> triangles)
//        {
//            // DO NOT MODIFY THIS FUNCTION

//            int iStart = vertices.Count;
//            vertices.AddRange(new Vector3[]{
//                new Vector3(r.x, r.y, 0.0f),
//                new Vector3(r.x, r.yMax, 0.0f),
//                new Vector3(r.xMax, r.yMax, 0.0f),
//                new Vector3(r.xMax, r.y, 0.0f)
//            });

//            triangles.AddRange(new int[]{
//                iStart + 0, iStart + 1, iStart + 2,
//                iStart + 2, iStart + 3, iStart + 0
//            });
//        }

//        #endregion

//        protected void GenerateCave()
//        {
//            // STEP 1: Randomly fill m_cave with random bools
//            for (int y = 0; y < Size.y; y++)
//            {
//                for (int x = 0; x < Size.x; x++)
//                {
//                    m_cave[x, y] = UnityEngine.Random.value < 0.45f;
//                }
//            }

//            // STEP 2: Cellular Automata
//            // https://www.roguebasin.com/index.php/Cellular_Automata_Method_for_Generating_Random_Cave-Like_Levels
//            // Follow the steps to produce a cave like level using the 4/5 rule

//            for (int i = 0; i < 5; i++)
//            {
//                CellularAutomata(m_cave);
//            }

//            //StartCoroutine(PaintCave());



//        }

//        IEnumerator PaintCave()
//        {
//            while (true)
//            {
//                yield return new WaitForSeconds(1);
//                CellularAutomata(m_cave);
//                CreateCaveMesh();
//            }
//        }

//        private void CellularAutomata(bool[,] bArray)
//        {


//            Debug.Log("Cellular Automata ran");
//            bool[,] newArray = bArray.Clone() as bool[,];

//            for (int y = 0; y < Size.y; y++)
//            {
//                for (int x = 0; x < Size.x; x++)
//                {
//                    //if (y == 0 || x == 0 || y == Size.y - 1 || x == Size.x -1)
//                    //{
//                    //    newArray[x, y] = true;
//                    //}

//                    int wallCounter = 0;
//                    for (int y1 = -1; y1 <= 1; y1++)
//                    {
//                        for (int x1 = -1; x1 <= 1; x1++)
//                        {
//                            int nX = x + x1;
//                            int nY = y + y1;

//                            if (nX <= 0 || nY <= 0 || nX >= Size.x || nY >= Size.y)
//                            {
//                                wallCounter++;
//                            }
//                            else if (bArray[nX, nY])
//                            {
//                                wallCounter++;
//                            }

//                        }

//                    }
//                    if (newArray[x, y])
//                    {
//                        newArray[x, y] = wallCounter >= 4;
//                    }

//                    else
//                    {
//                        newArray[x, y] = wallCounter >= 5;
//                    }
//                }
//            }
//            m_cave = newArray;

//        }


//        protected void GetWallRects(RectInt area, List<RectInt> walls)
//        {
//            // STEP 3: Replace the code below with a recursive function that checks
//            // if the entire area is 'walls', if so adds the area rectangle...
//            // if not, divides the area in 4 quadrants and recursivly calls GetWallRects()

//            if (area.height == 1 && area.width == 1)
//            {
//                if (m_cave[area.xMin, area.yMin])
//                {
//                    walls.Add(area);
//                    return;
//                }
//            }

//            bool isAllWalls = true;

//            for (int y = area.yMin; y < area.yMax; y++)
//            {
//                for (int x = area.xMin; x < area.xMax; x++)
//                {
//                    if (!m_cave[x, y]) // check if any tile is not a wall
//                    {
//                        isAllWalls = false;
//                        break; // Exit loop if the tile is not a wall
//                    }

//                }
//            }

//            if (isAllWalls)
//            {
//                walls.Add(area);
//                return;
//            }

//            // Get necessary dimensions in order to split the area into a quad.
//            int width = area.width / 2;
//            int height = area.height / 2;

//            GetWallRects(new RectInt(area.xMin, area.yMin, width, height), walls); // bottom left + half width and height, resulting in a 1/4 quad.
//            GetWallRects(new RectInt(area.xMin + width, area.yMin, width, height), walls); // Bottom right
//            GetWallRects(new RectInt(area.xMin, area.yMin + height, width, height), walls); // Top left
//            GetWallRects(new RectInt(area.xMin + width, area.yMin + height, width, height), walls); // Top Right

//        }
//    }
//}