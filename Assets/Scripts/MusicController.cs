using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource source;

    private string binFile;
    public string FileName
    {
        get
        {
            return Path.GetFileName(binFile);
        }
        set
        {
            binFile = Application.dataPath + Path.DirectorySeparatorChar + "Bins"
                        + Path.DirectorySeparatorChar + value;
            
            if (!File.Exists(binFile))
            {
                Debug.LogError("Bin file not found.");
                songNotes = new MusicNotes(new List<Note>());
            }
            else
            {
                songNotes = MusicNotesSerialization.Deserialize(binFile);
            }
        }
    }

    private int numLanes;
    private MusicNotes songNotes;
    private GuitarNotesController notesController;

    private void Start()
    {
        notesController = GetComponent<GuitarNotesController>();
        songNotes.deltaDelay = notesController.time;
        numLanes = 5;
        songNotes.numLanes = numLanes;
    }

    private void OnEnable()
    {
        source.Play();
    }

    private void Update()
    {
        if (source.isPlaying)
        {
            List<Note> newNotes = songNotes.GetNotesAtTime(source.time);

            foreach (var note in newNotes)
            {
                if (newNotes.Count != 0)
                {
                    notesController.GenerateNote(note.Pitch % numLanes);
                }
            }
        }
    }
}