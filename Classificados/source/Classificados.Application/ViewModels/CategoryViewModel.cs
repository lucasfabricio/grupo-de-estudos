using System;
using System.ComponentModel;
using Classificados.Domain.Configs;
using System.ComponentModel.DataAnnotations;

namespace Classificados.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(CategoryConfig.NAME_MIN_LENGTH)]
        [MaxLength(CategoryConfig.NAME_MAX_LENGTH)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Categoria pai")]
        public Guid? ParentCategoryId { get; set; }
    }
}
