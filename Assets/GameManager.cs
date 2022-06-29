using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public Material yellowMaterial;

    public Board boardPrefab;

    public Text DebugText;

    private Board boardInstance;
    
    public Cell CellPrefab;

    private int[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new int[8,8];

        boardInstance = Instantiate (boardPrefab) as Board;
        boardInstance.transform.localPosition = new Vector3 (-3.5f, -3.5f, 0);

        boardInstance.generate ();
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseOver();
    }


        void updateDebugView(){
            DebugText.text = debugGameState ();
        }

    void OnMouseOver() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.00f)) {
            Cell hitCell = hit.collider.GetComponent<Cell> ();

           Cell myCell = activateCell (hitCell.x, hitCell.y);
           Destroy(myCell);
            OnMouseExit (hitCell.x, hitCell.y);

            updateDebugView ();

        }
        
    }

    void OnMouseExit(int x, int y){
            grid [x, y] = 0;
            //deleteCells (x, y);
            
        }

    //void deleteCells(x, y){

    //}

    Cell activateCell(int x, int y) {
        grid [x, y] = 1;
       // OnMouseExit(x, y);
        Cell newCell = createCell(x, y);
        Cell createCell(int posx, int posy) {
            Cell newCell = Instantiate (CellPrefab) as Cell;

            newCell.x = posx;
            newCell.y = posy;

            newCell.transform.parent = transform;
            newCell.transform.localPosition = new Vector3 (posx-3.5f, posy-3.5f, 0);

            newCell.name = "Board cell [" + posx + "," + posy + "]";

            
    
            
            if(grid [x, y] > 0){
                Debug.Log("It worked");
                newCell.GetComponent<Renderer> ().material = yellowMaterial;
            
            }
            return newCell;
        }
        return newCell;
        //startcolor = renderer.material.color;
        //renderer.material.color = Color.yellow;
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
}
