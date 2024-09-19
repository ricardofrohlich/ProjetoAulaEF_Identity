using Microsoft.AspNetCore.Identity;

namespace ProjetoAulaEF_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
