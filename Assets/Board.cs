using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{
    public Cell CellPrefab;
    public GameObject PawnPrefab;
    public GameObject bishopPrefab;
    public GameObject rookPrefab;
    public GameObject kingPrefab;
    public GameObject knightPrefab;
    public GameObject queenPrefab;

    public GameObject PawnPrefabB;
    public GameObject bishopPrefabB;
    public GameObject rookPrefabB;
    public GameObject kingPrefabB;
    public GameObject knightPrefabB;
    public GameObject queenPrefabB;

    public const int King = 2;

    public const int Pawn = 3;

    public const int Knight = 4;

    public const int Bishop = 5;

    public const int Rook = 6;

    public const int Queen = 7;

    public const int KingB = 12;

    public const int PawnB = 13;

    public const int KnightB = 14;

    public const int BishopB = 15;

    public const int RookB = 16;

    public const int QueenB = 17;

    public List<Cell> Cells;

    public int[,] grid;

    public int PawnLimit = 0;

    public Material blackMaterial;

    public Material whiteMaterial;

    public void generate() {
        Cells = new List<Cell> ();

        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                Cells.Add(createCell (x, y, (x + y) % 2));
                populate(x, y);
            }
        }
    }

    public void Moves() {

    }

    Cell createCell(int posx, int posy, int type) {
        Cell newCell = Instantiate (CellPrefab) as Cell;

        if (type == 0) {
            newCell.GetComponent<Renderer> ().material = blackMaterial;
        } else {
            newCell.GetComponent<Renderer> ().material = whiteMaterial;
        }

        newCell.x = posx;
        newCell.y = posy;

        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3 (posx, posy, 0);

        newCell.name = "Board cell [" + posx + "," + posy + "]";

        return newCell;
        //return null;
    }

    public void populate(int x, int y) 
    {
        //Debug.Log("Populate Function Called");
        //Debug.Log("test");
        //Debug.Log(x);
       // Debug.Log(y);
        //cellInstance.occupied = true;
            switch (grid [x, y])
            {
                case 3:
                    if (PawnLimit < 20) {
                        //Debug.Log("Pawn");
                        GameObject newPawn = Instantiate (PawnPrefab) as GameObject;
                        newPawn.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                        PawnLimit= PawnLimit + 1;
                    }
                    break;
                case 0:
                    //Debug.Log("gggggg");
                    break;
            
                case 5:
                    GameObject newBishop = Instantiate (bishopPrefab) as GameObject;
                    newBishop.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break; 

                case 4:
                    GameObject newKnight = Instantiate (knightPrefab) as GameObject;
                    newKnight.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;

                case 2:
                    GameObject newKing = Instantiate (kingPrefab) as GameObject;
                    newKing.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;     

                case 7:
                    GameObject newQueen = Instantiate (queenPrefab) as GameObject;
                    newQueen.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;
                    
                case 6:
                    GameObject newRook = Instantiate (rookPrefab) as GameObject;
                    newRook.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;

                case 13:
                    if (PawnLimit < 20) {
                        //Debug.Log("Pawn");
                        GameObject newPawnB = Instantiate (PawnPrefabB) as GameObject;
                        newPawnB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                        PawnLimit= PawnLimit + 1;
                    }
                    break;

                case 15:
                    GameObject newBishopB = Instantiate (bishopPrefabB) as GameObject;
                    newBishopB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break; 

                case 14:
                    GameObject newKnightB = Instantiate (knightPrefabB) as GameObject;
                    newKnightB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;

                case 12:
                    GameObject newKingB = Instantiate (kingPrefabB) as GameObject;
                    newKingB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;     

                case 17:
                    GameObject newQueenB = Instantiate (queenPrefabB) as GameObject;
                    newQueenB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;
                    
                case 16:
                    GameObject newRookB = Instantiate (rookPrefabB) as GameObject;
                    newRookB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    break;
            }
        
            
        
    }
    // Start is called before the first frame update
    void Start()
    {

        grid = new int[8,8];

        //boardInstance.generate();
        //populate();
        //Starting Board positions

        grid [0, 0] = 16;
        grid [1, 0] = 14;
        grid [2, 0] = 15;
        grid [5, 0] = 15;
        grid [7, 0] = 16;
        grid [6, 0] = 14;
        grid [2, 0] = 15;
        grid [3, 0] = 17;
        grid [4, 0] = 12;

        grid [0, 7] = 6;
        grid [1, 7] = 4;
        grid [2, 7] = 5;
        grid [5, 7] = 5;
        grid [7, 7] = 6;
        grid [6, 7] = 4;
        grid [2, 7] = 5;
        grid [3, 7] = 7;
        grid [4, 7] = 2;

        for(int x = 0; x < 8; x++)
        {
            grid [x, 1] = 13;
            grid [x, 6] = 3;
        }  
        generate();
 
    }

    // Update is called once per frame
    void Update()
    {
        //populate();
    }
}
