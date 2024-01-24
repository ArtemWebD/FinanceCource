using Finance.models;

namespace Finance.dto
{
    public class ClientLoginDto
    {
        public string name { get; set; }
        public int id { get; set; }

        public ClientLoginDto(User user)
        {
            name = user.name;
            id = user.id;
        }
    }
}
