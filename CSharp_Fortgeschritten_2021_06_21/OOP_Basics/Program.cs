﻿using System;

namespace OOP_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            SchiffWithEngine schiffWithEngine = new SchiffWithEngine(2, 1998, "Blub Blub", 12, 18, false, MotorizedTyp.Diesel);
            


            //MyProgramm myProgramm = new MyProgramm();
            //myProgramm.Main();


            Console.ReadKey();
        }
    }
}
