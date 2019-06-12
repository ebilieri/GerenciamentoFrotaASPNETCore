using Frota.Application.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frota.Application.ViewModels
{
    public class VeiculoModel
    {
        public int ID { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "Informe o Chassi com 17 caractres.")]
        [Required(ErrorMessage = "Campo chassi obrigatório.")]
        public string Chassi { get; set; }

        [Display(Name = "Tipo de Veículo")]
        [Range(1, 255, ErrorMessage = "Campo tipo de veículo obrigatório.")]
        public TipoVeiculo Tipo { get; set; }

        [Display(Name = "Número de Passageiros")]
        public byte NumeroPassageiro { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Campo cor obrigatório.")]
        public string Cor { get; set; }

        private List<string> _mensagemValidacao { get; set; }
        public List<string> MensagemValidacao
        {
            get { return _mensagemValidacao ?? (_mensagemValidacao = new List<string>()); }
        }
    }
}
