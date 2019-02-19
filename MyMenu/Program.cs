using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MyMenu
{



    class Program
    {

        public static int saveWindowHeight;
        public static int saveWindowWidth;
       
        public static int maxLenghtItem(string[] a)
        {
            string linia = "";
            foreach (var item in a)
            {
                if (item.Length > linia.Length)
                {
                    linia = item;
                }
            }
            return linia.Length;
        }
        public static void Main()
        {



            string[] TAB = { "opcja1", "opcja2", "bardzo dluga pozycja bardzo dluga pozycja ", "exit", "opcja5", "opcja" };
            int maxlenght = maxLenghtItem(TAB);
            
          
            saveWindowHeight = Console.WindowHeight;
            saveWindowWidth = Console.WindowWidth;
    
            Console.Title = "Menu";
            Console.CursorVisible = false;

            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();


            int index_item = 0;

            int console_heigiht;
            int console_weight;
            int bok1 = 0;
            int bok2 = 0;
            int gora1 = 0;
            int gora2 = 0;
            int dol_1 = 0;
            string x0 = "┌";
            string x1 = "└";
            string x2 = "┐";
            string x3 = "┘";
            string bok = "│";
           
         
      int pozycja_x =   console_weight = saveWindowWidth / 2 - maxlenght / 2;
      int pozycja_y = console_heigiht = saveWindowHeight / 2 - TAB.Length;   
      int pozycja_ramka_x = pozycja_x - 2;
      int pozycja_ramka_y = pozycja_y -2;

      do
      {
          Console.Clear();

         
          Console.SetCursorPosition(saveWindowWidth / 2 - maxlenght / 2, saveWindowHeight / 2 - TAB.Length);

          console_heigiht = saveWindowHeight / 2 - TAB.Length; ;

          for (int i = 0; i < TAB.Length +4 ; i++)
          {
              Console.SetCursorPosition(pozycja_ramka_x, pozycja_ramka_y+ i);
              if (i == 0)
              {
                  Console.WriteLine(x0);
              }
              if (i == TAB.Length + 4 -1)
              {
                  Console.WriteLine(x1);
              }
          else if( i > 0)
              Console.WriteLine(bok);
              gora1 = pozycja_ramka_x;
              gora2 = pozycja_ramka_y;
              dol_1 = pozycja_ramka_y + i;
          }
          for (int i =1; i < maxlenght + 4; i++)
          {
              Console.SetCursorPosition(gora1 + i, dol_1);
              Console.WriteLine("─");
          }

          for (int j = 1; j < maxlenght + 4 ; j++)
          {
                      Console.SetCursorPosition(gora1 + j, gora2);

                      if (j == maxlenght + 4)
                      {
                          Console.WriteLine("┘");
                      }
                      else
                      {
                          Console.Write("─");
                      }
                      bok1 = gora1+j;
                      bok2 = gora2;
                 
          }
 
          for (int i = 0; i < TAB.Length + 4; i++)
          {
              Console.SetCursorPosition(bok1, bok2 + i);
              if (i == 0)
              {
                  Console.WriteLine(x2);
              }
              if (i == TAB.Length + 4 - 1)
              {
                  Console.WriteLine(x3);
              }
              else if (i > 0)
                  Console.WriteLine(bok);
       
          }
       
         
        
           
                for (int i = 0; i < TAB.Length; i++)
                {
                    int ile = (maxlenght - TAB[i].Length);
                    Console.SetCursorPosition(console_weight + ile / 2, console_heigiht);
                  
                    if (index_item == i)
                    {

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine(TAB[i]);

                        console_heigiht += 1;
                    }
                    if (index_item != i)
                    {

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(TAB[i]);
                        console_heigiht += 1;

                    }




                }



                keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        index_item -= 1;
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (index_item < 0)
                        {
                            index_item = 0;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        index_item += 1;
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (index_item >= TAB.Length)
                        {
                            index_item = TAB.Length - 1;
                        }
                        break;
                    
                
                }
               
                if(keyinfo.Key != ConsoleKey.DownArrow && keyinfo.Key != ConsoleKey.UpArrow && keyinfo.Key != ConsoleKey.Escape)
                {

                    Console.Beep();
                for (int i = 0; i < 5; i++)
                {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.SetCursorPosition( Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
                    Console.WriteLine("Nieprawidlowy klawisz");
                    Thread.Sleep(50);

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Thread.Sleep(50);
                }

                }  

                Console.ResetColor();
           
            } while (keyinfo.Key != ConsoleKey.Escape);

          
        }


        public static ConsoleColor Theard { get; set; }
    }
}
