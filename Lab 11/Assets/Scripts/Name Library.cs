using System.Collections; // Access to collection types ( IEnumerator )
using System.Collections.Generic; // Access to generic collection types ( Queue<T>, List<T> )
using System.Linq; // Linq stands for Language Integrated Query. Its a minipulater. ( for collections...). .ToList()
using UnityEngine; // Required for MonoBehaviour, Debug, Random

public class LoginQueueManager : MonoBehaviour // Manages a Login queue
{
    // Name libraries
    // Private - only this script can use
    // string[] - an array of strings 
    // userNames - variable name
    // = new string[] - allocate memory for the array and assign values. new instance
    // userNames will store a list of player usernames who will simmulate joining the login queue from "online"
    private string[] userNames = new string[]
    {
        "Juan", "Lays", "Camille", "Chris", "Duck", "Flor", "Nelson",
        "Jordan", "Freddie", "Jamie", "Mitch", "Jordon", "Elias", "Jose",
        "Ivanna", "Morgan", "Reese", "Parker", "Quinn", "Blake",
        "Cameron", "Elliot", "Rowan", "Skyler", "Dakota"
    };
// char[] is an array of characters
// lastInitials - variable name
// .ToCharArray(); - converts the string of letters into an array of characters, so we can randomly select a last initial for our player names.
    private char[] lastInitials = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

// Queue 
    private Queue<string> loginQueue = new Queue<string>();

    void Start()
    {
        // Create initial queue (4–6 players)
        int initialCount = Random.Range(4, 7);

        for (int i = 0; i < initialCount; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }

        // Log initial queue using LINQ
        List<string> queueList = loginQueue.ToList();
        Debug.Log($"Initial login queue created. There are {queueList.Count} players in the queue: {string.Join(", ", queueList)}");

        // Start routines
        StartCoroutine(AddPlayerRoutine());
        StartCoroutine(LoginPlayerRoutine());
    }

    // Helper method to generate random player name
    string GetRandomPlayerName()
    {
        string first = firstNames[Random.Range(0, firstNames.Length)];
        char last = lastInitials[Random.Range(0, lastInitials.Length)];
        return $"{first} {last}.";
    }

    // Coroutine to add players
    IEnumerator AddPlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));

            string newPlayer = GetRandomPlayerName();
            loginQueue.Enqueue(newPlayer);

            Debug.Log($"{newPlayer} is trying to login and added to the login queue.");
        }
    }

    // Coroutine to process login
    IEnumerator LoginPlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            if (loginQueue.Count > 0)
            {
                string player = loginQueue.Dequeue();
                Debug.Log($"{player} is now inside the game.");
            }
            else
            {
                Debug.Log("Login server is idle. No players are waiting.");
            }
        }
    }
}