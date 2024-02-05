using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPuzzleSolver : MonoBehaviour
{
    [SerializeField] List<KeyHole> keyHoles;
    [SerializeField] GameObject jumpShelf;
    [SerializeField] GameObject book;

    public static KeyPuzzleSolver instance;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public bool CheckPuzzle()
    {
        for (int i = 0; i < keyHoles.Count; i++)
        {
            if (!keyHoles[i].correctKeyIn) return false;
        }
        return true;
    }

    public void CompletePuzzle()
    {
        book.GetComponent<Collider>().enabled = true;
        book.GetComponent<Rigidbody>().useGravity = true;
        //jumpShelf.SetActive(true);
    }
}
