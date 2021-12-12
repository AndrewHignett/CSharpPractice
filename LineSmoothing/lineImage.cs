using System;
using System.Drawing;
using System.Collections.Generic;

//Class for the image of a line and all relevant functions
//Here we'll have the image and it's dimensions stored
//Realistically, all this will have is variables for an object, constructors and retrieval methods
class LineImage
{
    //dimensions of input image
    public int x;
    public int y;
    //image
    public Bitmap lineImageBitmap;
    //number of lines, colour count
    public int colourCount;

    public LineImage(int xDimension, int yDimension, Bitmap imageBitmap)
    {
        this.x = xDimension;
        this.y = yDimension;
        this.lineImageBitmap = ScaleImage(imageBitmap);
        this.colourCount = DetectColours(imageBitmap);
        Console.WriteLine(colourCount);
        while (true)
        {

        }
    }

    //Only has a get, since is set in the constructor
    public Bitmap LineImageBitmap
    { get { return lineImageBitmap; } }

    //Placeholder for scaling the image to 1024x1024
    private Bitmap ScaleImage(Bitmap imageBitmap)
    {
        //scaling to 1024x1024 goes here
        return imageBitmap;
    }

    private int DetectColours(Bitmap lineImage)
    {
        //hash list of colours
        HashSet<Color> colours = new HashSet<Color>();
        //Need to store central points
        for (int i = 0; i < 1024; i++)
        {
            int[,] minMax = new int[colourCount, 2];
            for (int j = 0; j < 1024; j++)
            {
                //get the colour of the pixel
                colours.Add(lineImage.GetPixel(i, j));
                Console.WriteLine(lineImage.GetPixel(i, j));
            }
        }
        return colours.Count;
    }
}