//made by ninekorn aka steve chassé. The NONinfinite maze generator is from a youtube tutorial or somewhere else. i just made it kinda infinite but i will search the reference to where i got the original maze script from.



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class InfMazeGen : MonoBehaviour
{
    class Tile
    {
        public GameObject theTile;
        public float creationTime;
        public int[] _maze;
        public int _currentIndex;

        public Tile(GameObject t, float ct)
        {
            theTile = t;
            creationTime = ct;
            //_maze = maze;
            //_currentIndex = currentIndex;
        }
    }




    public int width = 7;
    public int widther = 6;
    public int height = 7;
    public int heighter = 6;
    private Vector2 CurrentTile;
    private Stack<Vector2> _tiletoTry = new Stack<Vector2>();
    int _detailScale = 2;
    int _heightScale = 2500;
    int randX = 3420;
    int randY = 3420;
    Vector3 startPos;
    public GameObject player;

    int[] currentMazeGrid;
    int[] MazeContainerIndex;
    int[][] MazeContainerOfMaze;
    Vector2?[] MazePositionArray;
    GameObject[] arrayOfGridMaze;



    int someResetCounter = 0;
    bool starterOncer = true;
    GameObject objecter;
    int[] Maze;
    int planeSize = 1;
    int maxX = 1;
    int maxY = 1;
    Vector2 posToSend;
    int[] completeMaze;
    int sizeX = 3;
    int sizeY = 3;
    Hashtable tiles = new Hashtable();

    List<int> arrayOfIndexOfBlockInMaze = new List<int>();

    List<int> arrayOfIndexOfBlockInLeftMaze = new List<int>();
    List<int> arrayOfIndexOfBlockInRightMaze = new List<int>();

    GameObject[] arrayOfParentObject = new GameObject[9];

    public Material greenMat;
    public Material redMat;
    public Material blueMat;
    public Material purpleMat;
    public Material yellowMat;
    public Material orangeMat;
    public Material blackMat;
    public Material grayMat;
    public Material turquoiseMat;


    public GameObject terrainAssetRL;



    public GameObject terrainMiddleLR;






    private List<Vector2> offsetsTwoMiddleTileOne = new List<Vector2>
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        //new Vector2(1, 0),
        //new Vector2(-1, 0)
    };


    private List<Vector2> offsetsTwoMiddleTileTwo = new List<Vector2>
    {
        //new Vector2(0, 1),
        //new Vector2(0, -1),
        new Vector2(1, 0),
        new Vector2(-1, 0)
    };



    private List<Vector2> offsetsTwoCornerOne = new List<Vector2>
    {
        new Vector2(0, 1),
        //new Vector2(0, -1),
        new Vector2(1, 0),
        //new Vector2(-1, 0)
    };

    private List<Vector2> offsetsTwoCornerTwo = new List<Vector2>
    {
        //new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 0),
        //new Vector2(-1, 0)
    };



    private List<Vector2> offsetsTwoCornerThree = new List<Vector2>
    {
        new Vector2(0, 1),
        //new Vector2(0, -1),
        //new Vector2(1, 0),
        new Vector2(-1, 0)
    };


    private List<Vector2> offsetsTwoCornerFour = new List<Vector2>
    {
        //new Vector2(0, 1),
        new Vector2(0, -1),
        //new Vector2(1, 0),
        new Vector2(-1, 0)
    };


   







    private List<Vector2> offsetsTwoCornerOneSINGLE = new List<Vector2>
    {
        new Vector2(0, 1),
        //new Vector2(0, -1),
        //new Vector2(1, 0),
        //new Vector2(-1, 0)
    };

    private List<Vector2> offsetsTwoCornerTwoSINGLE = new List<Vector2>
    {
        //new Vector2(0, 1),
        //new Vector2(0, -1),
        new Vector2(1, 0),
        //new Vector2(-1, 0)
    };



    private List<Vector2> offsetsTwoCornerThreeSINGLE = new List<Vector2>
    {
        //new Vector2(0, 1),
        //new Vector2(0, -1),
        //new Vector2(1, 0),
        new Vector2(-1, 0)
    };


    private List<Vector2> offsetsTwoCornerFourSINGLE = new List<Vector2>
    {
        //new Vector2(0, 1),
        new Vector2(0, -1),
        //new Vector2(1, 0),
        //new Vector2(-1, 0)
    };


























    private List<Vector2> offsets = new List<Vector2>
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 0),
        new Vector2(-1, 0)
    };

    /*private List<Vector2> offsetsTwo = new List<Vector2>
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        //new Vector2(1, 0),
        //new Vector2(-1, 0)
    };*/

    private List<Vector2> offsetsSeven = new List<Vector2>
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 0),
        new Vector2(-1, 0),

        new Vector2(1, 1),
        new Vector2(1, -1),
        new Vector2(-1, 1),
        new Vector2(-1, -1)
    };


    private List<Vector2> offsetsLeft = new List<Vector2>
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        //new Vector2(1, 0),
        new Vector2(-1, 0),

        //new Vector2(1, 1),
        //new Vector2(1, -1),
        new Vector2(-1, 1),
        new Vector2(-1, -1)
    };

    private List<Vector2> offsetsRight = new List<Vector2>
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 0),
        //new Vector2(-1, 0),

        new Vector2(1, 1),
        new Vector2(1, -1),
        //new Vector2(-1, 1),
        //new Vector2(-1, -1)
    };
















    static int[] arrayTop = new int[]
    {
        7,
        1,
        4
    };

    static int[] arrayMiddle = new int[]
    {
        6, // index 0
        0,
        3
    };

    static int[] arrayBottom = new int[]
    {
        8,
        2,
        5
    };

    int[][] totalArray = new int[][]
    {
        arrayTop,
        arrayMiddle, // index 1
        arrayBottom
    };

    /*int[] arrayTileLeft = new int[]
    {
            0,
            0,
            0
    };

    int[] arrayTileMiddle = new int[]
    {
            0,
            0,
            0
    };

    int[] arrayTileRight = new int[]
    {
            0,
            0,
            0
    };*/

    int[] arrayTileTotal = new int[]
    {
        0,0,0,
        0,0,0,
        0,0,0
    };

    /*int[] arrayTileTotal = new int[]
     {
            7,1,4,
            6,0,3,
            8,2,5
     };*/

    void shiftRight(int[] inputArray)
    {
        int[] temp = inputArray;
        var max = temp[2];
        var mid = temp[1];
        var min = temp[0];

        inputArray[0] = max;
        inputArray[1] = min;
        inputArray[2] = mid;
    }

    void shiftLeft(int[] inputArray)
    {
        int[] temp = inputArray;
        var max = temp[2];
        var mid = temp[1];
        var min = temp[0];

        temp[0] = mid;
        temp[1] = max;
        temp[2] = min;
    }



    void shiftRightWithIndex(int[] inputArray, int index)
    {
        int i = 0;
        for (; i < inputArray.Length; i++)
        {
            if (inputArray[i] == index)
            {
                break;
            }
        }

        int indexInArray = inputArray[i];

        if (indexInArray == 2)
        {

        }

        var max = inputArray[2];
        var mid = inputArray[1];
        var min = inputArray[0];




        /*int[] temp = inputArray;
        var max = temp[2];
        var mid = temp[1];
        var min = temp[0];

        inputArray[0] = max;
        inputArray[1] = min;
        inputArray[2] = mid;*/
    }





    void Start()
    {
        startPos = Vector3.zero;

        MazeContainerIndex = new int[sizeX * sizeY];
        MazeContainerOfMaze = new int[sizeX * sizeY][];
        currentMazeGrid = new int[sizeX * sizeY];
        MazePositionArray = new Vector2?[sizeX * sizeY];
        arrayOfGridMaze = new GameObject[sizeX * sizeY];

        for (int i = 0; i < currentMazeGrid.Length; i++)
        {
            currentMazeGrid[i] = 0;
        }
        for (int i = 0; i < MazePositionArray.Length; i++)
        {
            MazePositionArray[i] = null;
        }
    }

    int? lastPosPlayerX;
    int? lastPosPlayerY;
    void Update()
    {
        int playX = (Mathf.RoundToInt(player.transform.position.x));
        int playZ = (Mathf.RoundToInt(player.transform.position.z));
        Vector2 test = new Vector2(playX, playZ);
        checkTiles(test);
    }


    Stopwatch testWatch = new Stopwatch();

    //its not a perfect system. as I will need to put the tiles in a list or "lerp" the vector from where the player was to where he is so that no tiles are lost IF the player moves too fast...
    //right now it doesnt incorporate lists so some tiles arent beeing created as the position isn't "lerped".

    void checkTiles(Vector2 playerPos)
    {

        var posXX = Mathf.RoundToInt(playerPos.x / (width + widther - 1)) * (width + widther - 1);
        var posYY = Mathf.RoundToInt(playerPos.y / (height + heighter - 1)) * (height + heighter - 1);

        float xMove = (player.transform.position.x - startPos.x);
        float zMove = (player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) > 0 || Mathf.Abs(zMove) > 0)
        {
            testWatch.Stop();
            testWatch.Reset();
            testWatch.Start();

            float updateTime = Time.realtimeSinceStartup;

            int playX = (Mathf.RoundToInt(player.transform.position.x));
            int playZ = (Mathf.RoundToInt(player.transform.position.z));

            int playerX = Mathf.RoundToInt(player.transform.position.x / (width + widther - 1)) * (width + widther - 1);
            int playerZ = Mathf.RoundToInt(player.transform.position.z / (height + heighter - 1)) * (height + heighter - 1);

            //Vector3 pos = new Vector3(playerX, 0, playerZ);
            Vector2 test = new Vector2(playX, playZ);

            for (int x = -1; x <= maxX; x++)
            {
                for (int y = -1; y <= maxY; y++)
                {
                    var indexX = x;
                    if (indexX < 0)
                    {
                        indexX = (x * -1) + (maxX);
                    }

                    var indexY = y;
                    if (indexY < 0)
                    {
                        indexY = (y * -1) + (maxY);
                    }

                    var xx = x * (width + widther - 1);
                    var yy = y * (height + heighter - 1);

                    var testX = posXX + xx;
                    var testY = posYY + yy;


                    Vector3 positioner;
                    positioner.x = testX;
                    positioner.y = 0;
                    positioner.z = testY;

                    if (currentMazeGrid[indexX * (sizeY) + indexY] == 0)
                    {
                        posToSend = new Vector2(testX, testY);
                        completeMaze = MakeBlocks(posToSend, indexX * (sizeY) + indexY);

                        GameObject tuile = new GameObject();
                        tuile.transform.position = posToSend;
                        arrayOfGridMaze[indexX * (sizeY) + indexY] = tuile;

                        MazeContainerOfMaze[indexX * (sizeY) + indexY] = completeMaze;
                        //MazePositionArray[indexX * (sizeY) + indexY] = posToSend;
                        //MazeContainerIndex[indexX * (sizeY) + indexY] = indexX * (sizeY) + indexY;

                        currentMazeGrid[indexX * (sizeY) + indexY] = 1;
                    }
                }
            }









            //--------------------MANUALLY SWITCHING THE TILES FROM LEFT TO RIGHT OR VICE VERSA OR TOP TO BOTTOM OR VICE VERSA
            if (lastPosPlayerX != null && lastPosPlayerY != null)
            {
                if (posXX < lastPosPlayerX)
                {
                    for (int mainArrayIndex = 0; mainArrayIndex < totalArray.Length; mainArrayIndex++)
                    {
                        for (int gridArrayIndex = totalArray[mainArrayIndex].Length - 1; gridArrayIndex >= 0; gridArrayIndex--)
                        {
                            if (gridArrayIndex == 0)
                            {
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];
                                arrayOfGridMaze[indexCurrent] = null;
                                MazeContainerOfMaze[indexCurrent] = null;
                                currentMazeGrid[indexCurrent] = 0;
                            }
                            else
                            {
                                var indexToTheLeft = totalArray[mainArrayIndex][gridArrayIndex - 1];
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];

                                if (gridArrayIndex == totalArray[mainArrayIndex].Length - 1)
                                {
                                    if (arrayOfGridMaze[indexCurrent] != null)
                                    {
                                        Destroy(arrayOfGridMaze[indexCurrent].transform.gameObject);
                                    }
                                }

                                var oldarrayOfGridMaze = arrayOfGridMaze[indexToTheLeft];
                                var oldMazeContainerOfMaze = MazeContainerOfMaze[indexToTheLeft];

                                arrayOfGridMaze[indexToTheLeft] = arrayOfGridMaze[indexCurrent];
                                arrayOfGridMaze[indexCurrent] = oldarrayOfGridMaze;

                                MazeContainerOfMaze[indexToTheLeft] = MazeContainerOfMaze[indexCurrent];
                                MazeContainerOfMaze[indexCurrent] = oldMazeContainerOfMaze;
                            }

                            //4 is destroyed. 1 goes to 4. 7 goes to 1. new chunk on 7
                            //7,1,4,
                            //6,0,3,
                            //8,2,5
                        }
                    }
                }
                else if (posXX > lastPosPlayerX)
                {
                    for (int mainArrayIndex = 0; mainArrayIndex < totalArray.Length; mainArrayIndex++)
                    {
                        for (int gridArrayIndex = 0; gridArrayIndex <= totalArray[mainArrayIndex].Length - 1; gridArrayIndex++)
                        {
                            if (gridArrayIndex == totalArray[mainArrayIndex].Length - 1)
                            {
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];
                                arrayOfGridMaze[indexCurrent] = null;
                                MazeContainerOfMaze[indexCurrent] = null;
                                currentMazeGrid[indexCurrent] = 0;
                            }
                            else
                            {
                                var indexToTheRight = totalArray[mainArrayIndex][gridArrayIndex + 1];
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];

                                if (gridArrayIndex == 0)
                                {
                                    if (arrayOfGridMaze[indexCurrent] != null)
                                    {
                                        Destroy(arrayOfGridMaze[indexCurrent].transform.gameObject);
                                    }
                                }

                                var oldarrayOfGridMaze = arrayOfGridMaze[indexToTheRight];
                                var oldMazeContainerOfMaze = MazeContainerOfMaze[indexToTheRight];

                                arrayOfGridMaze[indexToTheRight] = arrayOfGridMaze[indexCurrent];
                                arrayOfGridMaze[indexCurrent] = oldarrayOfGridMaze;

                                MazeContainerOfMaze[indexToTheRight] = MazeContainerOfMaze[indexCurrent];
                                MazeContainerOfMaze[indexCurrent] = oldMazeContainerOfMaze;
                            }
                        }
                    }
                }

                if (posYY < lastPosPlayerY)
                {
                    for (int mainArrayIndex = 0; mainArrayIndex <= totalArray.Length - 1; mainArrayIndex++)
                    {
                        for (int gridArrayIndex = 0; gridArrayIndex < totalArray[mainArrayIndex].Length; gridArrayIndex++)
                        {
                            if (mainArrayIndex == totalArray.Length - 1)
                            {
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];
                                arrayOfGridMaze[indexCurrent] = null;
                                MazeContainerOfMaze[indexCurrent] = null;
                                currentMazeGrid[indexCurrent] = 0;
                            }
                            else
                            {
                                var indexToTheTop = totalArray[mainArrayIndex + 1][gridArrayIndex];
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];

                                if (mainArrayIndex == 0)
                                {
                                    if (arrayOfGridMaze[indexCurrent] != null)
                                    {
                                        Destroy(arrayOfGridMaze[indexCurrent].transform.gameObject);
                                    }
                                }

                                var oldarrayOfGridMaze = arrayOfGridMaze[indexToTheTop];
                                var oldMazeContainerOfMaze = MazeContainerOfMaze[indexToTheTop];

                                arrayOfGridMaze[indexCurrent] = arrayOfGridMaze[indexToTheTop];
                                arrayOfGridMaze[indexToTheTop] = oldarrayOfGridMaze;

                                MazeContainerOfMaze[indexCurrent] = MazeContainerOfMaze[indexToTheTop];
                                MazeContainerOfMaze[indexToTheTop] = oldMazeContainerOfMaze;
                            }
                        }
                    }
                }
                else if (posYY > lastPosPlayerY)
                {
                    for (int mainArrayIndex = totalArray.Length - 1; mainArrayIndex >= 0; mainArrayIndex--)
                    {
                        for (int gridArrayIndex = 0; gridArrayIndex < totalArray[mainArrayIndex].Length; gridArrayIndex++)
                        {
                            if (mainArrayIndex == 0)
                            {
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];
                                arrayOfGridMaze[indexCurrent] = null;
                                MazeContainerOfMaze[indexCurrent] = null;
                                currentMazeGrid[indexCurrent] = 0;
                            }
                            else
                            {
                                var indexToTheTop = totalArray[mainArrayIndex - 1][gridArrayIndex];
                                var indexCurrent = totalArray[mainArrayIndex][gridArrayIndex];

                                if (mainArrayIndex == totalArray.Length - 1)
                                {
                                    if (arrayOfGridMaze[indexCurrent] != null)
                                    {
                                        Destroy(arrayOfGridMaze[indexCurrent].transform.gameObject);
                                    }
                                }

                                var oldarrayOfGridMaze = arrayOfGridMaze[indexToTheTop];
                                var oldMazeContainerOfMaze = MazeContainerOfMaze[indexToTheTop];

                                arrayOfGridMaze[indexCurrent] = arrayOfGridMaze[indexToTheTop];
                                arrayOfGridMaze[indexToTheTop] = oldarrayOfGridMaze;

                                MazeContainerOfMaze[indexCurrent] = MazeContainerOfMaze[indexToTheTop];
                                MazeContainerOfMaze[indexToTheTop] = oldMazeContainerOfMaze;
                            }
                        }
                    }
                }
            }
            //--------------------MANUALLY SWITCHING THE TILES FROM LEFT TO RIGHT OR VICE VERSA OR TOP TO BOTTOM OR VICE VERSA


























            for (int x = -1; x <= maxX; x++)
            {
                for (int y = -1; y <= maxY; y++)
                {
                    var indexX = x;
                    if (indexX < 0)
                    {
                        indexX = (x * -1) + (maxX);
                    }

                    var indexY = y;
                    if (indexY < 0)
                    {
                        indexY = (y * -1) + (maxY);
                    }

                    var xx = x * (width + widther - 1);
                    var yy = y * (height + heighter - 1);

                    var testX = posXX + xx;
                    var testY = posYY + yy;


                    if (arrayOfGridMaze[indexX * (sizeY) + indexY] == null || currentMazeGrid[indexX * (sizeY) + indexY] == 0 || MazeContainerOfMaze[indexX * (sizeY) + indexY] == null)
                    {
                        continue;
                    }

                    if (currentMazeGrid[indexX * (sizeY) + indexY] == 1)
                    {
                        if (indexX * (sizeY) + indexY == 0 || // for Debug
                            indexX * (sizeY) + indexY == 1 ||
                            indexX * (sizeY) + indexY == 2 ||
                            indexX * (sizeY) + indexY == 3 ||
                            indexX * (sizeY) + indexY == 6 ||
                            indexX * (sizeY) + indexY == 4 ||
                            indexX * (sizeY) + indexY == 5 ||
                            indexX * (sizeY) + indexY == 8 ||
                            indexX * (sizeY) + indexY == 7
                            )
                        {
                            fixNeighboorMaze(posXX, posYY, testX, testY, indexX, indexY, x, y);
                        }
                        for (int xxx = 0; xxx < width + widther; xxx++)
                        {
                            for (int yyy = 0; yyy < height + heighter; yyy++)
                            {
                                var currentPos = new Vector3(testX + xxx - widther - 1, 0, testY + yyy - heighter - 1);

                                /*var toCheck = new Vector2(xxx, yyy);

                                if (MazeContainerOfMaze[indexX * (sizeY) + indexY][xxx * (height + heighter) + yyy] == 1 &&
                                    HasSevenWallsIntact(toCheck, MazeContainerOfMaze[indexX * (sizeY) + indexY]))
                                {
                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                    objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + yyy - heighter - 1);
                                    objecter.transform.parent = arrayOfGridMaze[indexX * (sizeY) + indexY].transform;
                                    objecter.GetComponent<MeshRenderer>().material = redMat;
                                }*/

                                var currentMainIndex = indexX * (sizeY) + indexY;
                                var currentGridIndex = xxx * (height + heighter) + yyy;

                                int indexMain = -1;
                                int indexSecondary = -1;

                                for (int i = 0; i < totalArray.Length; i++)
                                {
                                    for (int j = 0; j < totalArray[i].Length; j++)
                                    {
                                        if (currentMainIndex == totalArray[i][j])
                                        {
                                            indexMain = i;
                                            indexSecondary = j;
                                        }
                                    }
                                }

                                var currentIndexor = totalArray[indexMain][indexSecondary];
                                int emptyTile;
                                int intactTile;
                                int outOfBounds;

                                if (yyy > 1 && yyy < (height + heighter - 2) && xxx > 1 && xxx < (width + widther - 2))
                                {
                                    var testerX = (width + widther - 1);
                                    var testerY = yyy;
                                    var toCheck = new Vector2(xxx, testerY);
                                    var toCheck2 = new Vector2(testerX, testerY);

                                    if (MazeContainerOfMaze[currentIndexor][xxx * (height + heighter) + testerY] == 1)
                                    {
                                        List<Vector2> currentEmptyBlocks;
                                        int totalOne = HasFourWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], out currentEmptyBlocks, new Vector2(testX, testY), out intactTile, out emptyTile, out outOfBounds);

                                        if (intactTile == 0)
                                        {
                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                            objecter.GetComponent<MeshRenderer>().material = blueMat;
                                        }
                                        else if (intactTile == 1)
                                        {
                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                            objecter.GetComponent<MeshRenderer>().material = greenMat;
                                        }
                                        else if (intactTile == 2)
                                        {
                                            int cornerTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerOne);
                                            int cornerTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerTwo);
                                            int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                            int middleTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileTwo);
                                            int cornerTileThree = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerThree);
                                            int cornerTileFour = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerFour);

                                            if (middleTileOne == 2)
                                            {
                                                //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = turquoiseMat;
                                            }

                                            if (middleTileTwo == 2)
                                            {
                                                //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = turquoiseMat;
                                            }

                                            if (cornerTileOne == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                            }

                                            if (cornerTileTwo == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                            }

                                            if (cornerTileThree == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                            }

                                            if (cornerTileFour == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                            }
                                        }
                                        else if (intactTile == 3)
                                        {
                                            int totaloneone = HasThreeWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor]);

                                            if (totaloneone == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = blackMat;
                                            }
                                            else if (totaloneone == 3)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = orangeMat;
                                            }
                                        }
                                        else if (intactTile == 4)
                                        {
                                            int totaloneone = HasThreeWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor]);

                                            if (totaloneone == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = blackMat;
                                            }
                                            else if (totaloneone == 4)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = yellowMat;
                                            }
                                        }
                                        else if (intactTile == 5)
                                        {
                                            int totaloneone = HasThreeWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor]);

                                            if (totaloneone == 2)
                                            {
                                                objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = blackMat;
                                            }
                                        }
                                    }
                                }
                                if (yyy == 0 && xxx > 1 && xxx < (width + widther - 2))
                                {
                                    if (indexMain < totalArray.Length - 1)
                                    {
                                        var testerX = xxx;
                                        var testerY = (height + heighter - 1);
                                        var toCheck = new Vector2(testerX, yyy);
                                        var toCheck2 = new Vector2(testerX, testerY);

                                        if (MazeContainerOfMaze[currentIndexor][testerX * (height + heighter) + yyy] == 1)
                                        {
                                            List<Vector2> currentEmptyBlocks;
                                            int totalOne = HasFourWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], out currentEmptyBlocks, new Vector2(testX, testY), out intactTile, out emptyTile, out outOfBounds);
                                            var indexInArrayBottom = totalArray[indexMain + 1][indexSecondary];

                                            if (outOfBounds > 0)
                                            {
                                                int totalTwo = 0;
                                                for (int i = 0; i < currentEmptyBlocks.Count; i++)
                                                {
                                                    var someOffsetX = testerX + currentEmptyBlocks[i].x;
                                                    var someOffsetY = testerY + currentEmptyBlocks[i].y;

                                                    if (MazeContainerOfMaze[indexInArrayBottom][(int)someOffsetX * (height + heighter) + (int)someOffsetY] == 1)
                                                    {
                                                        totalTwo++;
                                                    }
                                                }

                                                if (intactTile == 0)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blueMat;
                                                    }
                                                }
                                                else if (intactTile == 1)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = greenMat;
                                                    }
                                                    else if (totalTwo == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                    }
                                                }
                                                else if (intactTile == 2)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        int cornerTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerOne);
                                                        int cornerTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerTwo);
                                                        int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                                        int middleTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileTwo);
                                                        int cornerTileThree = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerThree);
                                                        int cornerTileFour = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerFour);

                                                        if (middleTileOne == 2)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = turquoiseMat;
                                                        }

                                                        if (middleTileTwo == 2)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = turquoiseMat;
                                                        }

                                                        if (cornerTileOne == 2)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }

                                                        if (cornerTileTwo == 2)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }

                                                        if (cornerTileThree == 2)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }

                                                        if (cornerTileFour == 2)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }
                                                    }
                                                    else if(totalTwo == 1)
                                                    {
                                                        int middleTileOne = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayBottom], offsetsTwoMiddleTileOne);
                                                        int middleTileTwo = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayBottom], offsetsTwoMiddleTileTwo);

                                                        if (middleTileOne ==1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = orangeMat;
                                                        }

                                                        if (middleTileTwo == 0)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }
                                                    }
                                                }
                                                else if (intactTile == 3)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        int someTest = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsets);

                                                        if (someTest == 3)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = orangeMat;
                                                        }
                                                        else
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        int someTest = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsets);
                                                        if (someTest != 3)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                            }
                                        }
                                        else
                                        {
                                            /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                            objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                        }
                                    }
                                    else
                                    {

                                    }
                                    
                                }
                                else if (yyy == 1 && xxx > 1 && xxx < (width + widther - 2))
                                {
                                    if (indexMain < totalArray.Length - 1)
                                    {
                                        var testerX = xxx;
                                        var testerY = (height + heighter - 1);
                                        var toCheck = new Vector2(testerX, yyy);
                                        var toCheck2 = new Vector2(testerX, testerY);

                                        if (MazeContainerOfMaze[currentIndexor][testerX * (height + heighter) + yyy] == 1)
                                        {
                                            List<Vector2> currentEmptyBlocks;
                                            int totalOne = HasFourWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], out currentEmptyBlocks, new Vector2(testX, testY), out intactTile, out emptyTile, out outOfBounds);
                                            var indexInArrayBottom = totalArray[indexMain + 1][indexSecondary];

                                            if (outOfBounds > 0)
                                            {
                                                int totalTwo = 0;
                                                for (int i = 0; i < currentEmptyBlocks.Count; i++)
                                                {
                                                    var someOffsetX = testerX + currentEmptyBlocks[i].x;
                                                    var someOffsetY = testerY + currentEmptyBlocks[i].y;

                                                    if (MazeContainerOfMaze[indexInArrayBottom][(int)someOffsetX * (height + heighter) + (int)someOffsetY] == 1)
                                                    {
                                                        totalTwo++;
                                                    }
                                                }
                                                if (intactTile == 0)
                                                {

                                                }
                                                else if (intactTile == 1)
                                                {


                                                    int someTest = HasThreeWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayBottom]);

                                                    if (someTest == 2)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }
                                                    else if (someTest == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }
                                                    else if (someTest == 3)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }
                                                }
                                                else if (intactTile == 2)
                                                {

                                                }
                                                else if (intactTile == 3)
                                                {

                                                }
                                                else if (intactTile == 4)
                                                {

                                                }
                                            }
                                            else
                                            {
                                                if (intactTile == 0)
                                                {
                                                    
                                                }
                                                else if (intactTile == 1)
                                                {

                                                    if (MazeContainerOfMaze[indexInArrayBottom][(int)testerX * (height + heighter) + (int)testerY] == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }
                                                }
                                                else if (intactTile == 2)
                                                {
                                                    int someTest = HasThreeWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayBottom]);

                                                    if (someTest == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }
                                                    else if (someTest == 2)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }

                                                }
                                                else if (intactTile == 3)
                                                {
                                                    int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                                    int middleTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileTwo);
                                                    if (middleTileOne == 2)
                                                    {
                                                        //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }

                                                    if (middleTileTwo == 2)
                                                    {
                                                        //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                }
                                                else if (intactTile == 4)
                                                {
                                                    int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                                    int middleTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileTwo);
                                                    if (middleTileOne == 2)
                                                    {
                                                        //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }

                                                    if (middleTileTwo == 2)
                                                    {
                                                        //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                            objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else if (yyy == (height + heighter - 2) && xxx > 1 && xxx < (width + widther - 2))
                                {
                                    if (indexMain > 0)
                                    {
                                        var testerX = xxx;
                                        var testerY = 0;
                                        var toCheck = new Vector2(testerX, yyy);
                                        var toCheck2 = new Vector2(testerX, testerY);


                                        if (MazeContainerOfMaze[currentIndexor][testerX * (height + heighter) + yyy] == 1)
                                        {
                                            List<Vector2> currentEmptyBlocks;
                                            int totalOne = HasFourWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], out currentEmptyBlocks, new Vector2(testX, testY), out intactTile, out emptyTile, out outOfBounds);
                                            var indexInArrayBottom = totalArray[indexMain - 1][indexSecondary];

                                            if (outOfBounds > 0)
                                            {
                                                int totalTwo = 0;
                                                for (int i = 0; i < currentEmptyBlocks.Count; i++)
                                                {
                                                    var someOffsetX = testerX + currentEmptyBlocks[i].x;
                                                    var someOffsetY = testerY + currentEmptyBlocks[i].y;

                                                    if (MazeContainerOfMaze[indexInArrayBottom][(int)someOffsetX * (height + heighter) + (int)someOffsetY] == 1)
                                                    {
                                                        totalTwo++;
                                                    }
                                                }
                                                if (intactTile == 0)
                                                {
            
                                                }
                                                else if (intactTile == 1)
                                                {
                                                    /*if (totalTwo == 0)
                                                    {

                                                    }
                                                    else if (totalTwo==1)
                                                    {

                                                    }
                                                    else if (totalTwo == 2)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                    else if (totalTwo == 3)
                                                    {

                                                    }*/
                                                }
                                                else if (intactTile == 2)
                                                {
                       
                                                }
                                                else if (intactTile == 3)
                                                {
                                     
                                                }
                                                else if (intactTile == 4)
                                                {
                                 
                                                }
                                            }
                                            else
                                            {
                                                if (intactTile == 0)
                                                {
                                                
                                                }
                                                else if (intactTile == 1)
                                                {
                                                    int someTest = HasThreeWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayBottom]);

                                                    if (someTest == 2)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                    else if (someTest == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                }
                                                else if (intactTile == 2)
                                                {
                                                    int someTest = HasThreeWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayBottom]);

                                                    if (someTest == 2)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                    else if (someTest == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                }
                                                else if (intactTile == 3)
                                                {
                                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                    objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                    objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                }
                                                else if (intactTile == 4)
                                                {
                                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                    objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                    objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                            objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                        }
                                    }
                                    else
                                    {
                                        /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                        objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                    }
                                }
                                else if (yyy == (height + heighter - 1) && xxx > 1 && xxx < (width + widther - 2))
                                {
                                    if (indexMain > 0)
                                    {
                                        var testerX = xxx;
                                        var testerY = 0;
                                        var toCheck = new Vector2(testerX, yyy);
                                        var toCheck2 = new Vector2(testerX, testerY);


                                        if (MazeContainerOfMaze[currentIndexor][testerX * (height + heighter) + yyy] == 1)
                                        {
                                            List<Vector2> currentEmptyBlocks;
                                            int totalOne = HasFourWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], out currentEmptyBlocks, new Vector2(testX, testY), out intactTile, out emptyTile, out outOfBounds);
                                            var indexInArrayTop = totalArray[indexMain - 1][indexSecondary];

                                            if (outOfBounds > 0)
                                            {
                                                int totalTwo = 0;
                                                for (int i = 0; i < currentEmptyBlocks.Count; i++)
                                                {
                                                    var someOffsetX = testerX + currentEmptyBlocks[i].x;
                                                    var someOffsetY = testerY + currentEmptyBlocks[i].y;

                                                    if (MazeContainerOfMaze[indexInArrayTop][(int)someOffsetX * (height + heighter) + (int)someOffsetY] == 1)
                                                    {
                                                        totalTwo++;
                                                    }
                                                }

                                                if (intactTile == 0)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blueMat;
                                                    }
                                                    else if (totalTwo == 1)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = redMat;
                                                    }
                                                }
                                                else if (intactTile == 1)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = greenMat;
                                                    }
                                                    else
                                                    {

                                                      

                                                        /*int someTest = HasThreeWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop]);

                                                        if (someTest == 1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = redMat;
                                                        }*/



                                                        int middleTileOne = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop], offsetsTwoMiddleTileOne);
                                                        //int middleTileTwo = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop], offsetsTwoMiddleTileTwo);

                                                        if (middleTileOne == 1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = redMat; // was purple
                                                        }

                                                        /*if (middleTileTwo == 1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }*/
                                                    }
                                                }
                                                else if (intactTile == 2)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        int cornerTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerTwo);
                                                        int cornerTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoCornerFour);

                                                        if (cornerTileOne == 2)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }

                                                        if (cornerTileTwo == 2)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = purpleMat;
                                                        }


                                                        int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                                        int middleTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileTwo);
                                                        if (middleTileOne == 2)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = turquoiseMat;
                                                        }

                                                        if (middleTileTwo == 2)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = turquoiseMat;
                                                        }
                                                    }
                                                    else if(totalTwo == 3)
                                                    {
                                                        int middleTileOne = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop], offsetsTwoMiddleTileOne);
                                                        int middleTileTwo = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop], offsetsTwoMiddleTileTwo);






                                                        /*int middleTileOne = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop], offsetsTwoMiddleTileOne);
                                                        int middleTileTwo = isCornerWallsIntactInt(toCheck2, MazeContainerOfMaze[indexInArrayTop], offsetsTwoMiddleTileTwo);

                                                        if (middleTileOne == 1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = orangeMat;
                                                        }
                                                        else if (middleTileTwo == 0)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }
                                                        else
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }*/
                                                    }
                                                }
                                                else if (intactTile == 3)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                                        if (middleTileOne == 1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = orangeMat;
                                                        }
                                                        else
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }
                                                        
                                                    }
                                                    else// if(totalTwo == 1) // to fix
                                                    {
                                                        objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                        objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                    }
                                                }
                                                else if (intactTile == 4)
                                                {
                                                    if (totalTwo == 0)
                                                    {
                                                        int middleTileOne = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileOne);
                                                        int middleTileTwo = isCornerWallsIntactInt(toCheck, MazeContainerOfMaze[currentIndexor], offsetsTwoMiddleTileTwo);

                                                        if (middleTileTwo == 2)
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }


                                                        /*if (middleTileOne == 1)
                                                        {
                                                            //objecter = Instantiate(terrainMiddleLR, new Vector3(testX + xxx - widther - 1, 0, testY + testerY - heighter - 1), Quaternion.identity);
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = orangeMat;
                                                        }
                                                        else
                                                        {
                                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                            objecter.GetComponent<MeshRenderer>().material = blackMat;
                                                        }*/
                                                    }
                                                }
                                            }
                                            else
                                            {                                         
                                                if (intactTile == 0)
                                                {

                                                }
                                                else if (intactTile == 1)
                                                {
                                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                                    objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                                    objecter.GetComponent<MeshRenderer>().material = redMat;
                                                }
                                                else if (intactTile == 2)
                                                {

                                                }
                                                else if (intactTile == 3)
                                                {

                                                }
                                                else if (intactTile == 4)
                                                {

                                                }
                                            }
                                        }
                                        else
                                        {
                                            /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                            objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                        }
                                    }
                                    else
                                    {
                                        /*objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        objecter.transform.position = new Vector3(testX + testerX - widther - 1, 1, testY + yyy - heighter - 1);
                                        objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                        objecter.GetComponent<MeshRenderer>().material = redMat;*/
                                    }
                                }





















                                /*else if (yyy > 1 && yyy < (height + heighter - 1) && xxx == 0)
                                {
                                    var testerX = (width + widther - 1);
                                    var testerY = yyy;
                                    var toCheck = new Vector2(xxx, testerY);
                                    var toCheck2 = new Vector2(testerX, testerY);

                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                    objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                    objecter.GetComponent<MeshRenderer>().material = pinkMat;
                                }
                                else if (yyy > 1 && yyy < (height + heighter - 1) && xxx == 1)
                                {
                                    //var testerX = (width + widther - 1);
                                    var testerY = yyy;
                                    var toCheck = new Vector2(xxx, testerY);
                                    //var toCheck2 = new Vector2(testerX, testerY);

                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                    objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                    objecter.GetComponent<MeshRenderer>().material = pinkMat;
                                }
                                else if (yyy > 1 && yyy < (height + heighter - 1) && xxx == (width + widther - 2))
                                {
                                    //var testerX = (width + widther - 1);
                                    var testerY = yyy;
                                    var toCheck = new Vector2(xxx, testerY);
                                    //var toCheck2 = new Vector2(testerX, testerY);

                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                    objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                    objecter.GetComponent<MeshRenderer>().material = pinkMat;
                                }
                                else if (yyy > 1 && yyy < (height + heighter - 1) && xxx == (width + widther - 1))
                                {
                                    //var testerX = (width + widther - 1);
                                    var testerY = yyy;
                                    var toCheck = new Vector2(xxx, testerY);
                                    //var toCheck2 = new Vector2(testerX, testerY);

                                    objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                    objecter.transform.position = new Vector3(testX + xxx - widther - 1, 1, testY + testerY - heighter - 1);
                                    objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                                    objecter.GetComponent<MeshRenderer>().material = pinkMat;
                                }*/





























                                if (MazeContainerOfMaze[indexX * (sizeY) + indexY][xxx * (height + heighter) + yyy] == 1)
                                    {
                                        if (indexX * (sizeY) + indexY == 0 || // for Debug
                                            indexX * (sizeY) + indexY == 1 ||
                                            indexX * (sizeY) + indexY == 2 ||
                                            indexX * (sizeY) + indexY == 3 ||
                                            indexX * (sizeY) + indexY == 6 ||
                                            indexX * (sizeY) + indexY == 4 ||
                                            indexX * (sizeY) + indexY == 5 ||
                                            indexX * (sizeY) + indexY == 8 ||
                                            indexX * (sizeY) + indexY == 7
                                           )
                                        {
                                            //objecter = new GameObject();
                                            //var meshFilt = objecter.AddComponent<MeshFilter>();
                                            //objecter.AddComponent<MeshRenderer>();
                                            //meshFilt.mesh = terrainAssetRL.GetComponent<MeshFilter>().mesh;

                                            objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                            objecter.transform.position = new Vector3(testX + xxx - widther - 1, 0, testY + yyy - heighter - 1);
                                            objecter.transform.parent = arrayOfGridMaze[indexX * (sizeY) + indexY].transform;
                                            //MazeContainerOfMaze[indexX * (sizeY) + indexY][xxx * (height + heighter) + yyy] = 3;
                                        }
                                    }
                                }

                            }
                            currentMazeGrid[indexX * (sizeY) + indexY] = 3;
                    }
                }
            }





            //testWatch.Stop();
            //UnityEngine.Debug.Log(testWatch.Elapsed.Milliseconds);

            startPos = player.transform.position;
            lastPosPlayerX = posXX;
            lastPosPlayerY = posYY;
        }
    }





































    void fixNeighboorMaze(int posXX, int posYY, int testX, int testY, int Xindex, int Yindex, int itX, int itY)
    {
        int checkLeft = 1;
        int checkRight = 1;
        int checkTop = 1;
        int checkBottom = 1;

        int checkBottomRight = 1;
        int checkBottomLeft = 1;

        int checkTopRight = 1;
        int checkTopLeft = 1;



        for (int x = -1; x <= maxX; x++)
        {
            for (int y = -1; y <= maxY; y++)
            {
                var breakerX = x + itX;
                var breakerY = y + itY;

                //UnityEngine.Debug.Log(breakerX + " _ " + breakerY);

                /*if (breakerX < -1 || breakerX > 1 ||
                    breakerY < -1 || breakerY > 1)
                {
                    //UnityEngine.Debug.Log("test");
                    continue;
                }*/

                /*if (x == 0 && y == 0 ||
                    x == -1 && y == -1 ||
                    x == -1 && y == 1 ||
                    x == 1 && y == -1 ||
                    x == 1 && y == 1)
                {
                    continue;
                }*/

                var indexX = x;
                if (indexX < 0)
                {
                    indexX = (x * -1) + (maxX);
                }

                var indexY = y;
                if (indexY < 0)
                {
                    indexY = (y * -1) + (maxY);
                }

                var xx = x * (width + widther - 1);
                var yy = y * (height + heighter - 1);

                var testXX = posXX + xx;
                var testYY = posYY + yy;

                if (testX == testXX && testY == testYY)
                {
                    continue;
                }

                if (checkRight == 1)
                {
                    var currentMainTileIndex = Xindex * (sizeY) + Yindex;

                    for (int mainArrayIndex = 0; mainArrayIndex < totalArray.Length; mainArrayIndex++)
                    {
                        for (int gridArrayIndex = 0; gridArrayIndex < totalArray[mainArrayIndex].Length; gridArrayIndex++)
                        {
                            if (currentMainTileIndex == totalArray[mainArrayIndex][gridArrayIndex])
                            {
                                if (gridArrayIndex == totalArray[mainArrayIndex].Length - 1)
                                {
                                    var indexInArrayRight = totalArray[mainArrayIndex][gridArrayIndex];
                                    var indexInArrayLeft = totalArray[mainArrayIndex][gridArrayIndex - 1];

                                    var xxx = 0;
                                    for (int yyy = 0; yyy < height + heighter; yyy++)
                                    {
                                        var testerX = (width + widther - 1);
                                        var testerY = yyy;

                                        if (MazeContainerOfMaze[indexInArrayLeft][testerX * (height + heighter) + testerY] == 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayRight][xxx * (height + heighter) + testerY] = 2;
                                        }

                                        else if (MazeContainerOfMaze[indexInArrayLeft][testerX * (height + heighter) + testerY] == 1)
                                        {

                                            MazeContainerOfMaze[indexInArrayRight][xxx * (height + heighter) + testerY] = 0;
                                        }

                                        if (MazeContainerOfMaze[indexInArrayRight][testerX * (height + heighter) + testerY] != 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayRight][testerX * (height + heighter) + testerY] = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    var indexInArrayRight = totalArray[mainArrayIndex][gridArrayIndex + 1];

                                    var xxx = 0;
                                    //for (int xxx = 0; xxx < width + widther; xxx++)
                                    {
                                        for (int yyy = 0; yyy < height + heighter; yyy++)
                                        {
                                            //if (xxx == 0)
                                            {
                                                var testerX = (width + widther - 1);
                                                var testerY = yyy;

                                                if (MazeContainerOfMaze[indexInArrayRight][xxx * (height + heighter) + testerY] == 2)
                                                {
                                                    MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 2;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    checkRight = 0;
                }


                if (checkLeft == 1)
                {
                    var currentMainTileIndex = Xindex * (sizeY) + Yindex;

                    int mainArrayIndex = 0;
                    int gridArrayIndex = 0;

                    for (mainArrayIndex = 0; mainArrayIndex < totalArray.Length; mainArrayIndex++)
                    {
                        for (gridArrayIndex = 0; gridArrayIndex < totalArray[mainArrayIndex].Length; gridArrayIndex++)
                        {
                            if (currentMainTileIndex == totalArray[mainArrayIndex][gridArrayIndex])
                            {
                                if (gridArrayIndex == 0) //- 1 <=
                                {
                                    var indexInArrayRight = totalArray[mainArrayIndex][gridArrayIndex + 1];
                                    var indexInArrayLeft = totalArray[mainArrayIndex][gridArrayIndex];

                                    var xxx = (width + widther - 1);
                                    for (int yyy = 0; yyy < height + heighter; yyy++)
                                    {
                                        var testerX = 0;
                                        var testerY = yyy;


                                        if (MazeContainerOfMaze[indexInArrayRight][testerX * (height + heighter) + testerY] == 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayLeft][xxx * (height + heighter) + testerY] = 2;
                                        }
                                        else if (MazeContainerOfMaze[indexInArrayRight][testerX * (height + heighter) + testerY] == 1)
                                        {
                                            MazeContainerOfMaze[indexInArrayLeft][xxx * (height + heighter) + testerY] = 0;
                                        }

                                        if (MazeContainerOfMaze[indexInArrayLeft][testerX * (height + heighter) + testerY] != 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayLeft][testerX * (height + heighter) + testerY] = 0;
                                        }




                                    }
                                }
                                else
                                {
                                    var xxx = (width + widther - 1);
                                    //for (int xxx = 0; xxx < width + widther; xxx++)
                                    {
                                        for (int yyy = 0; yyy < height + heighter; yyy++)
                                        {
                                            //if (xxx == (width + widther - 1))
                                            {
                                                var indexInArrayLeft = totalArray[mainArrayIndex][gridArrayIndex - 1];

                                                var testerX = 0;
                                                var testerY = yyy;

                                                if (MazeContainerOfMaze[indexInArrayLeft][xxx * (height + heighter) + yyy] == 2)
                                                {

                                                    MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 2;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    checkLeft = 0;
                }

                if (checkTop == 1)
                {
                    var currentMainTileIndex = Xindex * (sizeY) + Yindex;

                    int mainArrayIndex = 0;
                    int gridArrayIndex = 0;

                    for (mainArrayIndex = 0; mainArrayIndex < totalArray.Length; mainArrayIndex++)
                    {
                        for (gridArrayIndex = 0; gridArrayIndex < totalArray[mainArrayIndex].Length; gridArrayIndex++)
                        {
                            if (currentMainTileIndex == totalArray[mainArrayIndex][gridArrayIndex])
                            {
                                if (mainArrayIndex == 0)
                                {
                                    var indexInArrayTop = totalArray[mainArrayIndex][gridArrayIndex];
                                    var indexInArrayBottom = totalArray[mainArrayIndex + 1][gridArrayIndex];

                                    var yyy = 0;
                                    for (int xxx = 0; xxx < width + widther; xxx++)
                                    {
                                        var testerX = xxx;
                                        var testerY = (height + heighter - 1);

                                        if (MazeContainerOfMaze[indexInArrayBottom][testerX * (height + heighter) + testerY] == 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayTop][testerX * (height + heighter) + yyy] = 2;
                                        }
                                        else if (MazeContainerOfMaze[indexInArrayBottom][testerX * (height + heighter) + testerY] == 1)
                                        {
                                            MazeContainerOfMaze[indexInArrayTop][testerX * (height + heighter) + yyy] = 0;
                                        }

                                        if (MazeContainerOfMaze[indexInArrayTop][testerX * (height + heighter) + testerY] != 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayTop][testerX * (height + heighter) + testerY] = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int xxx = 0; xxx < width + widther; xxx++)
                                    {
                                        //for (int yyy = 0; yyy < height + heighter; yyy++)
                                        {

                                            var yyy = 0;

                                            var testerX = xxx;
                                            var testerY = (height + heighter - 1);
                                            var indexInArrayTop = totalArray[mainArrayIndex - 1][gridArrayIndex];

                                            //if (yyy == 0)
                                            {

                                                if (MazeContainerOfMaze[indexInArrayTop][xxx * (height + heighter) + yyy] == 2)
                                                {

                                                    MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 2;
                                                }
                                            }

                                            yyy = (height + heighter - 1);

                                            //else if (yyy == (height + heighter - 1))
                                            {
                                                if (checkTopRight == 1)
                                                {
                                                    if (gridArrayIndex < totalArray.Length - 1 && mainArrayIndex > 0)
                                                    {
                                                        var indexInArrayRightTop = totalArray[mainArrayIndex - 1][gridArrayIndex + 1];
                                                        var indexInArrayRight = totalArray[mainArrayIndex][gridArrayIndex + 1];
                                                        indexInArrayTop = totalArray[mainArrayIndex - 1][gridArrayIndex];

                                                        if (MazeContainerOfMaze[indexInArrayRightTop][0 * (height + heighter) + 0] == 1)
                                                        {
                                                            testerX = (width + widther - 1);
                                                            testerY = (height + heighter - 1);
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayRight][0 * (height + heighter) + (height + heighter - 1)] == 1)
                                                        {
                                                            testerX = (width + widther - 1);
                                                            testerY = (height + heighter - 1);
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayTop][(width + widther - 1) * (height + heighter) + 0] == 1)
                                                        {
                                                            testerX = (width + widther - 1);
                                                            testerY = (height + heighter - 1);
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }
                                                    }
                                                    checkTopRight = 0;
                                                }

                                                if (checkTopLeft == 1)
                                                {
                                                    if (gridArrayIndex > 0 && mainArrayIndex > 0)
                                                    {
                                                        var indexInArrayLeftTop = totalArray[mainArrayIndex - 1][gridArrayIndex - 1];
                                                        var indexInArrayLeft = totalArray[mainArrayIndex][gridArrayIndex - 1];
                                                        indexInArrayTop = totalArray[mainArrayIndex - 1][gridArrayIndex];

                                                        if (MazeContainerOfMaze[indexInArrayLeftTop][(width + widther - 1) * (height + heighter) + 0] == 1)
                                                        {
                                                            testerX = 0;
                                                            testerY = (height + heighter - 1);
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayLeft][(width + widther - 1) * (height + heighter) + (height + heighter - 1)] == 1)
                                                        {
                                                            testerX = 0;
                                                            testerY = (height + heighter - 1);
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayTop][0 * (height + heighter) + 0] == 1)
                                                        {
                                                            testerX = 0;
                                                            testerY = (height + heighter - 1);
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }
                                                    }
                                                    checkTopLeft = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    checkTop = 0;
                }

                if (checkBottom == 1)
                {
                    var currentMainTileIndex = Xindex * (sizeY) + Yindex;

                    int mainArrayIndex = 0;
                    int gridArrayIndex = 0;

                    for (mainArrayIndex = 0; mainArrayIndex < totalArray.Length; mainArrayIndex++)
                    {
                        for (gridArrayIndex = 0; gridArrayIndex < totalArray[mainArrayIndex].Length; gridArrayIndex++)
                        {
                            if (currentMainTileIndex == totalArray[mainArrayIndex][gridArrayIndex])
                            {
                                if (mainArrayIndex == totalArray.Length - 1)
                                {
                                    var indexInArrayTop = totalArray[mainArrayIndex - 1][gridArrayIndex];
                                    var indexInArrayBottom = totalArray[mainArrayIndex][gridArrayIndex];

                                    var yyy = (height + heighter - 1);
                                    for (int xxx = 0; xxx < width + widther; xxx++)
                                    {
                                        var testerX = xxx;
                                        var testerY = 0;

                                        if (MazeContainerOfMaze[indexInArrayTop][testerX * (height + heighter) + testerY] == 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayBottom][testerX * (height + heighter) + yyy] = 2;
                                        }
                                        else if (MazeContainerOfMaze[indexInArrayTop][testerX * (height + heighter) + testerY] == 1)
                                        {
                                            MazeContainerOfMaze[indexInArrayBottom][testerX * (height + heighter) + yyy] = 0;
                                        }

                                        if (MazeContainerOfMaze[indexInArrayBottom][testerX * (height + heighter) + testerY] != 2)
                                        {
                                            MazeContainerOfMaze[indexInArrayBottom][testerX * (height + heighter) + testerY] = 0;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int xxx = 0; xxx < width + widther; xxx++)
                                    {
                                        //for (int yyy = 0; yyy < height + heighter; yyy++)
                                        {

                                            var yyy = (height + heighter - 1);
                                            var indexInArrayBottom = totalArray[mainArrayIndex + 1][gridArrayIndex];
                                            var testerX = xxx;
                                            var testerY = 0;
                                            //if (yyy == (height + heighter - 1))
                                            {

                                                if (MazeContainerOfMaze[indexInArrayBottom][xxx * (height + heighter) + yyy] == 2)
                                                {

                                                    MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 2;
                                                }
                                            }

                                            yyy = 0;

                                            //else if (yyy == 0)
                                            {
                                                if (checkBottomLeft == 1)
                                                {
                                                    if (gridArrayIndex > 0 && mainArrayIndex < totalArray.Length - 1)
                                                    {
                                                        var indexInArrayLeftBottom = totalArray[mainArrayIndex + 1][gridArrayIndex - 1];
                                                        var indexInArrayLeft = totalArray[mainArrayIndex][gridArrayIndex - 1];
                                                        indexInArrayBottom = totalArray[mainArrayIndex + 1][gridArrayIndex];

                                                        if (MazeContainerOfMaze[indexInArrayLeftBottom][(width + widther - 1) * (height + heighter) + (height + heighter - 1)] == 1)
                                                        {
                                                            testerX = 0;
                                                            testerY = 0;
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayLeft][(width + widther - 1) * (height + heighter) + 0] == 1)
                                                        {
                                                            testerX = 0;
                                                            testerY = 0;
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayBottom][0 * (height + heighter) + (height + heighter - 1)] == 1)
                                                        {
                                                            testerX = 0;
                                                            testerY = 0;
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }
                                                    }
                                                    checkBottomLeft = 0;
                                                }

                                                if (checkBottomRight == 1)
                                                {
                                                    if (gridArrayIndex < totalArray.Length - 1 && mainArrayIndex < totalArray.Length - 1)
                                                    {
                                                        var indexInArrayRightBottom = totalArray[mainArrayIndex + 1][gridArrayIndex + 1];
                                                        var indexInArrayRight = totalArray[mainArrayIndex][gridArrayIndex + 1];
                                                        indexInArrayBottom = totalArray[mainArrayIndex + 1][gridArrayIndex];

                                                        if (MazeContainerOfMaze[indexInArrayRightBottom][0 * (height + heighter) + (height + heighter - 1)] == 1)
                                                        {
                                                            testerX = (width + widther - 1);
                                                            testerY = 0;
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayRight][0 * (height + heighter) + 0] == 1)
                                                        {
                                                            testerX = (width + widther - 1);
                                                            testerY = 0;
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }

                                                        if (MazeContainerOfMaze[indexInArrayBottom][(width + widther - 1) * (height + heighter) + (height + heighter - 1)] == 1)
                                                        {
                                                            testerX = (width + widther - 1);
                                                            testerY = 0;
                                                            if (MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] != 2)
                                                            {
                                                                MazeContainerOfMaze[Xindex * (sizeY) + Yindex][testerX * (height + heighter) + testerY] = 0;
                                                            }
                                                        }
                                                    }
                                                    checkBottomRight = 0;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    checkBottom = 0;
                }
            }
        }
    }






    // end of main program
    // ============= subroutines ============
    public int[] MakeBlocks(Vector2 test, int indexor)
    {
        Maze = new int[(width + widther) * (height + heighter)];
        //Maze = new int[(width + widther), (height + heighter)];

        test += Vector2.one;

        for (int x = 0; x < width + widther; x++)
        {
            for (int y = 0; y < height + heighter; y++)
            {
                Maze[x * (height + heighter) + y] = 1;
            }
        }

        CurrentTile = Vector2.one;
        _tiletoTry.Push(CurrentTile);
        Maze = CreateMaze(CurrentTile, test, indexor, Maze);  // generate the maze in Maze Array.
        GameObject ptype = null;
        return Maze;
    }

    float temporaryY = 3;
    float size0;
    float tester;
    float noise;






    int[] newMaze;
    List<Vector2> neighbors = new List<Vector2>();
    // =======================================
    public int[] CreateMaze(Vector2 CurrentTile, Vector2 forPerlin, int indexor, int[] Mazor)
    {
        while (_tiletoTry.Count > 0)
        {
            /*if ((int)CurrentTile.x == 0)
            {
                Mazor[(int)CurrentTile.x * (height + heighter) + (int)CurrentTile.y] = 3;
            }*/

            if (Mazor[(int)CurrentTile.x * (height + heighter) + (int)CurrentTile.y] != 2) //&& Mazor[(int)CurrentTile.x * (height + heighter) + (int)CurrentTile.y] != 3
            {
                Mazor[(int)CurrentTile.x * (height + heighter) + (int)CurrentTile.y] = 0;
            }

            neighbors = GetValidNeighbors(CurrentTile, forPerlin, indexor, Mazor, out newMaze);

            noise = SimplexNoise.SeamlessNoise((forPerlin.x / _detailScale) * _heightScale, (forPerlin.y / _detailScale) * _heightScale, randX, randY, 0);
            tester = (noise);

            temporaryY = 3;
            size0 = (tester) * CurrentTile.y + CurrentTile.x;
            temporaryY -= size0;

            if (temporaryY < 0)
            {
                temporaryY *= -1;
            }

            var testing = (int)(temporaryY % neighbors.Count);

            if (neighbors.Count > 0)
            {
                _tiletoTry.Push(CurrentTile);
                CurrentTile = neighbors[testing];
            }
            else
            {
                CurrentTile = _tiletoTry.Pop();
            }
        }

        return newMaze;
    }




    // ================================================
    Vector2 toCheck;
    Vector2? toRemoveVector;
    List<Vector2> validNeighbors = new List<Vector2>();
    private List<Vector2> GetValidNeighbors(Vector2 centerTile, Vector2 forPerlin, int indexor, int[] Mazor, out int[] mazer)
    {
        validNeighbors.Clear();
        foreach (var offset in offsets)
        {
            toCheck = new Vector2(centerTile.x + offset.x, centerTile.y + offset.y);

            if (toCheck.x % 2 == 1 || toCheck.y % 2 == 1)
            {
                if (IsInside(toCheck))
                {
                    if (Mazor[(int)toCheck.x * (height + heighter) + (int)toCheck.y] == 1 && HasThreeWallsIntact(toCheck, Mazor)) //Maze[(int)toCheck.x * (height + heighter) + (int)toCheck.y] //Maze[(int)toCheck.x,(int)toCheck.y]
                    {
                        validNeighbors.Add(toCheck);
                    }

                    else if (Mazor[(int)toCheck.x * (height + heighter) + (int)toCheck.y] == 0 && HasThreeWallsIntact(toCheck, Mazor))
                    {
                        foreach (var offseter in offsets)
                        {
                            var testerX = toCheck.x + offseter.x;
                            var testerY = toCheck.y + offseter.y;
                            var newVec = new Vector2(testerX, testerY);

                            var indexX = testerX;
                            if (indexX < 0)
                            {
                                indexX = (testerX * -1) + (width);
                            }

                            var indexY = testerY;
                            if (indexY < 0)
                            {
                                indexY = (testerY * -1) + (height);
                            }

                            if (IsInside(newVec))
                            {
                                if (indexX == 0 || indexX == width + widther - 1 ||
                                    indexY == 0 || indexY == height + heighter - 1)
                                {
                                    Mazor[(int)testerX * (height + heighter) + (int)testerY] = 2;
                                }
                            }
                        }
                    }


                    /*if (indexor == 7 ||indexor == 6 || indexor == 8)
                    {
                        if (toCheck.x == 0)
                        {
                            Mazor[(int)toCheck.x * (height + heighter) + (int)toCheck.y] = 3;
                        }
                    }*/
                }
            }
        }
        mazer = Maze;
        return validNeighbors;
    }

    Vector2 neighborToCheck;
    private bool HasThreeWallsIntact(Vector2 Vector2ToCheck, int[] Mazor)
    {
        int intactWallCounter = 0;
        foreach (var offset in offsets)
        {
            neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 1) //Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y]
            {
                intactWallCounter++;
            }
        }
        return intactWallCounter == 3;
    }

    private int HasThreeWallsIntactInt(Vector2 Vector2ToCheck, int[] Mazor)
    {
        int intactWallCounter = 0;
        foreach (var offset in offsets)
        {
            neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 1)//|| IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] ==2) //Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y]
            {
                intactWallCounter++;
            }
        }
        return intactWallCounter; // intactWallCounter == 3;
    }







    private int isCornerWallsIntactInt(Vector2 Vector2ToCheck, int[] Mazor, List<Vector2> someOffsets)
    {
        int intactWallCounter = 0;
        foreach (var offset in someOffsets)
        {
            neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 1)//|| IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] ==2) //Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y]
            {
                intactWallCounter++;
            }
        }
        return intactWallCounter; // intactWallCounter == 3;
    }










    private int HasFourWallsIntactInt(Vector2 Vector2ToCheck, int[] Mazor, out List<Vector2> newList, Vector2 oriPos, out int intactTile, out int emptyTile, out int outOfBounds)
    {
        List<Vector2> arrayOfOffsetPos = new List<Vector2>();

        int someIndex = 0;
        int intactWallCounter = 0;
        int _emptyTile = 0;
        int _outOfBounds = 0;


        //Check all four directions around the tile
        foreach (var offset in offsetsSeven)
        {
            //find the neighbor's position
            Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            //make sure it is inside the maze, and it hasn't been dug out yet

            if (!IsInside(neighborToCheck))
            {
                arrayOfOffsetPos.Add(offset);
                _outOfBounds++;
            }

            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 0 || IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 2)
            {
                //objecter = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //objecter.transform.position = new Vector3(oriPos.x + neighborToCheck.x - widther - 1, 1, oriPos.y+ neighborToCheck.y - heighter - 1);
                //objecter.transform.parent = arrayOfGridMaze[currentIndexor].transform;
                //objecter.GetComponent<MeshRenderer>().material = redMat;

                _emptyTile++;
            }

            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 1)
            {
                intactWallCounter++;
            }

            someIndex++;
        }

        intactTile = intactWallCounter;
        emptyTile = _emptyTile;
        outOfBounds = _outOfBounds;



        //tell whether three walls are intact
        newList = arrayOfOffsetPos;
        return intactWallCounter;// intactWallCounter == 4; //|| intactWallCounter == 3|| intactWallCounter == 2 intactWallCounter == 5 ||
    }



    private int HasSomeWallsIntactInt(Vector2 Vector2ToCheck, int[] Mazor)
    {
        int someIndex = 0;
        int intactWallCounter = 0;

        //Check all four directions around the tile
        foreach (var offset in offsetsSeven)
        {
            //find the neighbor's position
            Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            //make sure it is inside the maze, and it hasn't been dug out yet

            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 0 || IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 2)
            {

                intactWallCounter++;
            }

            someIndex++;
        }

        //tell whether three walls are intact
        return intactWallCounter;// intactWallCounter == 4; //|| intactWallCounter == 3|| intactWallCounter == 2 intactWallCounter == 5 ||
    }







    private bool HasFourWallsIntact(Vector2 Vector2ToCheck, int[] Mazor)
    {
        int intactWallCounter = 0;
        //Check all four directions around the tile
        foreach (var offset in offsetsSeven)
        {
            //find the neighbor's position
            Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            //make sure it is inside the maze, and it hasn't been dug out yet

            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 0 || IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 2)
            {
                intactWallCounter++;
            }
        }
        //tell whether three walls are intact


        return intactWallCounter == 4; //|| intactWallCounter == 3|| intactWallCounter == 2 intactWallCounter == 5 ||
    }







    /*private bool HasSevenWallsIntact(Vector2 Vector2ToCheck, int[] Mazor)
    {
        //toRemove = null;

        int intactWallCounter = 0;
        //Check all four directions around the tile
        foreach (var offset in offsetsSeven)
        {
            //find the neighbor's position
            Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            //make sure it is inside the maze, and it hasn't been dug out yet

            if (IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 0) //|| IsInside(neighborToCheck) && Mazor[(int)neighborToCheck.x * (height + heighter) + (int)neighborToCheck.y] == 2
            {
                intactWallCounter++;
            }
            /*else if (IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x, (int)neighborToCheck.y] == 1)
            {
                toRemove = new Vector2(neighborToCheck.x, neighborToCheck.y);
            }
        }
        //tell whether three walls are intact
        //UnityEngine.Debug.Log(intactWallCounter);
        return intactWallCounter == 7;
    }*/


















    // ================================================
    private bool IsInside(Vector2 p)
    {
        return p.x >= 0 && p.y >= 0 && p.x < (width + widther) && p.y < (height + heighter);
    }
}
