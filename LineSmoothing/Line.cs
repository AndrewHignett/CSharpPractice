using System;
using System.Drawing;

//A line is defined by an array
public class Line
{
    public int[,] line;


    //need a constructure here
    public Line(Bitmap lineImage)
    {
        int[,] thisLine = Erode(lineImage);
        this.line = LaplaceSmoothing(thisLine);
    }

    //intention here is to reduce the line to it's midmost parts, as this line will likely be more than 1 pixel wide
    //This will modify the bitmap to be this thin line (or number of lines) on the background
    private int[,] Erode(Bitmap lineImage)
    {
        //local copy of array of y locations at each x point in the image
        //eroding will only work with the fixed size image
        int[,] tempLine = new int[1024, 5];
        //for multiple lines, we will need to count colours first and then use this when checking colours, limit this to 5
        //these are temporarily predefined for functionality on black and white
        Color tempColour = Color.FromArgb(255, 0, 0, 0);
        Color[] colours = { tempColour };
        int colourCount = 1;
        //Need to store central points
        for (int i = 0; i < 1024; i++)
        {
            int[,] minMax = new int[colourCount, 2];
            for (int j = 0; j < 1024; j++)
            {
                //get the colour of the pixel
                Color clr = lineImage.GetPixel(i, j);
                if (tempColour == clr)
                {
                    if (minMax[Array.IndexOf(colours, clr), 0] == 0)
                    {
                        minMax[Array.IndexOf(colours, clr), 0] = j;
                    }
                    minMax[Array.IndexOf(colours, clr), 1] = j;
                }
            }
            for (int colourInc = 0; colourInc < colourCount; colourInc++)
            {
                //store the midpoint
                tempLine[i, colourInc] = 1023 - (minMax[colourInc, 0] + (minMax[colourInc, 1] - minMax[colourInc, 0]) / 2);
            }
        }
        return tempLine;
    }

    //Butterworth filter for smoothing the line, this will be applied to the line as defined in order to smooth it
    public void ButterworthFilter()
    {

    }

    //Laplacian smoothing of the 2D coordinates
    private int[,] LaplaceSmoothing(int[,] thisLine)
    {
        int iterations = 5;
        //colourCount will need to be updated to a max of 5
        int colourCount = 1;
        //Trying without copying any arrays as much
        int[] tripleTemp = new int[3];
        //Use a same size array to store smoothed values
        int[,] thisLineCopy = new int[1024, 5];
        //tempoarary array to store
        for (int j = 0; j < iterations; j++) {
            for (int colour = 0; colour < colourCount; colour++)
            {
                for (int i = 1; i < 1023; i++)
                {
                    tripleTemp[0] = thisLine[i - 1, colour];
                    tripleTemp[1] = thisLine[i, colour];
                    tripleTemp[2] = thisLine[i + 1, colour];
                    //Copy to the temporaryArray
                    thisLineCopy[i, colour] = tripleTemp[1] + (tripleTemp[0] + tripleTemp[2] - 2 * tripleTemp[1]) / 2;
                }
                //Update the currentLine to the values from the tempoary array
                for (int copyIter = 1; copyIter < 1023; copyIter++)
                {
                    thisLine[copyIter, colour] = thisLineCopy[copyIter, colour];
                }
            }
        }
        return thisLine;
    }
}
