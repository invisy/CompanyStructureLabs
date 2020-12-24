using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TRPZ.Interfaces;
using TRPZ.Other;

namespace TRPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoadSave loader = new LoadSave();
            CLI cli = new CLI(loader);
            cli.Main();
        }
    }
}