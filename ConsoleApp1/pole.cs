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
        public int size;
        public fieldItem start;
        public fieldItem end;


        public pole(string lvlName, int size)
        {
            this.lvlName = lvlName;
            this.size = size;
        }


        public void generateSqare()
        {
            fieldItem lastMade;

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
                        north = null;

                    } 
                }
            }
        }


        

        internal class fieldItem
        {


            public string name;
            public fieldItem north;
            public fieldItem south;
            public fieldItem west;
            public fieldItem east;

            public fieldItem(string name, fieldItem north, fieldItem south, fieldItem west, fieldItem east)
            {
                this.name = name;
                this.north = north;
                this.south = south;
                this.west = west;
                this.east = east;
            }   
        }
    }
}   
