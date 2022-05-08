using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class SongProcessor
    {
        public static int CreateSong(string title, string author,
            string album, string coverLink)
        {
            SongModel data = new SongModel
            {
                Title = title,
                Author = author,
                Album = album,
                CoverLink = coverLink
            };

            string sql = @"insert into dbo.SongTable (Title, Author, Album, CoverLink)
                            values(@Title, @Author, @Album, @CoverLink);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SongModel> LoadSongs()
        {
            string sql = @"select Id, Title, Author, Album, CoverLink
                            from dbo.SongTable;";
            return SqlDataAccess.LoadData<SongModel>(sql);
        }
    }
}
