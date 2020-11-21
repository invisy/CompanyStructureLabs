using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TRPZ
{
    [DataContract]
    public class Worker : Employee,ICommandable
    {
          

    }
}