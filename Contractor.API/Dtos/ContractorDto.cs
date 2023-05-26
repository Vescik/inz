namespace Contractor.API.Dtos
{
    public class ContractorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nip { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public static implicit operator ContractorDto(ContractorDto v)
        {
            throw new NotImplementedException();
        }
    }
}
