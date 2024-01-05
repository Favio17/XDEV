using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using XDEV_001_FRONT.Models;

namespace XDEV_001_FRONT.Utils
{
    public interface apiInterface
    {
        Task<List<ProductoViewModel>> GetProductos();

    }

    public class Helper : apiInterface
    {
        public string accessToken = string.Empty;
        private readonly HttpClient cliente;

        public Helper(HttpClient _cliente)
        {
            cliente = _cliente;
            cliente.BaseAddress = new Uri("https://localhost:7210/");
        }

        public async Task<List<ProductoViewModel>> GetProductos()
        {

            await GetToken();
            List<ProductoViewModel> lstProductos = new List<ProductoViewModel>();
            
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var apiUrl = "GetAllProducts";
                try
                {
                    var response = await cliente.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var productos = JsonConvert.DeserializeObject<List<ProductoViewModel>>(responseData);
                        lstProductos = productos;
                    }
                    else
                    {
                        // Manejar el caso en el que la autenticación falla
                        Console.WriteLine("Credenciales inválidas");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }


            
            return lstProductos;
        }

        public async Task GetToken()
        {
            LoginViewModel model = new LoginViewModel();    
            TokenModel token = new TokenModel();
            var apiUrl = "PostLoginDetails";

                //Para motivos de práctica. Aquí se podría incorporar el módulo del login. 
                model.EmailId = "favio@gmail.com";
                model.Password = "root";
                model.FullName = "Test Name";
                model.UserMessage = "UserMessage";
                model.ID = 0;
                model.Designation = "Engineer";
                model.AccessToken = "";

                string json = JsonConvert.SerializeObject(model);

                try
                {
                    var response = await cliente.PostAsync(apiUrl, JsonContent.Create(model));

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var tokenAux = JsonConvert.DeserializeObject<TokenModel>(responseData);
                        accessToken = tokenAux.AccessToken;
                    }
                    else
                    {
                        // Manejar el caso en el que la autenticación falla
                        Console.WriteLine("Credenciales inválidas");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }


            
        }

    }
}
