using BusTCC.Application.DTOs;

namespace BusTCC.API.Models
{
    public class UserToken
    {
        public UsuarioDTO User { get; set; }
        public string Token { get; set; }
    }
}
