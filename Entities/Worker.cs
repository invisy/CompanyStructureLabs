using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TRPZ
{
    [DataContract]
    public class Worker : Employee,ICommandable
    {
        [JsonIgnore]
        public ICommander SuperVisor { get; set; }  

        public void AddCommander(ICommander superVisor)
        {
            if (SuperVisor is null)
            {
                SuperVisor = superVisor;
            }
        }
    }
}