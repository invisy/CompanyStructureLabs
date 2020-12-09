using Company.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Other
{
    public class BuildCompany
    {
        public static ICompany BuildStructure(string path)
        {
            return LoadSave.Load(path);
        }

    }
}
