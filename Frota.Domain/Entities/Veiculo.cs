namespace Frota.Domain.Entities
{
    public class Veiculo : EntityBase
    {
        public int Id { get; set; }
        public string Chassi { get; set; }
        public byte Tipo { get; set; }
        public byte NumeroPassageiro { get; set; }
        public string Cor { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (string.IsNullOrEmpty(Chassi))
                AdicionarMensagem("Chassi é de preenchimento Obrigatorio");
            
        }
    }
}
