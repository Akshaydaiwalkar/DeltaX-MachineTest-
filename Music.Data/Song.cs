//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Music.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfRelease { get; set; }
        public string Image { get; set; }
        public Nullable<int> ArtistId { get; set; }
    }
}
