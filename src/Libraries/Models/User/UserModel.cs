using TDDNet6.Models.UserModel;

namespace TDDNet6.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
    }
}
