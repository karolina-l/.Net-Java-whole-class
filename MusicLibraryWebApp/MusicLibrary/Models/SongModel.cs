using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicLibrary.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please provide the title")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please provide the author")]
        public string Author { get; set; }

        [Display(Name = "Album")]
        [Required(ErrorMessage = "Please provide the album")]
        public string Album { get; set; }

        [Display(Name = "Link to the album cover")]
        [Required(ErrorMessage = "Please provide the link to the album cover")]
        public string CoverLink { get; set; }
    }
}