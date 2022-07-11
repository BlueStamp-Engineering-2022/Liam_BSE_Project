using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//IF STUFF BREAKS CHECK DEBUG UPDATE
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

    public int BishopLimit = 0;

    public int RookLimit = 0;

    public int KnightLimit = 0;

    public int QueenLimit = 0;

    public int KingLimit = 0;

    public Material blackMaterial;

    public Material whiteMaterial;

    public bool ClickedOnce = false;

    public GameObject high;

    public int OldX;

    public int OldY;

    public int posx;

    public int posy;

    public GameObject Pawn_Move_Light;

    public bool Click = false;

    public bool Highlighted = false;

    public bool[,] MoveHighlightVectors;

    public bool[,] PieceMovement;

    public bool [,] PossibleMove;

    public bool R = false;

    public GameObject highlightPrefab;

    public Text DebugText;

    public bool ClickedForHighlightDelete = false;

    public GameObject highlightPrefab1;

    public int MoveHighlight = 0;

    public GameObject Move;

    public bool Moving = false;

    public bool stufffff = false;

    public GameObject[,] Pieces;

    //GameObject newPawn;

    GameObject movedPawn;

    GameObject movedstuff;




    void MovePieces(int x, int y)
    {

    }

    void detectInput() {

        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                if(grid[x, y] == 43)
                {
                    Moving = true;
                    var curx = x;
                    var cury = y;

                    if(Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Current X: " + curx + " " + "Current Y: " + cury);
                        Debug.Log(Pieces[curx, cury + 1]);
                        GameObject newPawn = Instantiate (PawnPrefab) as GameObject;
                        newPawn.transform.localPosition = new Vector3(curx - 3.5f, cury -3.5f, -2);
                        Pieces[curx, cury] = newPawn;
                        Debug.Log(curx + " " + cury);
                        Destroy(Pieces[curx, cury + 1]);
                        
                        Debug.Log("Grid is 43");
                        Moving = false;
                    }
                }
            }
        }

        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("Input Detected");
            if (Physics.Raycast(ray, out hit, 1000.000f)){
                Cell hitCell = hit.collider.GetComponent<Cell> ();

                Highlight (hitCell.x, hitCell.y);
            }
            
        }

    }

    
    string debugGameState() {
    
        string map = "";

        for (int x = 0; x < 8; x++){
            map += x + ": ";

            for (int y = 0; y < 8; y++) {
                map += "[" + grid [x, y] + "]";
            }
            map += "\n";
        }
        return map;
    }

    void updateDebugView(){
        DebugText.text = debugGameState ();
    }

    public void PawnMoves(int x, int y)
    {
        posx = x;
        posy = y;

        Move = Instantiate(highlightPrefab, new Vector3 (posx-3.5f, posy-4.5f, -1.9f), Quaternion.identity);
        grid [OldX, OldY - 1] = grid[OldX, OldY] + 20;
        //Debug.Log(grid[OldX, OldY]);
        if(grid[OldX, OldY - 1] > 42)
        {
            Debug.Log("Space");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("Input Detected");
        
        }
        
    }
    void GenerateMoves(int x, int y)
    {
        switch (grid [x, y])
        {
            case 23:
                Debug.Log("Pawn Selected");
                PawnMoves(x, y);
                break;
            case 0:
                //Debug.Log("gggggg");
                break;
        
            case 25:
                Debug.Log("Bishop Selected");
                break; 

            case 24:
                Debug.Log("Knight Selected");
                break;

            case 22:
                Debug.Log("King Selected");
                break;     

            case 27:
                Debug.Log("Queen Selected");
                break;
                
            case 26:
                Debug.Log("Rook Selected");
                break;

            case 33:
                Debug.Log("Pawn Selected");
                break;

            case 35:
                Debug.Log("Bishop Selected");
                break; 

            case 34:
                Debug.Log("Knight Selected");
                break;

            case 32:
                Debug.Log("King Selected");
                break;     

            case 37:
                Debug.Log("Queen Selected");
                break;
                
            case 36:
                Debug.Log("Rook Selected");
                break;
        }
        
            
        
    } 


    void Highlight(int x, int y){

        if(ClickedOnce == false)
        {
            high = Instantiate(highlightPrefab, new Vector3 (x-3.5f, y-3.5f, -1.9f), Quaternion.identity);
            //OldX = grid [x,y];
            //Debug.Log(OldX);
            //Debug.Log(OldY);
            OldX = x;
            OldY = y;
            grid [OldX, OldY] = grid[OldX, OldY] + 20;
            //if(grid [OldX, OldY] > 21)
            //{
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        GenerateMoves(i, j);
                    }
                }
            //}
            ClickedOnce = true;
            updateDebugView();
        }
        else if(ClickedOnce == true && Input.GetMouseButtonDown(0) && Moving == false) //Change back to 0 after testing
        {
           // Debug.Log("Highlight function delete call");
            Destroy(high);

            Destroy(Move);

            grid [OldX, OldY] = grid[OldX, OldY] - 20;

            grid [OldX, OldY - 1] = 0;

            ClickedOnce = false;
            //INSANITY = true;
            //Click = false;
            updateDebugView();
        }
            
        
    } 



    public void generate() {
        //Cells = new List<Cell> ();

        for(int x = 0; x  < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
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
        newCell.transform.localPosition = new Vector3 (posx - 3.5f, posy - 3.5f, 0);

        newCell.name = "Board cell [" + posx + "," + posy + "]";

        return newCell;
    }

    public void populate(int x, int y) 
    {
        updateDebugView();
        switch (grid [x, y])
        {

            case 3:
                if (PawnLimit < 16) 
                {
                    GameObject newPawn = Instantiate (PawnPrefab) as GameObject;
                    newPawn.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newPawn;
                    PawnLimit= PawnLimit + 1;                        
                } 
                break;

            case 0:
                //Debug.Log("gggggg");Debug.Log("Destroyed");
                break;
        
            case 5:
                if (BishopLimit < 5) 
                {
                    GameObject newBishop = Instantiate (bishopPrefab) as GameObject;
                    newBishop.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newBishop;
                    BishopLimit = BishopLimit + 1;
                }
                break; 

            case 4:
                if (KnightLimit < 4) {
                    GameObject newKnight = Instantiate (knightPrefab) as GameObject;
                    newKnight.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newKnight;
                    KnightLimit = KnightLimit + 1;
                } 
                break;

            case 2:
                if(KingLimit < 3)
                {
                    GameObject newKing = Instantiate (kingPrefab) as GameObject;
                    newKing.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newKing;
                    KingLimit = KingLimit + 1;
                }
                break;     

            case 7:
                if (QueenLimit < 4) {
                    GameObject newQueen = Instantiate (queenPrefab) as GameObject;
                    newQueen.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newQueen;
                    QueenLimit = QueenLimit + 1;
                }
                break;
                
            case 6:
                if (RookLimit < 4) {
                    GameObject newRook = Instantiate (rookPrefab) as GameObject;
                    newRook.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newRook;
                    RookLimit = RookLimit + 1;
                }
                break;

            case 13:
                if (PawnLimit < 16) {
                    //Debug.Log("Pawn");
                    //Debug.Log("Pawn runs every frame < -20");
                    GameObject newPawnB = Instantiate (PawnPrefabB) as GameObject;
                    newPawnB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    Pieces[x, y] = newPawnB;
                    PawnLimit= PawnLimit + 1;
                    Debug.Log("case 13 increase");
                }
                break;

            case 15:
                if (BishopLimit < 4) {
                    GameObject newBishopB = Instantiate (bishopPrefabB) as GameObject;
                    newBishopB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    BishopLimit = BishopLimit + 1;
                    Pieces[x, y] = newBishopB;
                }
                break; 

            case 14:
                if (KnightLimit < 4) {
                    GameObject newKnightB = Instantiate (knightPrefabB) as GameObject;
                    newKnightB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    KnightLimit = KnightLimit + 1;
                    Pieces[x, y] = newKnightB;
                }
                break;

            case 12:
                if(KingLimit < 3)
                {
                    GameObject newKingB = Instantiate (kingPrefabB) as GameObject;
                    newKingB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    KingLimit = KingLimit + 1;
                    Pieces[x, y] = newKingB;
                }
                break;     

            case 17:
                if (QueenLimit < 4) {
                    GameObject newQueenB = Instantiate (queenPrefabB) as GameObject;
                    newQueenB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    QueenLimit = QueenLimit + 1;
                    Pieces[x, y] = newQueenB;
                }
                break;
                
            case 16:
                if (RookLimit < 4) {
                    GameObject newRookB = Instantiate (rookPrefabB) as GameObject;
                    newRookB.transform.localPosition = new Vector3(x - 3.5f, y -3.5f, -2);
                    RookLimit = RookLimit + 1;
                    Pieces[x, y] = newRookB;
                }
                break;
        }     
    }

    void MoveStuff(int x, int y)
    {
        switch(grid[x, y])
        {
        
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PossibleMove = new bool [8,8];

        MoveHighlightVectors = new bool[8,8];

        grid = new int[8,8];

        Pieces = new GameObject[8, 8];

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
        Cells = new List<Cell> ();

        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                Cells.Add(createCell (x, y, (x + y) % 2));
            }
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        detectInput();
    }
}
