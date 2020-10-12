﻿using Dominio;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static Agencia laAgencia = new Agencia();
        static void Main(string[] args)
        {
            bool leave = false;
            int option = 0;
            while (!leave)
            {
                ShowMenu();
            }
        }

        private static void ShowMenu()
        {
            ShowTitle("Menu");
            
        }
        private static void ShowTitle(string title)
        {
            string line = "*************************";
            Console.WriteLine();
            Console.WriteLine(line);
            Console.WriteLine(line);
            Console.WriteLine(title);
            Console.WriteLine(line);
            Console.WriteLine(line);
        }
    }
}