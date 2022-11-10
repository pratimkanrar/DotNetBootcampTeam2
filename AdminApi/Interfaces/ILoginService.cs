using AdminApi.Entities;

namespace AdminApi.Interfaces
{
    public interface ILoginService
    {
        string Generate(Admin admin);
        Admin Authenticate(AdminLogin adminlogin);
        void ChangePassword(AdminLogin adminlogin);
    }
}
