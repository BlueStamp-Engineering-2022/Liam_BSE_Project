using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public Material yellowMaterial;

    public Material redMaterial;

    public Board boardPrefab;

    public Text DebugText;

    private Board boardInstance;
    
    public Cell CellPrefab;

    public int OldX;

    public int OldY;

    private Cell selected;

    public List<Cell> Cells;

    public int Z = -1;

    public int[,] grid;

    bool Clicked = false;

    public const int King = 2;

    public const int Pawn = 3;

    public const int Knight = 4;

    public const int Bishop = 5;

    public const int Rook = 6;

    public const int Queen = 7;

    public GameObject PawnPrefab;

    public GameObject bishopPrefab;

    public GameObject rookPrefab;

    public GameObject kingPrefab;

    public GameObject knightPrefab;

    public GameObject queenPrefab;

    public int PawnLimit = 0;

    public int BishopLimit = 0;

    public int RookLimit = 0;

    public int KingLimit = 0;

    public int KnightLimit = 0;

    public int QueenLimit = 0;
    
    //bool On = false;

    // Start is called before the first frame update

    
    public void generate() {
        Cells = new List<Cell> ();

        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                Cells.Add(createCell (x, y));
            }
        }
    }

    Cell createCell(int posx, int posy) {
        Cell newCell = Instantiate (CellPrefab) as Cell;

        Clicked = true;

        //Debug.Log(posx);

        newCell.GetComponent<Renderer> ().material = yellowMaterial;

        newCell.x = posx;
        newCell.y = posy;

        OldX=posx;
        OldY=posy;
        
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3 (posx - 3.5f, posy - 3.5f, 0);

        newCell.name = "Board cell [" + posx + "," + posy + "]";

        selected = newCell;

        return newCell;
    }

    Cell deleteCell(int posx, int posy) {
       // Cell newCell = Instantiate (CellPrefab) as Cell;
        //Debug.Log(posx);

        Clicked = false;

        selected.transform.localPosition = new Vector3 (posx - 3.5f, posy - 3.5f, 1000);

        //newCell.GetComponent<Renderer> ().material = redMaterial;

        Z = Z + 1;
        /*
        newCell.x = posx;
        newCell.y = posy;

        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3 (posx - 3.5f, posy - 3.5f, -1);

        newCell.name = "Board cell [" + posx + "," + posy + "]";
        */
        return null;
    }
    void updateDebugView(){
        DebugText.text = debugGameState ();
    }
    public void Start(){


        //generate();
        grid = new int[8,8];

        boardInstance = Instantiate (boardPrefab) as Board;
        boardInstance.transform.localPosition = new Vector3 (-3.5f, -3.5f, 0);

        //boardInstance.generate();
        //populate();
        //Starting Board positions
        grid [0, 0] = 6;
        grid [1, 0] = 4;
        grid [2, 0] = 5;
        grid [5, 0] = 5;
        grid [7, 0] = 6;
        grid [6, 0] = 4;
        grid [2, 0] = 5;
        grid [3, 0] = 7;
        grid [4, 0] = 2;

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
            grid [x, 1] = 3;
            grid [x, 6] = 3;
        }
    }   

    // Update is called once per frame
    void Update()
    {
        detectInput();
    }


   

    void detectInput(){
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.000f)){
                Cell hitCell = hit.collider.GetComponent<Cell> ();

                activateCell (hitCell.x, hitCell.y);
                updateDebugView ();
            }
            
        }
    }
    void activateCell(int x, int y){
        grid [x, y] = 1;
        if(Clicked == true){
            deleteCell(OldX, OldY);
            
        } else {
            createCell(x, y);
        }  
    } 
/*    void activatCell(int x, int y) {
        grid [x, y] = 1;

       // OnMouseExit(x, y);
        createCell(x, y);
        Cell createCell(int posx, int posy) {
            Cell newCell = Instantiate (CellPrefab) as Cell;

            newCell.x = posx;
            newCell.y = posy;

            newCell.transform.parent = transform;
            newCell.transform.localPosition = new Vector3 (posx-3.5f, posy-3.5f, 0);

            newCell.name = "Board cell [" + posx + "," + posy + "]";

            
    
            
            if(grid [x, y] > 0){
                Debug.Log("Adding");
                newCell.GetComponent<Renderer> ().material = yellowMaterial;
                //grid [x, y] = 0;
            
            }
            return newCell;
        }
        //startcolor = renderer.material.color;
        //renderer.material.color = Color.yellow;
    }
*/
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
    //public void populate() 
    /*{
        Debug.Log("Populate Function Called");
        foreach (Cell cellInstance in Cells)
        {
            Debug.Log("test");
            Debug.Log(cellInstance.transform.position.x);
            Debug.Log(cellInstance.transform.position.y);
            cellInstance.occupied = true;
                if (grid [(int) cellInstance.transform.position.x, (int) cellInstance.transform.position.y] == 3)
                {
                        Debug.Log("Pawn");
                        GameObject newPawn = Instantiate (PawnPrefab) as GameObject;
                        newPawn.transform.localPosition = new Vector3( cellInstance.transform.position.x, cellInstance.transform.position.y, -2);
                        //if (PawnLimit)

                } else if (grid [(int) cellInstance.transform.position.x, (int) cellInstance.transform.position.y] == 5) {
                        GameObject newBishop = Instantiate (bishopPrefab) as GameObject;
                        newBishop.transform.localPosition = new Vector3(cellInstance.transform.position.x, cellInstance.transform.position.y, -2);
                } else if (grid [(int) cellInstance.transform.position.x, (int) cellInstance.transform.position.y] == 4) {
                        GameObject newKnight = Instantiate (knightPrefab) as GameObject;
                        newKnight.transform.localPosition = new Vector3(cellInstance.transform.position.x, cellInstance.transform.position.y, -2);
                } else if (grid [(int) cellInstance.transform.position.x, (int) cellInstance.transform.position.y] == 7) {
                        GameObject newKing = Instantiate (kingPrefab) as GameObject;
                        newKing.transform.localPosition = new Vector3(cellInstance.transform.position.x, cellInstance.transform.position.y, -2);
                } else if (grid [(int) cellInstance.transform.position.x, (int) cellInstance.transform.position.y] == 2) {
                        GameObject newQueen = Instantiate (queenPrefab) as GameObject;
                        newQueen.transform.localPosition = new Vector3(cellInstance.transform.position.x, cellInstance.transform.position.y, -2);
                } else if (grid  [(int) cellInstance.transform.position.x, (int) cellInstance.transform.position.y] == 6) {
                        GameObject newRook = Instantiate (rookPrefab) as GameObject;
                        newRook.transform.localPosition = new Vector3(cellInstance.transform.position.x, cellInstance.transform.position.y, -2);
                }
        }
            
        
    }*/
}
