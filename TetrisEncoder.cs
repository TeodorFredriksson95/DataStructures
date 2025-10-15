using System;
using System.IO;

namespace DataStructures;
class TetrisEncoder
{
    public static void Main()
    {
        // Simple palette:
        // index 0 = white (255,255,255)
        // index 1 = red   (255,0,0)
        byte[] sm_palette = new byte[]
        {
            255, 255, 255,  // white
            255, 0, 0       // red
        };

        // Define grid size
        int width = 7;
        int height = 4;

        // Each pixel = one byte → palette index
        byte[] data = new byte[width * height];

        // Make a simple "Tetris L" pattern
        // 1 = red, 0 = white
        byte[,] pattern = new byte[,]
        {
            {0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0},
            {0,0,0,1,0,0,0},
            {0,0,0,0,0,0,0}
        };

        int index = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                data[index++] = pattern[y, x];
            }
        }

        // Save file next to executable
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        Directory.CreateDirectory(outputDir);

        string filePath = Path.Combine(outputDir, "tetris.bytes");
        File.WriteAllBytes(filePath, data);

        Console.WriteLine($"Tetris bytes file saved to: {filePath}");
        Console.WriteLine("Data preview (palette indices):");

        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(data[i] + " ");
            if ((i + 1) % width == 0) Console.WriteLine();
        }

        Console.WriteLine("\nDone!");
    }
}
