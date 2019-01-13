using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System;

namespace DataLayer
{
    public class Product_GroupMetaData
    {
        [Key]
        public int GroupId { get; set; }
        [DisplayName("عنوان منو")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string GroupTitle { get; set; }
        public Nullable<int> ParentId { get; set; }
    }
}