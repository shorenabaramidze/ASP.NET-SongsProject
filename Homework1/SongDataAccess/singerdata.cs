//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SongDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    //[DataContract]
    public partial class singerdata
    {
        //[DataMember]
        public int ID { get; set; }
        //[DataMember]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string sex { get; set; }
        public string country { get; set; }
        public string genre { get; set; }
    }
}
