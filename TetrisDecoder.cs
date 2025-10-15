//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Resources;
//using UnityEngine;

//using DataStructures;
//{
//    [RequireComponent(typeof(MeshFilter))]
//    [RequireComponent(typeof(MeshRenderer))]
//    public class Workshop02 : MonoBehaviour
//{

//    static byte[] sm_palette_tetris = new byte[] { 255, 255, 255, 255, 0, 0 };

//    #region Properties

//    #endregion

//    void Start()
//    {
//        /// DO NOT MODIFY THIS FUNCTION

//        // read data from resource
//        TextAsset encodedTetrisData = Resources.Load<TextAsset>("tetris");

//        // decode data
//        Color[,] decodedTetrisData = DecodeTetrisData(encodedTetrisData.bytes, 7);


//        // create texture
//        if (decodedTetrisData != null)
//        {
//            Texture2D texture = new Texture2D(decodedTetrisData.GetUpperBound(0) + 1, decodedTetrisData.GetUpperBound(1) + 1, TextureFormat.ARGB32, false);
//            texture.filterMode = FilterMode.Point;

//            // copy over data
//            for (int y = 0; y < texture.height; ++y)
//            {
//                for (int x = 0; x < texture.width; ++x)
//                {
//                    texture.SetPixel(x, y, decodedTetrisData[x, y]);
//                }
//            }
//            texture.Apply();

//            // assign to material
//            GetComponent<MeshRenderer>().material.mainTexture = texture;
//        }

//    }

//    protected Color[,] DecodeTetrisData(byte[] data, int width)
//    {
//        Color32[] colorArray = new Color32[sm_palette_tetris.Length / 3];


//        for (int i = 0; i < sm_palette_tetris.Length; i += 3)
//        {
//            byte r = sm_palette_tetris[i];
//            byte g = sm_palette_tetris[i + 1];
//            byte b = sm_palette_tetris[i + 2];
//            byte a = 255;

//            colorArray[i / 3] = new Color32(r, g, b, a);
//        }

//        for (int i = 0; i < colorArray.Length; i++)
//        {
//            Debug.Log(colorArray[i]);
//        }

//        Debug.Log(colorArray.Length);
//        Debug.Log(data.Length / 160);

//        int height = data.Length / width;
//        Color[,] targetArray = new Color[width, height];

//        for (int i = 0; i < data.Length; i++)
//        {
//            Color32 color = colorArray[data[i]];
//            int widthX = i % width;
//            int heightY = i / width;
//            targetArray[widthX, heightY] = color;

//        }
//        return targetArray;


//    }
//}
//}