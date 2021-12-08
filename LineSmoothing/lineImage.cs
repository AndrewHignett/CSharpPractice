using System;
using System.Drawing;

//Class for the image of a line and all relevant functions
//Here we'll have the image and it's dimensions stored
//Realistically, all this will have is variables for an object, constructors and retrieval methods
class lineImage
{
    //dimensions of input image
    public int x;
    public int y;

    public lineImage(int xDimension, int yDimension, Bitmap imageBitmap)
    {
        this.x = xDimension;
        this.y = yDimension;
        this.lineImageBitmap = imageBitmap;

    }

    //Only has a get, since is set in the constructor
    public Bitmap lineImageBitmap
    { get; }

    //intention here is to reduce the lineto it's midmost parts, as this line will likely be more than 1 pixel wide
    //This will modify the bitmap to be this thin line (or number of lines) on the background
    public void erode()
    {
        //Need to store central points
        for (int i = 0; i < x; i++)
        {

            for (int j = 0; j < y; j++)
            {
                //get the colour of the pixel
                Color clr = this.lineImageBitmap.GetPixel(j, i);
                int red = clr.R;
                int green = clr.G;
                int blue = clr.B;
                Console.WriteLine($"{j} {i} - {red} {green} {blue}");
            }
        }
    }
}