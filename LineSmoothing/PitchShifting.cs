using System;

//Managing the key and which notes we're shifting to is this class
public class PitchShifting
{
    //we need to store the key, this will be taken from the UI as something that can be selected
    public Keys key;
    //this is the line from line smoothing, we can then match these to notes that the samples can be shifted to appropriately
    public int[] line;

    public void PitchShifting(int[] line, String key)
    {
        this.line = line;
        key = new Keys(key);
        this.key = key;
    }

    //dependent on the key, shift notes to their closest note in line
    public shiftToNotes ()
    {
        //the lines are 3 pixels thick 64 pixels aprt, starting with pixel row 1 (not 0)
        //midpoints are half steps, so each semitone is every step of 32 pixels from pixel 1 onwards, starting C
    }
}
