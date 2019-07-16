using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.ViewModels
{
    public class LoginModelView
    {
        /// <summary>
        /// 로그인용 사용자 ID
        /// </summary>
        
        [Required(ErrorMessage ="사용자 ID를 입력하세요.")]
        public string UserID { get; set; }

        /// <summary>
        /// 로그인용 비밀번호
        /// </summary>
        [Required(ErrorMessage ="비밀번호를 입력하세요.")]
        public string UserPassword { get; set; }
    }
}
