using System;
using System.Collections.Generic;
using System.Globalization;
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
        //head node
        public fieldItem? start;
        //tail node
        public fieldItem? end;
        //starting position
        public fieldItem? home;
        //finish
        public fieldItem? granny;


        private Dictionary<String, String> rooms_descriptions;


        private List<String> roomNames;


        private List<Question> questions = new List<Question>
        {
            new Question("What's 9+10?","21"),
            new Question("What is the highest-rated film on IMDb as of January 1st, 2022?","b",new string[]{"a)Godfather","b)Shawshank Redemption","c)Pulp Fiction"}),
            new Question("In what country is the Chernobyl nuclear plant located?","a",new string[]{"a)Ukraine","b)Russia","c)Hungary","d)Romania"}),
            new Question("True or False: Halloween originated as an ancient Irish festival.","True"),
            new Question("Which planet has the most moons?","a",new string[]{"a)Saturn","b)A-2b","c)Earth","d)Jupiter" }),
            new Question("How many ghosts chase Pac-Man at the start of each game?","4"),
            new Question("What company was originally called \"Cadabra\"? Amazon","c",new string[]{"a)Netflix","b)AliExpress","c)Amazon","d)Tesla"}),
            new Question("How many faces does a Dodecahedron have?","a",new string[]{"a)12","b)8","c)20"}),
            new Question("Who was the Ancient Greek God of the Sun?","c",new string[]{"a)Hermes","b)Hades","c)Apollo","d)Zeus"}),
            new Question("5x^2-80=0","5"),
            new Question("What is the most common surname in the United States?","c",new string[]{"a)Free","b)Jones","c)Smith","d)Burger"}),
            new Question("What country has the highest life expectancy?","a",new string[]{"a)Honk Kong","b)Japan","c)Switzerland","d)Norway"}),
            new Question("What is the 4th letter of the Greek alphabet?","delta"),
            new Question("What character has both Robert Downey Jr. and Benedict Cumberbatch played?","Sherlock Holmes"),
            new Question("Which planet in the Milky Way is the hottest?","b",new string[]{"a)Earth","b)Venus","c)Jupiter","d)Mars"}),
            new Question("Where did sushi originate?","a",new string[]{"a)China","b)Japan","c)Korea","d)Hawaii"}),
            new Question("What is a group of crows called?","c",new string[]{"a)Flock","b)Party","c)A murder","d)A collaboration"}),
            new Question("How many dots appear on a pair of dice?","42"),
            new Question("Compared to their body weight, what animal is the strongest?","a",new string[]{"a)Dung Beetle","b)Elephant","c)Ant","d)Cow"}),
            new Question("How many hearts does an octopus have?","3"),
            new Question("Where is the strongest human muscle located? ","a",new string[]{"a)Jaw","b)Quad","c)Biceps","d)Hamstring"}),
            new Question("How many bones do we have in an ear?","3"),
            new Question("How many lives is a cat said to have?","9"),
            new Question("What artist has the most streams on Spotify? ","d",new string[]{"a)Justin Timberlake","b)Billie Eilish","c)XXXTentacion","d)Drake"}),
            new Question("How many minutes are in a full week?","10080"),
            new Question("What is a group of pandas known as?","c",new string[]{"a)Herd","b)Meeting","c)Embarassment","d)Circus"}),
            new Question("On what continent would you find the world’s largest desert?","Antarctica"),
            new Question("Brain of computer is?","a",new string[]{"a)CPU","b)GPU","c)RAM","d)HDD"}),
            new Question("71 in binary","1000111"),
            new Question("2 Celsius to Kelvin","275"),
            new Question("Which country are the Giza Pyramids in?","d",new string[]{"a)Greece","b)Nigeria","c)Zimbabwe","d)Egypt"}),
            new Question("Most widely spoken language in the world is?","c",new string[]{"a)Russian","b)English","c)Mandarrin","d)Arabic"}),
            new Question("WWhat is the name of the toy cowboy in Toy Story?","Woody"),
            new Question("Which Disney movie is Elsa in?","Frozen"),
            new Question("How many teeth does an average adult human have","32"),
            new Question("14^2","196"),
            new Question("Dou you remember? The 21st night of...","September"),
            new Question("If you are in a race, and you pass the one in second place, what place are you in?","Second"),
            new Question("How many seconds do 2 hours have?","7200")

        };

        
        


        public pole(string lvlName, int rows, int cols)
        {
            this.lvlName = lvlName;
            this.rows = rows;
            this.cols = cols;

            generateLinked();
            generateField();
            fillRoomsAndDescriptions();
            nameRooms();
            assignQuestions();

        }




        public void fillRoomsAndDescriptions()
        {
            rooms_descriptions = new Dictionary<String, String>();
            rooms_descriptions.Add("Dark Forest","A forest, where no light can be seen except for the small light emmited by your candle.");
            rooms_descriptions.Add("Mountain path", "A steep path, leading up the mountain. You can see goats climbing the mountain around the path.");
            rooms_descriptions.Add("A cloaked stranger", "Someone in dark grey robes, leaning into a tree next to the road. Better get going.");
            rooms_descriptions.Add("A pack of rabbits", "Awww, so many cute rabbits, you cannot just go by without petting some.");
            rooms_descriptions.Add("Swamp", "Florida, except without the terrible inhabitants.");
            rooms_descriptions.Add("Small Chapel", "Light a candle here for good luck.");
            rooms_descriptions.Add("A cave", "Grumbles and rumbles can be heard from within, might be the big bear Mumbles.");
            rooms_descriptions.Add("A friendly face", "Residence of the terrible witch, try to sneak past.");
            rooms_descriptions.Add("Witch's hut", "A forest, where no light can be seen except for the small light emmited by your candle.");
            rooms_descriptions.Add("Cannibal's campfire", "You see a man, roasting something that looks way too much like a human leg.");
            rooms_descriptions.Add("Lake of the Nokken", "You hear a strange sound, very soothing to the ears. It's coming from the lake, calling you, drawing you near.");
            rooms_descriptions.Add("The festival of the cursed", "Glorious celebrations of the people from beneath, dancing, singing and drinking...the blood of innocent children.");
            rooms_descriptions.Add("Mud", "Your feet got stuck in mud.");
            rooms_descriptions.Add("Creepy Vines", "Barbed vines tangle around your feet, trying to bind you");
            rooms_descriptions.Add("Giant crow", "Giant crow from the distant peak, quickly hide before it spots you.");
            rooms_descriptions.Add("Big frogge", "To a frog that is as big as a house, you look a lot like a tasty fly.");
            rooms_descriptions.Add("Dog in need", "A dog is lying across the path, hurt and angry.");
            rooms_descriptions.Add("A very deep trench", "You need to hopp across some stones and branches if you want to cross it.");
            rooms_descriptions.Add("Boobie trap", "U notice a trap a bit too late, and you must carefully get out of it without trigerring it.");
            rooms_descriptions.Add("Slimy merchant", "This merchant is trying to sell you some trinket, and he won't back down.");


            this.roomNames = new List<string>(rooms_descriptions.Keys); 

        }




        public void assignQuestions()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Assigning questions");
            fieldItem curr = start;
            Random rng = new Random();
            for (int i = 0; i < count(); i++)
            {
                if (curr != home && curr != granny)
                {
                    int n = rng.Next(questions.Count());
                    curr.setQuestion(questions.ElementAt(n));
                    questions.RemoveAt(n);
                }
                curr = curr.east;
            }
            Console.WriteLine("Questions assigned");
            Console.WriteLine("********************");
        }

        public void nameRooms()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Naming rooms and describing them");
            Random rng = new Random();
            home = getRandomRoom();
            home.setNameAndDescription("Home", "Your cozy home, if only you could stay here.");
            do
            {
                granny = getRandomRoom();
                if (granny == home) continue;
                granny.setNameAndDescription("Grandmother's house", "It smells suspiciously of dog furr");
            } while (granny == home);
            fieldItem curr = start;
            for(int i = 0; i < count(); i++)
            {
                if(curr != home && curr != granny)
                {
                    if(roomNames.Count() == 0)
                    {
                        Console.WriteLine("Out of room names!");
                        continue;
                    }
                    int n = rng.Next(roomNames.Count());
                    curr.setNameAndDescription(roomNames.ElementAt(n), rooms_descriptions[roomNames.ElementAt(n)]);
                    roomNames.RemoveAt(n);
                }
                curr = curr.east;
            }
            Console.WriteLine("Rooms are named");
            Console.WriteLine("********************");
        }



        //Creates a semi-doubly linked list of the "rooms", that is then used as the foundation in generateField() to link all the rooms together 
        //TLDR west and east connection for every room
        public void generateLinked()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Generating basic LL");
            fieldItem? lastMade = null;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine("Row:" + i + ';' + "cols:" + j + ';');
                    if (i == 0 && j == 0)
                    {
                        this.start = new fieldItem("Name:" + i + "," + j);
                        this.end = start;
                        lastMade = start;
                        continue;
                    }
                    

                    lastMade.east = new fieldItem("Name:" + i + "," + j);
                    if(j != 0) lastMade.east.west = lastMade;
                    lastMade = lastMade.east;
                }
            }

            this.end = lastMade;

            Console.WriteLine("Generation finished; Head" +start + " Tail"+end);
            Console.WriteLine("********************");
        }

        //Sounds fancier than is, links rooms together, basically creating
        //TLDR north and south connection for every room, and disconnects wrong EAST room connections left from previous method
        public void generateField()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Generating field");
            fieldItem? north = start;
            fieldItem? south = start;
            for(int i = 0; i < rows-1; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                   
                    //This moves *n(the number of collumns, because it will always end up below the current north room) times to the east room to get to the current north room's south room
                    for (int k = 0; k < cols; k++)
                    {
                        south = south.east;
                    }

                    //making the link
                    Console.WriteLine("Connecting "+north + "<->" + south);
                    north.south = south;
                    south.north = north;
                    //Disconnects wrong east connections for the right most collumn of grid
                    
                    north = north.east;
                    south = north;
                    if (j == cols)
                    {
                        north.west.east = null;
                    }
                }
            }
            Console.WriteLine("Generation finished; \nHead:\n"+start.detailedToString() );
            Console.WriteLine("Tail:\n" + end.detailedToString());
            Console.WriteLine("********************");

        }


        public int count()
        {
            return rows * cols;
            
        }


        public fieldItem? getRandomRoom()
        {
            Random rng = new Random();
            fieldItem rRooom = start;
            for(int I = 0; I < rng.Next(count()); I++)
            {
                rRooom = rRooom.east;
            }
            return rRooom;
        }







        public override string ToString() {
            String returnString = "";

            if(start != null)
            {
                fieldItem curr = start;
                do
                {
                    returnString += curr.ToString() + " -- ";
                    curr = curr.east;

                } while (curr != end);
                returnString += curr.ToString() + " -- ";
            }
            

            return this.lvlName +"( "+this.cols + ", "+this.rows+")\n"+returnString;
        }


        internal class fieldItem
        {


            public string name;
            public string description;
            public Question? question;


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
                this.question = null;
                description = "";
            }

            public fieldItem(string name)
            {
                this.name = name;
                this.north = null;
                this.south = null;
                this.west = null;
                this.east = null;
                this.question = null;
                description = "";
            }

            public void setNameAndDescription(string name, string description)
            {
                this.name =name;
                this.description = description;
            }

            public void setQuestion(Question? question)
            {
                this.question = question;
            }
            
            public string detailedToString()
            {
                string rString = "\n   North - "+this.north;
                rString += "\nWest"+ "  East -" + this.west + " ; " + this.east;
                rString += "\n   South - "+this.south;

                return ToString() + rString;

            }

            public override string ToString()
            {
                return name;
            }
        }
    }
}   
