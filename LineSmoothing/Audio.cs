using System;

//Storing the audio class
//This should contain all functions that read and modify the sound file that we're using
//We don't want to call the pitch shifting here, managing the key and which notes we're shifting to is not a part of this class
//this should just be executed here
public class Audio
{
    //we want to read audio from a file, so a filepath element is useful here
    public string filePath;
    //some descriptive features of the file that may be worth knowing, this all should come from the file's header
    public int sampleRate;
    public double length;
    public int channels;
    public int bitsPerSample;

    public Audio(string filePath)
	{
        //dealing with multiple filetypes should be done using abstract classes
        this.filePath = filePath;

	}

    //Read in audio file
    private ReadFile()
    {

    }

    //Shift pitch of the entire sample
    public PitchShift()
    {

    }

    //Shift pitch of subsample
    private SubSamplePitchShift()
    {
        //detect the pitch between samples
    }

    //this gives us a starting point before shifting pitch
    private DetectPitch()
    {
        
    }

    //Resample the waves in use in order to ensure it is of the sample length and sample count as the input waves
    private Resample()
    {

    }

    //Save the edited .wav file to a file, under a new file lane
    private Save()
    {

    }
}
