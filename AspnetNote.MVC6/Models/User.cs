using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        [Key]   // PK 설정
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required]  // NOT NULL 설정
        public string UserName { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required]  // NOT NULL 설정
        public string UserID { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required]  // NOT NULL 설정
        public string UserPassword { get; set; }
    }
}
