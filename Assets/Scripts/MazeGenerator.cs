using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private int sizeX=10; // Länge
    private int sizeY=10; // Breite
    private int sizeZ=3; // Höhe

    public Maze[,,] cells;
    private MazePosition[] stack;

    public MazeGenerator(int sizeX, int sizeY, int sizeZ)
    {
        sizeX = sizeX;
        sizeY = sizeY;
        sizeZ = sizeZ;

        cells = new Maze[sizeX, sizeY, sizeZ];

        // Initialisieren aller Zellen
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    cells[x, y, z] = new Maze();
                }
            }
        }

        // Arraygröße des Stacks entspricht aller Zellen im Labyrinth
        // Die Initialisierung der einzelnen Positionen ist erst später wichtig.
        stack = new MazePosition[sizeX * sizeY * sizeZ];

        // Lediglich die erste Position wird initialisiert und zufällig festgelegt.
        int startX = Random.Range(0, sizeX);
        int startY = Random.Range(0, sizeY);
        int startZ = Random.Range(0, sizeZ);
        stack[0] = new MazePosition(startX, startY, startZ);
        positionInStack = 0;

        // Die erste Zelle an der Startposition wird auf besucht gesetzt: visited = true
        cells[startX, startY, startZ].visited = true;
    }

    private int[] checkNeighbours(MazePosition currentPosition)
    {
        List<int> result = new List<int>();

        int x = currentPosition.x;
        int y = currentPosition.y;
        int z = currentPosition.z;

        // Wand 0 überprüfen 
        if (x - 1 >= 0) // Zuerst überprüfen ob wir überhaupt noch innerhalb der vorgegeben Größe sind
        {
            if (cells[x - 1, y, z].visited == false) result.Add(0); // Füge die Wand 0 hinzu
        }

        // Wand 5 überprüfen 
        if (x + 1 < sizeX) // Zuerst überprüfen ob wir überhaupt noch innerhalb der vorgegeben Größe sind
        {
            if (cells[x + 1, y, z].visited == false) result.Add(5); // Füge die Wand 5 hinzu
        }


        // Wand 1 überprüfen 
        if (y - 1 >= 0) // Zuerst überprüfen ob wir überhaupt noch innerhalb der vorgegeben Größe sind
        {
            if (cells[x, y - 1, z].visited == false) result.Add(1); // Füge die Wand 1 hinzu
        }

        // Wand 4 überprüfen 
        if (y + 1 < sizeY) // Zuerst überprüfen ob wir überhaupt noch innerhalb der vorgegeben Größe sind
        {
            if (cells[x, y + 1, z].visited == false) result.Add(4); // Füge die Wand 4 hinzu
        }


        // Wand 2 überprüfen 
        if (z - 1 >= 0) // Zuerst überprüfen ob wir überhaupt noch innerhalb der vorgegeben Größe sind
        {
            if (cells[x, y, z - 1].visited == false) result.Add(2); // Füge die Wand 2 hinzu
        }

        // Wand 3 überprüfen 
        if (z + 1 < sizeZ) // Zuerst überprüfen ob wir überhaupt noch innerhalb der vorgegeben Größe sind
        {
            if (cells[x, y, z + 1].visited == false) result.Add(3); // Füge die Wand 3 hinzu
        }

        return result.ToArray();
    }

    public void generate()
    {
        // Da der Algorithmus immer dann rückwärts läuft, wenn keine unbesuchten Nachbarzellen gefunden werden,
        // führen wir ihn so lange aus, bis wir wieder am Anfang unseres Stacks sind.
        while (positionInStack >= 0)
        {
            // Die aktuell zu überprüfende Zelle ist im Stack unter der aktuellen Position gespeichert.
            int x = stack[positionInStack].x;
            int y = stack[positionInStack].y;
            int z = stack[positionInStack].z;

            // Überprüfe die Nachbarzellen
            int[] possibleNeighbours = checkNeighbours(stack[positionInStack]);

            if (possibleNeighbours.Length > 0) // Es wurden unbesuchte Nachbarzellen gefunden
            {
                // Wähle eine zufällige Wand aus, durch die der Algorithmus jetzt zur nächsten Zelle geht
                int wall = possibleNeighbours[Random.Range(0, possibleNeighbours.Length)];

                // Setze die gewählte Wand in der aktuellen Zelle auf false (= existiert nicht = Durchgang)
                cells[x, y, z].walls[wall] = false;

                // Bestimme die neuen Koordinaten anhand der ausgewählten Wand
                if (wall == 0) x--;
                else if (wall == 5) x++;
                else if (wall == 1) y--;
                else if (wall == 4) y++;
                else if (wall == 2) z--;
                else if (wall == 3) z++;

                // Und setze die neue Zelle auf besucht und öffne die Wand (die gegenüberliegend von der, der vorherigen Zelle ist)
                // sowie erhöhe den Stack um eins und setze die neue Position
                positionInStack++;
                stack[positionInStack] = new MazePosition(x, y, z);
                cells[x, y, z].visited = true;
                cells[x, y, z].walls[5 - wall] = false;
            }

            else // Es wurden keine unbesuchten Nachbarzellen gefunden
            {
                // Also gehe eine Position im Stack zurück
                positionInStack--;
                // Und überprüfe anschließend erneut die jetzt aktuelle Zelle auf unbesuchte Nachbarzellen
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public class MazePosition
    {
        public int x, y, z;

        public MazePosition(int posX, int posY, int posZ)
        {
            x = posX;
            y = posY;
            z = posZ;
        }
    }
}