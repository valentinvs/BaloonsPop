﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaloonsPop;

namespace Demo
{
    class Demo
    {
        static void Main(string[] args)
        {
            GameField gameField = new GameField();
            ConsolePrinter.PrintGameField(gameField.BalloonsMatrix);
        }
    }
}
