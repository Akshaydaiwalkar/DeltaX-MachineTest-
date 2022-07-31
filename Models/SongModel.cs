using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Music.Data;

namespace Music.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfRelease { get; set; }
        public string DOR { get; set; }
        public string Image { get; set; }
        public Nullable<int> ArtistId { get; set; }

        public string SaveSong(HttpPostedFileBase fb, SongModel model)
        {
            string message = "Registration Successfully";
            MusicDeltaXEntities db = new MusicDeltaXEntities();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("~/Content/img/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/img/") + "/" + sysFileName;
                }
            }
            //SongModel model = new SongModel();
            var savesong = new Song()
            {
                Name = model.Name,
                DateOfRelease = model.DateOfRelease,
                Image = sysFileName,
                ArtistId = model.ArtistId,

            };
            db.Songs.Add(savesong);
            db.SaveChanges();
            return message;
        }

        public List<SongModel> GetSongList()
        {
            MusicDeltaXEntities db = new MusicDeltaXEntities();
            List<SongModel> str = new List<SongModel>();
            var songlist = db.Songs.ToList();
            if (songlist != null)
            {
                foreach (var reg in songlist)
                {
                    str.Add(new SongModel()
                    {
                        SongId = reg.SongId,
                        Name = reg.Name,
                        DOR = reg.DateOfRelease.ToString("MM/dd/yyyy"),
                        Image = reg.Image,
                        ArtistId = reg.ArtistId,

                    });
                }
            }
            return str;
        }


    }
}