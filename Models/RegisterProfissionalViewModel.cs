using System.ComponentModel.DataAnnotations;

namespace Projeto1_Web2_IF_johnnata.Models
{
    public class RegisterProfissionalViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não correspondem.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de profissional é obrigatório")]
        [Display(Name = "Tipo de Profissional")]
        public string TipoProfissional { get; set; } = string.Empty; // "Medico" ou "Nutricionista"

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(15)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "CRM/CRN")]
        public string? CrmCrn { get; set; }

        [StringLength(100)]
        [Display(Name = "Especialidade")]
        public string? Especialidade { get; set; }

        [StringLength(100)]
        [Display(Name = "Logradouro")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        [StringLength(10)]
        [Display(Name = "Número")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [StringLength(10)]
        [Display(Name = "CEP")]
        public string Cep { get; set; } = string.Empty;

        [StringLength(2)]
        [Display(Name = "DDD")]
        public string? Ddd1 { get; set; }

        [StringLength(25)]
        [Display(Name = "Telefone")]
        public string? Telefone1 { get; set; }

        [StringLength(2)]
        [Display(Name = "DDD 2")]
        public string? Ddd2 { get; set; }

        [StringLength(25)]
        [Display(Name = "Telefone 2")]
        public string? Telefone2 { get; set; }

        [Display(Name = "ID Cidade")]
        public int IdCidade { get; set; }

        [Display(Name = "ID Estado")]
        public int? IdEstado { get; set; }

        [Display(Name = "ID Contrato")]
        public int IdContrato { get; set; }
    }
}
