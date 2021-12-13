using System;
using System.Drawing;

//A line is defined by an array
public class Line
{
    public int[] line;
    public Color lineColour;
    public int sampleRes;


    //need a constructure here
    public Line(Bitmap lineImage, Color colour, int sampleRes)
    {
        this.sampleRes = sampleRes;
        this.lineColour = colour;
        //int[] thisLine = Erode(lineImage);
        //this.line = LaplaceSmoothing(thisLine, 4);
        //sample();
        this.line = Erode(lineImage);
        int[] thisLine = sample();
        this.line = LaplaceSmoothing(thisLine);
    }

    //intention here is to reduce the line to it's midmost parts, as this line will likely be more than 1 pixel wide
    //This will modify the bitmap to be this thin line (or number of lines) on the background
    private int[] Erode(Bitmap lineImage)
    {
        //local copy of array of y locations at each x point in the image
        //eroding will only work with the fixed size image
        int[] tempLine = new int[1024];
        //Need to store central points
        for (int i = 0; i < 1024; i++)
        {
            int[] minMax = new int[2];
            for (int j = 0; j < 1024; j++)
            {
                //get the colour of the pixel
                Color clr = lineImage.GetPixel(i, j);
                if (this.lineColour == clr)
                {
                    if (minMax[0] == 0)
                    {
                        minMax[0] = j;
                    }
                    minMax[1] = j;
                }
            }
            //store the midpoint
            tempLine[i] = (minMax[0] + (minMax[1] - minMax[0]) / 2);
            if (minMax[0] == 0 && minMax[1] == 0)
            {
                //store as -1, if we don't have the line for that part
                //this must be dealt with seperately
                tempLine[i] = -1;
            }            
        }
        return tempLine;
    }

    //Laplacian smoothing of the 2D coordinates - this deals with rather extreme cases that need to be smoothed out
    private int[] LaplaceSmoothing(int[] thisLine)
    {
        int iterations = 10000;
        //Trying without copying any arrays as much
        int[] tripleTemp = new int[3];
        //Use a same size array to store smoothed values
        int[] thisLineCopy = new int[1024/sampleRes];
        for (int j = 0; j < iterations; j++)
        {
            for (int i = 1; i < thisLineCopy.Length - 1; i++)
            {
                tripleTemp[0] = thisLine[i - 1];
                tripleTemp[1] = thisLine[i];
                tripleTemp[2] = thisLine[i + 1];
                //Copy to the temporaryArray
                if (tripleTemp[0] > -1 && tripleTemp[2] > -1)
                {
                    thisLineCopy[i] = tripleTemp[1] + (tripleTemp[0] + tripleTemp[2] - 2 * tripleTemp[1]) / 2;
                }
                else
                {
                    thisLineCopy[i] = thisLine[i];
                }
            }
            //Update the currentLine to the values from the tempoary array
            for (int copyIter = 1; copyIter < thisLineCopy.Length - 1; copyIter++)
            {
                thisLine[copyIter] = thisLineCopy[copyIter];
                
            }
            
        }
        return thisLine;
    }

    //Sampling to help with smoothing, this should be a simple method to removing higher frequency noise that could be
    //introduced by shakes
    private int[] sample()
    {
        int[] sampleLine = new int[1024/sampleRes];
        int[] newLine = new int[1024];
        //take a sample every 4 pixels
        for (int i = 0; i < sampleLine.Length; i++)
        {
            sampleLine[i] = this.line[i*sampleRes];
        }
        return sampleLine;
    }


    public int[] getFullLine()
    {
        int[] outputLine = new int[1024];
        for (int i = 0; i < this.line.Length; i++)
        {
            outputLine[i * sampleRes] = this.line[i];
        }
        return outputLine;
    }
}
