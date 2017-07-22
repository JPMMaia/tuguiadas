using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public static class TextureGenerator
{

    public static Texture2D GetTexture(int width, int height, Tile[,] tiles)
    {
        var texture = new Texture2D(width, height);
        var pixels = new Color[width * height];

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                float value = tiles[x, y].HeightValue;

                //Set color range, 0 = black, 1 = white
                if (value < 0.4f)
                    pixels[x + y * width] = Color.blue;
                else
                    pixels[x + y * width] = Color.white;
            }
        }

        texture.SetPixels(pixels);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.Apply();
        return texture;
    }

}
