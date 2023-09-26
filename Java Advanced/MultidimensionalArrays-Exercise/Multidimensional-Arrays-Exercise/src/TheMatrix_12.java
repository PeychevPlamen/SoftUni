import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class TheMatrix_12 {
    public static void main(String[] args) {
        readInput();
    }

    /**
     * Reads inputs, calls one of the solving methods, shows the result and the time(ms) it needed.
     */
    public static void readInput() {
        Scanner scanner = new Scanner(System.in);
        String str[] = scanner.nextLine().split(" ");
        int r = Integer.parseInt(str[0]);
        int c = Integer.parseInt(str[1]);
        char table [][] = new char[r][c];
        String line[];
        for(int i=0;i<r;i++)
        {
            line = scanner.nextLine().split(" ");
            for(int j=0;j<c;j++)
            {
                table[i][j] = line[j].charAt(0);
            }
        }
        char fillChar = scanner.nextLine().charAt(0);
        str = scanner.nextLine().split(" ");
        int startRow  = Integer.parseInt(str[0]);
        int startCol  = Integer.parseInt(str[1]);
        long startTime = System.currentTimeMillis();
        // matrixBFS(table,fillChar,startRow,startCol);
        matrixDFS(table,fillChar,startRow,startCol,table[startRow][startCol]);
        printTable(table);
    //    System.out.printf("Time is %d\n",System.currentTimeMillis()-startTime);

    }

    /**
     * BFS Solution
     * Using a LinkedList implementation of a queue we add pairs(MyPair class) of elements which represent coordinates on the table
     * how are elements removed --->. how are elements added <---
     * 1.the starting element at [startRow][startCol] is added
     * 2.remove the leftmost element(the oldest in the queue) until queue is empty
     * 3.1.if we aren't outbounds and the adjacent elements isn't marked => mark it and add it to the queue
     * 3.2, 3.3 , 3.4 is the same for different adjacency (up,down,left,right)(order doesn't matter)
     * 4.repeat 2
     * @param table - 2D matrix with elements
     * @param fillChar - char for replacement
     * @param startRow
     * @param startCol
     */
    public static void matrixBFS(char table[][],char fillChar,int startRow,int startCol)// BFS solution
    {
        char startChar = table[startRow][startCol];
        MyPair startPair = new MyPair(startRow,startCol);
        Queue<MyPair> queue = new LinkedList<>();
        queue.add(startPair);
        while(!queue.isEmpty())
        {

            MyPair cur = queue.remove();
            table[cur.x][cur.y]=fillChar;
            if(cur.x+1<table.length&&table[cur.x+1][cur.y]==startChar)
            {
                table[cur.x+1][cur.y] = fillChar;
                queue.add(new MyPair(cur.x+1,cur.y));
            }

            if(cur.y+1<table[0].length&&table[cur.x][cur.y+1]==startChar)
            {
                table[cur.x][cur.y+1] = fillChar;
                queue.add(new MyPair(cur.x,cur.y+1));
            }

            if(cur.x-1>=0&&table[cur.x-1][cur.y]==startChar)
            {
                table[cur.x-1][cur.y] = fillChar;
                queue.add(new MyPair(cur.x-1,cur.y));
            }

            if(cur.y-1>=0&&table[cur.x][cur.y-1]==startChar)
            {
                table[cur.x][cur.y-1] = fillChar;
                queue.add(new MyPair(cur.x,cur.y-1));

            }

        }

    }


    /**
     * DFS solution
     * Starting at position [currentRow][currentCol] we mark it and call matrixDFSHelper for solution
     *
     * @param table - 2D matrix with elemetns
     * @param fillChar - char for replacement
     * @param currentRow
     * @param currentCol
     * @param startChar - char at starting position
     */
    public static void matrixDFS(char table[][],char fillChar,int currentRow,int currentCol,char startChar)
    {
        table[currentRow][currentCol]=fillChar;
        matrixDFSHelper(table, fillChar, currentRow, currentCol, startChar);
    }

    /**
     * starting at [currentRow][currentCol]
     * 1.we peek in this order : down,right,up,left
     * 2. if the peeked position isn't outbounds and isn't marked a new call is made with the peeked position
     * 3. after every possible adjacent cell has been either modified or ignored
     * no more calls will be made and the program will end.
     * @param table -2D matrix with elemetns
     * @param fillChar- char for replacemen
     * @param currentRow
     * @param currentCol
     * @param startChar- char at starting position
     */
    public static void matrixDFSHelper(char table[][],char fillChar,int currentRow,int currentCol,char startChar)// DFS solution
    {
        if(currentRow+1<table.length&&table[currentRow+1][currentCol]==startChar)
        {
            table[currentRow+1][currentCol] = fillChar;
            matrixDFSHelper(table,fillChar,currentRow+1,currentCol,startChar);
        }

        if(currentCol+1<table[0].length&&table[currentRow][currentCol+1]==startChar)
        {
            table[currentRow][currentCol+1] = fillChar;
            matrixDFSHelper(table,fillChar,currentRow,currentCol+1,startChar);
        }

        if(currentRow-1>=0&&table[currentRow-1][currentCol]==startChar)
        {
            table[currentRow-1][currentCol] = fillChar;
            matrixDFSHelper(table,fillChar,currentRow-1,currentCol,startChar);
        }
        if(currentCol-1>=0&&table[currentRow][currentCol-1]==startChar)
        {
            table[currentRow][currentCol-1] = fillChar;
            matrixDFSHelper(table,fillChar,currentRow,currentCol-1,startChar);
        }


    }

    /**
     * Prints the matrix
     * @param table
     */
    public static void printTable(char table[][])
    {
        for(int i=0;i<table.length;i++)
        {
            for(int j=0;j<table[0].length;j++)
            {
                System.out.printf("%c",table[i][j]);
            }System.out.printf("\n");
        }
    }

    /**
     * Useful for BFS solution
     */
    static class MyPair
    {
        int x;
        int y;
        public MyPair(int x,int y)
        {
            this.x=x;
            this.y=y;
        }
        public String toString()
        {
            return String.format("[%d,%d]",x,y);
        }
    }
}
