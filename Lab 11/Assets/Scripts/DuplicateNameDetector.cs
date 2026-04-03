using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DuplicateNameDetector : MonoBehaviour
{
    private string[] firstNames = new string[]
    {
        "Carol", "Adam", "Maria", "John", "Leila", "Chris", "Jordan",
        "Taylor", "Alex", "Sam", "Dylan", "Avery", "Riley", "Casey",
        "Jamie", "Morgan", "Reese", "Parker", "Quinn", "Blake",
        "Cameron", "Elliot", "Rowan", "Skyler", "Dakota"
    };

    void Start()
    {
        // Create random list
        List<string> nameList = new List<string>();

        for (int i = 0; i < 15; i++)
        {
            string randomName = firstNames[Random.Range(0, firstNames.Length)];
            nameList.Add(randomName);
        }

        // Print full list
        Debug.Log("Created the name array: " + string.Join(", ", nameList));

        // Detect duplicates
        HashSet<string> seen = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (string name in nameList)
        {
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }
        }

        // Print results
        if (duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: " + string.Join(", ", duplicates));
        }
        else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}