using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Environment;

namespace DMCore.Models
{
    public class Deal
    {
        public Deal()
        {

        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Deal Title")]
        public string Title { get; set; }

        public string Instructions { get; set; }
        public IEnumerable<string> InstructionsList
        {
            get { return (Instructions ?? string.Empty).Split(NewLine); }
        }
        [Display(Name = "Deal URL")]
        public string URL { get; set; }

        public string Price { get; set; }
        public bool IsCoupon { get; set; }
        public string CouponCode { get; set; }

        public string ImageURL { get; set; }

        #region Image

        //public byte[] Image { get; set; }

        //public string ImageContentType { get; set; }

        //public string GetInlineImageSrc()
        //{
        //    if (Image == null || ImageContentType == null)
        //        return null;

        //    var base64Image = System.Convert.ToBase64String(Image);
        //    return $"data:{ImageContentType};base64,{base64Image}";
        //}

        //public void SetImage(Microsoft.AspNetCore.Http.IFormFile file)
        //{
        //    if (file == null)
        //        return;

        //    ImageContentType = file.ContentType;

        //    using (var stream = new System.IO.MemoryStream())
        //    {
        //        file.CopyTo(stream);
        //        Image = stream.ToArray();
        //    }
        //}

        #endregion
        public bool DMProduct { get; set; }

        public DateTime StartTS { get; set; }
        public DateTime EndTS { get; set; }
        public string Status { get; set; }

        public int Views { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTS { get; set; }

        public DealStore DealStore { get; set; }
        public int? DealStoreId { get; set; }
        public DealCategory DealCategory { get; set; }
        public int? DealCategoryId { get; set; }

        public DealTag DealTag { get; set; }
        public int DealTagId { get; set; }

    }
}
