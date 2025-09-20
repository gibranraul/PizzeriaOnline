using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace PizzeriaOnline
{
    class Menu
    {
        private string[] Options;
            private int SelectedIndex;
            private string Prompt = "";

            public Menu(string prompt, string[] options)
            {
                Prompt = prompt;
                Options = options;
                SelectedIndex = 0;
            }

            private void MostrarOpciones()
            {
                Console.WriteLine(Prompt);
                for (int i = 0; i < Options.Length; i++)
                {
                    string currentOption = Options[i];
                    string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                    Console.WriteLine($"{prefix}<< {currentOption} >>");

                }
            Console.ResetColor();
            }
        public int Correr()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Program.MostrarLogo();
                MostrarOpciones();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                //Actualiza el indice seleccionado basado en las flechas del teclado.
                if(keyPressed == ConsoleKey.UpArrow)
                {
                    
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                        SelectedIndex++;
                } else if (keyPressed == ConsoleKey.DownArrow)
                {
                        SelectedIndex++;
                    if (SelectedIndex > Options.Length-1)
                        SelectedIndex--;
                }
            }while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }

        
    }
}
