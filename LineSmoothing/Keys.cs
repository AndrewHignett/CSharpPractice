using System;

public class Keys
{
    //This could be done with a dictionary
    //Can't be constant, as array items are not initialised until run-time
    //All major keys - this can be adjusted later, for reference we can just used these
    //These could be used to retrieve our list of keys too
    public static String[] TheKeys
    {
        get { return new string[] { "C", "C#", "Db", "D", "Eb", "E", "F", "F#", "Gb", "G", "Ab", "A", "Bb", "B", "Cb" }; }
    }
    //Inclusion of notes based on the keys
    //C, C#, D, D#, E, F, F#, G, G#, A, A#, B
    private static bool[,] Notes = new bool[,] 
            {
                { true, false, true, false, true, true, false, true, false, true, false, true}, //C
                { false, true, false, true, false, true, true, false, true, false, true, true}, //C#
                { true, true, false, true, false, true, true, false, true, false, true, false}, //Db
                { false, true, true, false, true, false, true, true, false, true, false, true}, //D
                { true, false, true, true, false, true, false, true, true, false, true, false}, //Eb
                { false, true, false, true, true, false, true, false, true, true, false, true}, //E
                { true, false, true, false, true, true, false, true, false, true, true, false}, //F
                { false, true, false, true, false, true, true, false, true, false, true, true}, //F#
                { false, true, false, true, false, true, true, false, true, false, true, true}, //Gb
                { true, false, true, false, true, false, true, true, false, true, false, true}, //G
                { true, true, false, true, false, true, false, true, true, false, true, false}, //Ab
                { false, true, true, false, true, false, true, false, true, true, false, true}, //A
                { true, false, true, true, false, true, false, true, false, true, true, false}, //Bb
                { false, true, false, true, true, false, true, false, true, false, true, true}, //B
                { false, true, false, true, true, false, true, false, true, false, true, true}  //Cb
            };

    private string key;
    public bool[] thisNotes = new bool[12];

    public Keys(String key)
    {
        this.key = key;
        //copy the correct key's notes to this key
        Buffer.BlockCopy(Notes, Array.IndexOf(TheKeys, key) * sizeof(bool), this.thisNotes, 0, 12 * sizeof(bool));
    }

}