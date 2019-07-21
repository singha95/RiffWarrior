using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNoteEndController : MonoBehaviour
{
    public GameObject triggerHitNote;
    private GuitarNotesController notesScript;

    void Start()
    {
        var parent = transform.parent;
        while (parent != null && parent.name != "GuitarNotes")
        {
            parent = parent.transform.parent;
        }
        if(parent != null)
        {
            notesScript = parent.GetComponent<GuitarNotesController>();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerHitNote = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerHitNote = null;
        notesScript.RemoveNote(other.gameObject, false);
    }
}