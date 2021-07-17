using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectPhase_1_SDA
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                var Path = @"C:\Users\Haneen\source\repos\ProjectPhase(1)SDA\file1.txt";  
          //creat list of teacher class objects & list of string
                List<Teacher> teachers = new List<Teacher>();
                List<string> dataL = new List<string>();
          //read all lines from the file in put them in list of string 
                dataL = File.ReadAllLines(Path).ToList(); 
          //creat object from class proessT(this class contains all the methods that can be executed on the data)           
                ProcessT NewP = new ProcessT();
          
                Console.WriteLine("Welcome To Rainbow School System \n   <<<< Teacher Data >>>>");
                Console.WriteLine("The Process you can do are: \n * To display all exising data, Enter 1" +
                    " \n * To add new data, Enter 2 \n * To delete data, Enter 3 \n * To search by ID, Enter 4 \n * To update data, Enter 5");
                string r = "yes";
          //do-whlie to execut more than one operation if the user wants
                do
                {

                    read(dataL, teachers);
                    Console.WriteLine("\n Enter the number of your selected process:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            NewP.DisplayAll(teachers);
                            break;
                        case 2:
                            NewP.Addnew(dataL, Path, teachers);
                            break;
                        case 3:
                            NewP.DeleteById(Path, dataL, teachers);
                            break;
                        case 4:
                            NewP.SearchById(teachers);
                            break;
                        case 5:
                            NewP.Update(dataL, Path);
                            break;
                        default:
                            Console.WriteLine("\n < The number entered is incorrect >");
                            break;
                    }//END SWITCH
                    Console.WriteLine("\n Do you want to do another process ? (Enter yes or no)");
                    r = Console.ReadLine();
                } while (r.Equals("yes"));
                if (r.Equals("no"))
                {
                    Console.WriteLine(" --------------\n   Thank You");
                }
                else
                {
                    Console.WriteLine(" --------------\n < The Entry is incorrect > \n      Thank You");
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            }
      
     // this method to read each string line and put it in new object teacher   
        public static void read(List<string> dataL , List<Teacher> teachers)
        {
            teachers.Clear();
            foreach (string l in dataL)
            {
                string[] values = l.Split('-');
                Teacher newT = new Teacher();
                newT.ID = Convert.ToInt32(values[0]);
                newT.Name = values[1];
                newT.Class = values[2];
                newT.Section = values[3];
                teachers.Add(newT);
            }
        }//END METHODE read 
    }
}
