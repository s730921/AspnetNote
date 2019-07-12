using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        /// 게시물 번호
        /// </summary>
        [Key]   // PK 설정
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required]  // NOT NULL
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]  // NOT NULL
        public string NoteContents { get; set; }

        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]  // NOT NULL
        public int UserNo { get; set; }

        /// <summary>
        /// 테이블 조인
        /// </summary>
        [ForeignKey("UserNo")]  // 외래키 설정
        public virtual User User { get; set; }
    }
}
