using Microsoft.JSInterop;
using EventEase.Models;
using System.Text.Json;

namespace EventEase.Services
{
    public class UserSessionService
    {
        private const string StorageKey = "EventEase_UserSession";
        private readonly IJSRuntime _js;
        public Registration? CurrentUser { get; private set; }

        public UserSessionService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task LoadAsync()
        {
            try
            {
                var json = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);
                if (!string.IsNullOrEmpty(json))
                {
                    CurrentUser = JsonSerializer.Deserialize<Registration>(json);
                }
            }
            catch { /* ignore */ }
        }

        public async Task SaveAsync(Registration reg)
        {
            CurrentUser = reg;
            var json = JsonSerializer.Serialize(reg);
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }

        public async Task ClearAsync()
        {
            CurrentUser = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);
        }
    }
}