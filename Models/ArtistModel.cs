using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Music.Data;

namespace Music.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public System.DateTime DOB { get; set; }
        public string dateofbirth { get; set; }
        public string Bio { get; set; }
        public int SongId { get; set; }

        public string SaveArtist(ArtistModel model)
        {
            string message = "Registration Successfully";
            MusicDeltaXEntities db = new MusicDeltaXEntities();
            var saveart = new Artist()
            {
                Name = model.Name,
                DOB = model.DOB,
                Bio = model.Bio,
                SongId = model.SongId,
            };
            db.Artists.Add(saveart);
            db.SaveChanges();
            return message;
        }

        public List<ArtistModel> GetArtistList()
        {
            MusicDeltaXEntities db = new MusicDeltaXEntities();
            List<ArtistModel> str = new List<ArtistModel>();
            var artlist = db.Artists.ToList();
            if (artlist != null)
            {
                foreach (var reg in artlist)
                {
                    str.Add(new ArtistModel()
                    {
                        ArtistId = reg.ArtistId,
                        Name = reg.Name,
                        dateofbirth = reg.DOB.ToString("MM/dd/yyyy"),
                        Bio = reg.Bio,
                        SongId = reg.SongId,

                    });
                }
            }
            return str;
        }

        public List<ArtistModel> GetArtDDLList()
        {
            MusicDeltaXEntities db = new MusicDeltaXEntities();
            List<ArtistModel> lstartlistdata = new List<ArtistModel>();
            var datalist = db.Artists.ToList();
            if (datalist != null)
            {
                foreach (var data in datalist)
                {
                    lstartlistdata.Add(new ArtistModel()
                    {
                        ArtistId = data.ArtistId,
                        Name = data.Name,
                    });
                }
            }
            return lstartlistdata;
        }
    }
}