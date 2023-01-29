using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace markbk
{ 
    // extra class for some methods    
    public class xtramethods
    {
        // list for student objects
        public List<StudentConstructor> classlist = new List<StudentConstructor>();
        // list of student names to find index to find student object
        public List<string> namelist = new List<string>();
        // list of student averages for ease
        public List<double> classavg = new List<double>();

        //find
        
        public void find(int totstu, int currstuind)
        {
            Console.Write("Please input the name of the student exactly: ");
            string inpu = Convert.ToString(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < totstu; i++)
            {
                if (namelist[i] == inpu)
                {
                    if (found == false)
                    {
                        found = true;
                        currstuind = i;
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("That student was not found");
            }
            else
            {
                // now print info
                Console.WriteLine("{0} is {1} years old and is in grade {2}, and is enrolled in {3} course(s) with an average of {4}%",
                    classlist[currstuind].name, classlist[currstuind].age, classlist[currstuind].grade,
                    classlist[currstuind].totclass, classlist[currstuind].avg);
            }
        }


        //delete
        // i no longer use this method
        public void delete(int totstu, int currstuind)
        {
            Console.Write("Please input the name of the student exactly:  ");
            string inpu = Convert.ToString(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < totstu; i++)
            {
                if (namelist[i] == inpu)
                {
                    if (found == false)
                    {
                        found = true;
                        currstuind = i;
                        Console.WriteLine("{0} has been removed from the class", classlist[currstuind].name);
                        classlist.RemoveAt(currstuind);
                        namelist.RemoveAt(currstuind);
                        classavg.RemoveAt(currstuind);
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("That student was not found");
            }

        }

        //calc avg
        public void calcavg(int totstu)
        {
            double clasavg = 0;
            int totmrk = 0;
            foreach (int f in classavg)
            {
                totmrk = totmrk + f;
                clasavg = totmrk / totstu;
            }
            Console.WriteLine("The class average is {0}% with {1} Students", clasavg, totstu);
        }

        //displayclass
        public void displayclass(int totstu)
        {
            Console.WriteLine("There are {0} Students in the Class: ", totstu);
            foreach (string h in namelist)
            {
                Console.WriteLine(h);
            }
            Console.WriteLine(" ");
        }

        //honor roles
        public void honor(int totstu)
        {
            Console.WriteLine("The Students with averages above 80% are:  ");

            bool found = false;

            for (int i = 0; i < totstu; i++)
            {
                if (classavg[i] >= 80)
                {
                    found = true;
                    Console.WriteLine(classlist[i].name);


                }
            }
            if (found == false)
            {
                Console.WriteLine("No students acheived honor role");
            }
        }

    }

    // the inherited class
    public class StudentConstructor : StudentPortal
    {
        // this derived class is just a constructor

        public StudentConstructor(string nam, string grad, int totclas, string ag, double av)
        {
            name = nam;
            grade = grad;
            totclass = totclas;
            age = ag;
            avg = av;
        }
    }
    public class StudentPortal : StudentFields
    {
        // empty class to prove inheritance
    }


    // the student class
    public class StudentFields
    {
        // this parent class just holds the fields
        // fields
        public string name;
        public string age;
        public string grade;
        public int totclass;       
        public double avg;
        
        public static void addStuduent(xtramethods method1)
        {
            //name
            Console.Write("Name: ");
            string nam = Console.ReadLine();
            method1.namelist.Add(nam);
            //Console.WriteLine(method1.namelist[0]);

            //grade
            string grad;
            bool input2check = true;
            do
            {
                Console.Write("Grade: ");
                grad = Console.ReadLine();
                if (grad == "9" || grad == "10" || grad == "11" || grad == "12")
                {
                    input2check = false;

                }             
                else
                {
                    input2check = true;
                    Console.WriteLine("incorrect input");
                }
            } while (input2check == true);

            //age
            string ag = "eeee";
            switch (grad)
            {
                case "9":
                    ag = "14";
                    break;
                case "10":
                    ag = "15";
                    break;
                case "11":
                    ag = "16";
                    break;
                case "12":
                    ag = "17";
                    break;
            }

            //# of classes
            int totclas = 4;
            int input3check = 1;
            if (grad == "12")
            {
                Console.Write("How many classes is this student taking this semester?(1-4)  ");
                while (input3check == 1)
                {
                    totclas = Convert.ToInt32(Console.ReadLine());
                    if (totclas >= 1 && totclas <= 4)
                    {
                        input3check = 0;
                    }

                    else
                    {
                        input3check = 1;
                        Console.WriteLine("Incorrect Input.");
                    }
                }
            }

            //classes and marks
            string c1;
            int m1 = 0;
            string c2;
            int m2 = 0;
            string c3;
            int m3 = 0;
            string c4;
            int m4 = 0;

            if (grad == "12")
            {
                if (totclas >= 1)
                {
                    Console.Write("Name of 1st class: ");
                    c1 = Console.ReadLine();
                    Console.Write("Mark of 1st class(out of 100): ");
                    bool input4check = true;
                    do
                    {
                        m1 = Convert.ToInt32(Console.ReadLine());
                        if (m1 < 0 || m1 > 100)
                        {
                            input4check = true;
                            Console.WriteLine("Incorrect Input");
                        }
                        else
                        {
                            input4check = false;
                        }
                    } while (input4check == true);
                }
                if (totclas >= 2)
                {
                    Console.Write("Name of 2nd class: ");
                    c2 = Console.ReadLine();
                    Console.Write("Mark of 2nd class(out of 100): ");
                    bool input4check = true;
                    do
                    {
                        m2 = Convert.ToInt32(Console.ReadLine());
                        if (m2 < 0 || m2 > 100)
                        {
                            input4check = true;
                            Console.WriteLine("Incorrect Input");
                        }
                        else
                        {
                            input4check = false;
                        }
                    } while (input4check == true);
                }
                if (totclas >= 3)
                {
                    Console.Write("Name of 3rd class: ");
                    c3 = Console.ReadLine();
                    Console.Write("Mark of 3rd class(out of 100): ");
                    bool input4check = true;
                    do
                    {
                        m3 = Convert.ToInt32(Console.ReadLine());
                        if (m3 < 0 || m3 > 100)
                        {
                            input4check = true;
                            Console.WriteLine("Incorrect Input");
                        }
                        else
                        {
                            input4check = false;
                        }
                    } while (input4check == true);
                }
                if (totclas == 4)
                {
                    Console.Write("Name of 4th class: ");
                    c4 = Console.ReadLine();
                    Console.Write("Mark of 4th class(out of 100): ");
                    bool input4check = true;
                    do
                    {
                        m4 = Convert.ToInt32(Console.ReadLine());
                        if (m4 < 0 || m4 > 100)
                        {
                            input4check = true;
                            Console.WriteLine("Incorrect Input");
                        }
                        else
                        {
                            input4check = false;
                        }
                    } while (input4check == true);
                }
            }
            else
            {
                Console.Write("Name of 1st class: ");
                c1 = Console.ReadLine();
                Console.Write("Mark of 1st class(out of 100): ");
                bool input4check = true;
                do
                {
                    m1 = Convert.ToInt32(Console.ReadLine());
                    if (m1 < 0 || m1 > 100)
                    {
                        input4check = true;
                    }
                    else
                    {
                        input4check = false;
                    }
                } while (input4check == true);

                Console.Write("Name of 2nd class: ");
                c2 = Console.ReadLine();
                Console.Write("Mark of 2nd class(out of 100): ");
                bool input5check = true;
                do
                {
                    m2 = Convert.ToInt32(Console.ReadLine());
                    if (m2 < 0 || m2 > 100)
                    {
                        input5check = true;
                    }
                    else
                    {
                        input5check = false;
                    }
                } while (input5check == true);

                if (totclas >= 3)
                {
                    Console.Write("Name of 3rd class: ");
                    c3 = Console.ReadLine();
                    Console.Write("Mark of 3rd class(out of 100): ");
                    bool input6check = true;
                    do
                    {
                        m3 = Convert.ToInt32(Console.ReadLine());
                        if (m3 < 0 || m3 > 100)
                        {
                            input6check = true;
                        }
                        else
                        {
                            input6check = false;
                        }
                    } while (input6check == true);
                }

                Console.Write("Name of 4th class: ");
                c4 = Console.ReadLine();
                Console.Write("Mark of 4th class(out of 100): ");
                bool input7check = true;
                do
                {
                    m4 = Convert.ToInt32(Console.ReadLine());
                    if (m4 < 0 || m4 > 100)
                    {
                        input7check = true;
                    }
                    else
                    {
                        input7check = false;
                    }
                } while (input7check == true);
            }

            // average
            double av = 0;
            av = (m1 + m2 + m3 + m4) / (totclas);
            method1.classavg.Add(av);

            //Console.WriteLine(av);

            //object created and sending the input through paramaters to constrcutor
            StudentConstructor y = new StudentConstructor(nam, grad, totclas, ag, av);
            method1.classlist.Add(y);

        }




        // main method
        public static void Main(string[] args)
        {
            //creating exra methods objects
            xtramethods methods = new xtramethods();

            bool input1check = true;
            int input1;
            Console.WriteLine("How many students are in the class?(1-30)   ");
            // makes sure input is within bounds
            do
            {

                input1 = Convert.ToInt32(Console.ReadLine());
                if (input1 < 1 || input1 > 30)
                {
                    input1check = true;
                    Console.WriteLine("Input was out of bounds");
                }
                else
                {
                    input1check = false;
                }
            } while (input1check == true);
            // tottal # of students
            int totstu = input1;

            Console.WriteLine("Please Input info on the students");
            // asks user for input and creates object
            for (int i = 0; i < totstu; i++)
            {
                StudentFields.addStuduent(methods);
            }

            bool menuloop = true;
            int currstuind = -1;
            //the main menu with the basic user options
            do
            {
                Console.WriteLine("input the corresponding number to select the option");
                Console.WriteLine("1: Add");
                Console.WriteLine("2: Find");
                Console.WriteLine("3: Delete");
                Console.WriteLine("4: Calculate Class Average");
                Console.WriteLine("5: Display Class List");
                Console.WriteLine("6: Display All Honor Role Students");
                Console.WriteLine("7: Quit");
                string inp = Console.ReadLine();
                
                if (inp == "1")
                {
                    //add
                    totstu++;
                    StudentFields.addStuduent(methods);
                }
                else if (inp == "2")
                {
                    //find
                    methods.find(totstu, currstuind);


                }
                else if (inp == "3")
                {
                    // delete
                    //methods.delete(totstu, currstuind);
                    Console.Write("Please input the name of the student exactly to delete them:  ");
                    string inpu = Convert.ToString(Console.ReadLine());
                    bool found = false;

                    for (int i = 0; i < totstu; i++)
                    {
                        if (methods.namelist[i] == inpu)
                        {
                            if (found == false)
                            {
                                found = true;
                                currstuind = i;
                                Console.WriteLine("{0} has been removed from the class", methods.classlist[currstuind].name);
                                totstu--;
                                methods.classlist.RemoveAt(currstuind);
                                methods.namelist.RemoveAt(currstuind);
                                methods.classavg.RemoveAt(currstuind);
                            }
                        }                       
                    }
                    
                }
                else if (inp == "4")
                {
                    //calc avg
                    methods.calcavg(totstu);
                    
                }
                else if (inp == "5")
                {
                    //display class list
                    methods.displayclass(totstu);
                }        
                else if(inp == "6")
                {
                    // honor roles
                    methods.honor(totstu);
                    
                }
                else
                {
                    menuloop = false;
                }
            } while (menuloop == true);

        }
    }
    
}