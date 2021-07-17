using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ProjectPhase_1_SDA
{
    class ProcessT
    {
       // this method to retrieve  all data in teachers list and display on screen 
        public void DisplayAll(List<Teacher> teachers)
        {
            foreach (Teacher l in teachers)
            {
                
                Console.WriteLine($"ID:{l.ID} - Name:{l.Name} - Class:{l.Class} - Section:{l.Section}");
            }
        }//END METHODE display all


      // this method to add new data, before adding check if the entered Id exists in the list or not 
        public  void Addnew(List<string> dataL , string Path , List<Teacher> teachers)
        {
            int id;
            Boolean b;
            do
            {
                 b = true;
                Console.WriteLine("Ener the new ID:");
                 id = Convert.ToInt32(Console.ReadLine());
                foreach (var l in teachers)
                {
                    if (l.ID == id)
                    {
                        b = false;
                        Console.WriteLine("\n < this ID exists > ");
                        break;
                    }
                }
            } while (b == false);
            Console.WriteLine("Ener the Name:");
            string n = Console.ReadLine();
            Console.WriteLine("Ener the class:");
            string c = Console.ReadLine();
            Console.WriteLine("Ener the section:");
            string s = Console.ReadLine();
            dataL.Add($"{id} - {n} - {c} - {s}");
            File.WriteAllLines(Path, dataL);
            Console.WriteLine("\n < Added successfully >");

        }//END METHODE Add new

       
      // search by ID in the list, if it exists return all data about it
        public  void SearchById(List<Teacher> teachers)
        {
            Boolean b = false;
                Console.WriteLine("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (var l in teachers)
            {
                    if(l.ID == id)
                    {
                    b = true;
                        Console.WriteLine($"ID:{l.ID} - Name:{l.Name} - Class:{l.Class} - Section:{l.Section}");
                        break;
                    }  
            }
                if(b == false)
            {
                Console.WriteLine("\n < This ID not fouund >");
            }
        }//END METHODE search by Id


      // search by ID in the list, if it exists remove all data about it from the list and file
        public void DeleteById(string Path , List<string> dataL , List<Teacher> teachers)
        {
            Boolean b = false;
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var l in teachers)
            {
                
                if (l.ID == id)
                {
                    b = true;
                    dataL.RemoveAt(teachers.IndexOf(l));
                    teachers.Remove(l);
                    
                    Console.WriteLine("\n < Removed successfully > ");
                    break;
                }
            }
            File.WriteAllLines(Path, dataL);

            if (b == false)
            {
                Console.WriteLine("\n < This ID not fouund >");
            }
        }//END METHODE search by Id


        // search by ID in the list, if it exists modify existing  data with new data
        public void Update (List<string> dataL , string Path)
        {
            Boolean b = false;
            Console.WriteLine("Enter id:");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var l in dataL)
            {
                string[] values = l.Split('-');
                int v1 = Convert.ToInt32(values[0]);
                if (v1 == id)
                {
                    b = true;
                    Console.WriteLine($"ID:{values[0]} - Name:{values[1]} - Class:{values[2]} - Section:{values[3]}");
                    Console.WriteLine("Enter the new data about this person:");
                    Console.WriteLine("ID:");
                    values[0] = Console.ReadLine();
                    Console.WriteLine("Name:");
                    values[1] = Console.ReadLine();
                    Console.WriteLine("Class:");
                    values[2] = Console.ReadLine();
                    Console.WriteLine("Section:");
                    values[3] = Console.ReadLine();
                    var x = dataL.IndexOf(l);
                    string v = $"{values[0]} - {values[1]} - {values[2]} - {values[3]}";
                    dataL[x] = v;
                    Console.WriteLine("\n < Update successfully >");
                    break;
                }
            }
           
            if (b == true)
            {
                File.WriteAllLines(Path, dataL);
            }
           else {
                Console.WriteLine("\n < This ID not fouund >");
            }
        }//END METHODE search by Id
    }
}
