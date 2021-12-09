using System;
using System.Drawing;

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

    public LineImage(int xDimension, int yDimension, Bitmap imageBitmap)
    {
        this.x = xDimension;
        this.y = yDimension;
        this.lineImageBitmap = ScaleImage(imageBitmap);
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
}