using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WorkersDB
{
    class Program
    {
        static List<WorkerClass> workers = new List<WorkerClass>();
        static void Main(string[] args)
        {
            LoadFromFile();

            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Új dolgozó felvétele");
                Console.WriteLine("2. Mentés fájlba");
                Console.WriteLine("3. Betöltés fájlból");
                Console.WriteLine("4. Kirás képernyőre");
                Console.WriteLine("5. kiírás HTML-be");
                Console.WriteLine("6. Kilépés");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        AddWorker();
                        break;
                    case '2':
                        SaveToFile();
                        break;
                    case '3':
                        LoadFromFile();
                        break;
                    case '4':
                        PrintToScreen();
                        break;
                    case '5':
                        PrintToHTML();
                        break;
                    case '6':
                        SaveToFile();
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (!exit); //exit == false ugyanaz
        }

        static void AddWorker()
        {
            string name;
            int age;
            string gender;

            Console.Clear();
            Console.Write("Kérem a dolgozó nevét: ");
            name = Console.ReadLine();
            Console.Write("Kérem a dolgozó életkorát: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kérem a dolgozó nemét (Férfi/Nő): ");
            gender = Console.ReadLine();

            //WorkerClass worker = new WorkerClass(name, age, gender);
            //Workers.add(name);                                        ugyanaz

            workers.Add(new WorkerClass(name, age, gender));
        }

        static void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(@"h:\workers.db", false);

            foreach (WorkerClass worker in workers)
            {
                writer.WriteLine($"{worker.GetDataString()}");
            }

            writer.Close();
        }

        static void LoadFromFile()
        {
            workers.Clear();

            StreamReader reader = new StreamReader(@"h:\workers.db");

            string sor;

            while (!reader.EndOfStream)
            {
                sor = reader.ReadLine();

                string[] adatok = sor.Split(';');

                //WorkerClass worker = new WorkerClass(adatok[0], Convert.ToInt32(adatok[1]), adatok[2]);
                //workers.Add(worker);                                                                      ugyanaz

                workers.Add(new WorkerClass(adatok[0], Convert.ToInt32(adatok[1]), adatok[2]));
            }

            reader.Close();
        }

        static void PrintToScreen()
        {
            Console.Clear();

            foreach (WorkerClass worker in workers)
            {
                Console.WriteLine(worker.Name.PadRight(20) + worker.Age.ToString().PadRight(3) + worker.Gender);
            }

            Console.ReadKey();
        }

        static void PrintToHTML()
        {
            StreamWriter writer = new StreamWriter(@"h:\workers.html");

            writer.WriteLine("<table border = '1'>");


            writer.WriteLine("<tbody>");


            writer.WriteLine("<tr>");


            writer.WriteLine("<th>");
            writer.WriteLine("Név");
            writer.WriteLine("</th>");

            writer.WriteLine("<th>");
            writer.WriteLine("Kor");
            writer.WriteLine("</th>");

            writer.WriteLine("<th>");
            writer.WriteLine("Nem");
            writer.WriteLine("</th>");


            writer.WriteLine("</tr>");

            foreach (WorkerClass worker in workers)
            {
                writer.WriteLine("<tr>");

                writer.WriteLine("<td>");
                writer.WriteLine(worker.Name);
                writer.WriteLine("</td>");

                writer.WriteLine("<td>");
                writer.WriteLine(worker.Age);
                writer.WriteLine("</td>");

                writer.WriteLine("<td>");
                writer.WriteLine(worker.Gender);
                writer.WriteLine("</td>");
                

                writer.WriteLine("</tr>");
            }


            writer.WriteLine("</tbody>");


            writer.WriteLine("</table");

            writer.Close();

            Process process = new Process();
            process.StartInfo.FileName = "chrome.exe";
            process.StartInfo.Arguments = @"h:\workers.html";
            process.Start();

        }
    }
}
