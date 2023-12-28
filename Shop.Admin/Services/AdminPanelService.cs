using Shop.DataModels.CustomModels;
using Shop.Logic.Services;
using System.Net.Http.Json;

namespace Shop.Admin.Services
{
    //testing code for commit related gitHub issues 
    public class AdminPanelService : IAdminPanelService
    {
        private readonly HttpClient _httpClient;
        public AdminPanelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        AdminService adminService = new AdminService();
        public async Task<ResponseModel> AdminLogin(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/admin/AdminLogin", loginModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseModel>();
            }
            else
            {
                // Handle error response here
                return adminService.AdminLogin(loginModel);
            }
        }
    }
}
