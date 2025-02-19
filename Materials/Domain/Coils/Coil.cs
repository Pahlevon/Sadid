using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SadidServices.Materials.Shared.Primitives;

namespace SadidServices.Materials.Domain.Coils
{
    public class Coil : Entity<Guid>
    {
        public Coil():base(Guid.NewGuid()) { }
        public Coil(string serial,string melt,string owner,float ownerWeight,float sadidWeight,string type,string size,DateTime timeReceive,string description):base(Guid.NewGuid())
        {
            Serial = serial;
            Melt = melt;
            Owner = owner;
            OwnerWeight = ownerWeight;
            SadidWeight = sadidWeight;
            Type = type;
            Size = size;
            TimeReceive = timeReceive;
            Description = description;
        }
        
        public string Serial { get; set; }
        public string Melt { get; set; }
        public string Owner { get; set; }
        public float OwnerWeight { get; set; }
        public float SadidWeight { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public DateTime TimeReceive { get; set; }
        public string Description { get; set; }





    }
}