using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//imagine can be removed after making the background
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace LineSmoothing
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
             * Use Specific image file read in IO
             * read line from image - Image class should do this, constructor should not contain a function
             * *optional step* convert image to a fixed size - scale it
             * The image is converted to an array that can be passed into a Line constructor, this means that the image must be of fixed size (1024x1024)
             * smooth line
             * output smoothed line
             */
            int x = 1024;
            int y = 1024;
            Bitmap image = new Bitmap(x, y, PixelFormat.Format32bppArgb);
            Color[,] test = new Color[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (j%64 <= 1)
                    {
                        image.SetPixel(i, j, Color.FromArgb(255, 0, 255, 0));
                    }
                }
            }
            //image.Save(".\\Lines\\temp\\test.png");


            //Bitmap img = (Bitmap)Image.FromFile(".\\Lines\\LineTest6.png");

            //using this approach our does not have to be of a fixed size, we can find dimensions and store them and then use that for scaling appropraitely
            //currently this is fixed
            //LineImage aLineImage = new LineImage(x, y, img);
            //Is there any beefit to having this as a class? - it certainly keeps code here clean, and allows us to have functions that edit the object to
            //be functions part of that object's class

            //The line image should be made up of several line objects, they can be smoothed seperately
            //We should start by taking the image and an image is made up of a non-descript number of lines, defined by the colour count, which should be a
            //part of the LineImage class
            //ColourCount is added to the LineImage class - but this doesn't behave correctly unless we have a fixed colour
            //test running GUI
            Application.Run(new DrawLine());
        }
    }
}