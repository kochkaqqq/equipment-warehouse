
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace Presentation.Utils.ApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly ToastService _toastService = null!;

        public ApiClient(IHttpClientFactory httpClientFactory, ToastService toastService)
        {
            _httpClientFactory = httpClientFactory;
            _toastService = toastService;
        }

        public async Task<Guid> CreateEntityAsync(string url, JsonContent content)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var res = await httpClient.PostAsync(url, content);

            if (!res.IsSuccessStatusCode)
            {
                HandleErrorResponse(res);
                return default!;
            }

            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Guid>(json);
        }

        public async Task<bool> DeleteAsync(string url, Guid guid)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var res = await httpClient.DeleteAsync($"{url}/{guid}");

            if (!res.IsSuccessStatusCode)
            {
                HandleErrorResponse(res);
                return false;
            }
            else
            {
                _toastService.Notify(new(ToastType.Success, "Успешно удалено."));
                return true;
            }
        }

        public async Task<T> GetAsync<T>(string url, Guid? id = null)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var res = await httpClient.GetAsync(id.HasValue ? $"{url}/{id}" : url);

            if (!res.IsSuccessStatusCode)
            {
                HandleErrorResponse(res);
                return default!;
            }

            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? throw new NotImplementedException(); //TODO обработать ошибку получения некорректных данных
        }

        public async Task<T> PostAsync<T>(string url, JsonContent content) where T : class
        {
            var httpClient = _httpClientFactory.CreateClient();

            var res = await httpClient.PostAsync(url, content);

            if (!res.IsSuccessStatusCode)
            {
                HandleErrorResponse(res);
                return default!;
            }

            var json = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? throw new NotImplementedException(); //TODO обработать ошибку получения некорректных данных
        }

        public async Task<bool> PutAsync(string url, JsonContent content)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var res = await httpClient.PutAsync(url, content);

            if (!res.IsSuccessStatusCode)
            {
                HandleErrorResponse(res);
                return false;
            }
            else
            {
                _toastService.Notify(new(ToastType.Success, "Успешно обновлено."));
                return true;
            }
        }

        private void HandleErrorResponse(HttpResponseMessage res)
        {
            if (res.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                _toastService.Notify(new(ToastType.Warning, "Введены некорректные данные."));
                return;
            }
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _toastService.Notify(new(ToastType.Warning, "Ошибка. Сущность не найдена."));
                return;
            }
            if (res.StatusCode == System.Net.HttpStatusCode.NotImplemented)
            {
                _toastService.Notify(new(ToastType.Warning, "Ошибка. Данная функциональность еще не реализована."));
                return;
            }
            _toastService.Notify(new(ToastType.Warning, "Произошла ошибка на сервере. Обратитесь к админу."));
        }
    }
}
