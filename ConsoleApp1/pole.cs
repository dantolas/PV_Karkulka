using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class pole
    {
        
        public string lvlName;
        public int rows;
        public int cols;
        public fieldItem start;
        public fieldItem end;


        public pole(string lvlName, int rows, int cols)
        {
            this.lvlName = lvlName;
            this.rows = rows;
            this.cols = cols;
        }




        public void generateLinked()
        {
            fieldItem? lastMade = null;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; i++)
                {
                    if (i == 0 && j == 0)
                    {

                        this.start = new fieldItem("Name:" + i + "," + j);
                        this.end = start;
                        lastMade = start;
                        continue;
                    }
                    if(i == rows && j == cols)
                    {
                        lastMade.east = new fieldItem("Name:" + i + "," + j);
                        this.end = lastMade.east;
                        lastMade = lastMade.east;
                    }

                    lastMade.east = new fieldItem("Name:" + i + "," + j);
                    lastMade = lastMade.east;
                }
            }
        }


        /*public void generateField()
        {
            fieldItem? lastMade = null;

            fieldItem? north;
            fieldItem? south;
            fieldItem? east;
            fieldItem? west;
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; i++)
                {
                   if(i == 0 && j == 0)
                    {

                        this.start = new fieldItem("Name:" + i + "," + j);
                        this.end = start;
                        lastMade = start;
                        continue;
                    }

                   if(i == 0)
                    {
                        north = null;
                        west = lastMade;


                    }
                }
            }
        }*/

        public override string ToString() {
            String returnString = "";


            fieldItem curr = start;
            do
            {
                returnString += curr.ToString()+" -- ";
                curr = curr.east;

            } while (curr != end);

            return returnString;
        }


        internal class fieldItem
        {


            public string name;
            public fieldItem? north;
            public fieldItem? south;
            public fieldItem? west;
            public fieldItem? east;

            public fieldItem(string name, fieldItem north, fieldItem south, fieldItem west, fieldItem east)
            {
                this.name = name;
                this.north = north;
                this.south = south;
                this.west = west;
                this.east = east;
            }

            public fieldItem(string name)
            {
                this.name = name;
                this.north = null;
                this.south = null;
                this.west = null;
                this.east = null;
            }

            public override string ToString()
            {
                return name;
            }
        }
    }
}   
