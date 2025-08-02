// 代码生成时间: 2025-08-02 23:09:02
 * The class handles formatting responses into a predefined structure,
 * which includes a status code, message, and data payload.
 * This tool is intended to be used with the MAUI framework for mobile applications.
 */
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.Maui.Controls;

namespace MauiApp.ApiFormatter
{
    public class ApiResponseFormatter
    {
        /// <summary>
        /// Formats a successful API response.
        /// </summary>
        /// <param name="data">The data to be included in the response.</param>
        /// <returns>A formatted API response.</returns>
        public static Dictionary<string, object> FormatSuccessResponse(object data)
        {
            return new Dictionary<string, object>
            {
                {"status", "success"},
                {"message", "Request processed successfully."},
                {"data", data}
            };
        }

        /// <summary>
        /// Formats an API response with an error.
        /// </summary>
        /// <param name="message">The error message to be included in the response.</param>
        /// <returns>A formatted API error response.</returns>
        public static Dictionary<string, object> FormatErrorResponse(string message)
        {
            return new Dictionary<string, object>
            {
                {"status", "error"},
                {"message", message}
            };
        }

        /// <summary>
        /// Serializes the formatted response into a JSON string.
        /// </summary>
        /// <param name="response">The formatted response to be serialized.</param>
        /// <returns>A JSON string representation of the response.</returns>
        public static string SerializeResponse(Dictionary<string, object> response)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                // Log the exception and return a formatted error response
                // Here you would use a logging framework or service
                // For simplicity, we are just returning the error message as a string
                return $"{{"status": "error", "message": "Error serializing response: {ex.Message}"}}";
            }
        }
    }
}
