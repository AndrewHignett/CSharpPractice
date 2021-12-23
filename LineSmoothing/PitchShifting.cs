using System;

 //Managing the key and which notes we're shifting to is this class
public class PitchShifting
{
    //we need to store the key, this will be taken from the UI as something that can be selected
    public Keys key;
    //this is the line from line smoothing, we can then match these to notes that the samples can be shifted to appropriately
    public int[] line;

    public PitchShifting(int[] line, String key)
    {
        this.line = line;
        this.key = new Keys(key);
    }

    //dependent on the key, shift notes to their closest note in line
    public void shiftToNotes ()
    {
        //the lines are 3 pixels thick 64 pixels aprt, starting with pixel row 1 (not 0)
        //midpoints are half steps, so each semitone is every step of 32 pixels from pixel 1 onwards, starting C

        //All c notes are (y - 1)%(12*32) == 0
        //where bool index true, let bool index = i, then (y - 1 + 32*i)%(12*32) gives octave
        //index of bool array is integer division of (y - 1)/32, if > 11 then %12 the result of the integer division
        //we must first find the closest note, if this isn't valid, we must then assign it to the next closest note
        //there are never two falses in a row
        //in order to find the closest note, we can do (y - 1)%32, if this is <= 16, then we must increase the note
        //if this is 16 < then decrease the note
        int x = 0;
        foreach (int y in this.line)
        {
            if (y > -1)
            {
                //invert to line as the image is treated as upsidedown
                int invertY = 1023 - y;
                int noteIndex = (invertY - 1) / 32;
                int octave = noteIndex / 12;
                if (noteIndex > 11)
                {
                    noteIndex %= 12;
                }

                if (octave > 0)
                {
                    this.line[x] = 1024 - ((noteIndex + 12 * octave) * 32 + 1);
                }
                else
                {
                    this.line[x] = 1024 - (noteIndex * 32 + 1);
                }

                //Adjust to match key
                if (!this.key.thisNotes[noteIndex])
                {
                    //if the closest note is not a part of the key
                    if ((invertY - 1) % 32 <= 16)
                    {
                        this.line[x] += 32;
                    }
                    else
                    {
                        this.line[x] -= 32;
                    }
                }
            }
            x++;
        }
    }
}