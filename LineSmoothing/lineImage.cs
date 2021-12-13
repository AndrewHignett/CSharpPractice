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
    public HashSet<Color> uniqueColours;
    //list of lines
    public List<Line> lineList;

    public LineImage(int xDimension, int yDimension, Bitmap imageBitmap)
    {
        this.x = xDimension;
        this.y = yDimension;
        this.lineImageBitmap = ScaleImage(imageBitmap);
        this.uniqueColours = DetectColours(imageBitmap);
        this.colourCount = uniqueColours.Count;
        Console.WriteLine(colourCount);
        this.lineList = new List<Line>();
        HashSet<Color>.Enumerator em = uniqueColours.GetEnumerator();
        while (em.MoveNext())
        {
            Console.WriteLine(em.Current);
            //Specified sample resolution to 4
            Line tempLine = new Line(imageBitmap, em.Current, 4);
            lineList.Add(tempLine);
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

    private HashSet<Color> DetectColours(Bitmap lineImage)
    {
        //hash list of colours
        HashSet<Color> colours = new HashSet<Color>();
        Color background = Color.FromArgb(255, 255, 255, 255);
        //Need to store central points
        for (int i = 0; i < 1024; i++)
        {
            int[,] minMax = new int[colourCount, 2];
            for (int j = 0; j < 1024; j++)
            {
                //get the colour of the pixel
                Color thisColour = lineImage.GetPixel(i, j);
                if (thisColour != background)
                {
                    colours.Add(thisColour);
                }
            }
        }
        return colours;
    }

    public void SaveLine()
    {
        Bitmap a = new Bitmap(1024, 1024);
        for (int i = 0; i < 1024; i++)
        {
            for (int j = 0; j < 1024; j++)
            {
                a.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
            }
        }
        //This iss specific to the first line, when dealing with multiple lines, this will need to be more robust
        int[] thisLine = lineList[0].getFullLine();
        for (int i = 0; i < 1024; i++)
        {
            int location = thisLine[i];
            if (location > -1)
            {
                a.SetPixel(i, location, lineList[0].lineColour);
            }
        }
        a.Save(".\\image.png");
    }

}