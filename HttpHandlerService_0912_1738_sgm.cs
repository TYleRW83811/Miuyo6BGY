// 代码生成时间: 2025-09-12 17:38:17
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System.Net;

namespace HttpHandlerService
{
    /// <summary>
    /// Http请求处理器，用于向服务器发送请求并接收响应。
    /// </summary>
    public class HttpHandlerService
    {
        private HttpClient _httpClient;

        /// <summary>
        /// 初始化HttpClient实例。
        /// </summary>
        public HttpHandlerService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 发送GET请求。
        /// </summary>
        /// <param name="url">请求的URL。</param>
        /// <returns>请求的响应内容。</returns>
        public async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // 错误处理
                Console.WriteLine($"Request failed: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// 发送POST请求。
        /// </summary>
        /// <param name="url">请求的URL。</param>
        /// <param name="content">请求内容。</param>
        /// <returns>请求的响应内容。</returns>
        public async Task<string> PostAsync(string url, HttpContent content)
        {
            try
            {
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // 错误处理
                Console.WriteLine($"Request failed: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// 释放HttpClient资源。
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
