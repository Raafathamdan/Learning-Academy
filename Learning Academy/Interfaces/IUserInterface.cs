using Learning_Academy.DTO.User;

namespace Learning_Academy.Interfaces
{
    public interface IUserInterface
    {
        Task Login(LoginDTO dto);
        Task Logout(int UserId);

    }
}
