using Mango.Web.DTOS;
using Mango.Web.Interfaces.Services;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Services
{
	public class BaseService(IHttpClientFactory httpClientFactory) : IBaseService
	{
		// Handle any HTTP request
		public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
		{
			if (requestDto == null || string.IsNullOrEmpty(requestDto.Url))
			{
				return new() { IsSuccess = false, Message = "Invalid Request" };
			}

			HttpClient client = httpClientFactory.CreateClient("MangoAPI");

			HttpRequestMessage message = new();
			message.Headers.Add("Accept", "application/json");
			message.RequestUri = new Uri(requestDto.Url);

			if (requestDto.Data != null)
			{
				message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
			}

			HttpResponseMessage? apiResponse = null;

			switch (requestDto.ApiType)
			{
				case ApiType.POST:
					message.Method = HttpMethod.Post;
					break;
				case ApiType.DELETE:
					message.Method = HttpMethod.Delete;
					break;
				case ApiType.PUT:
					message.Method = HttpMethod.Put;
					break;
				default:
					message.Method = HttpMethod.Get;
					break;
			}

			try
			{
				apiResponse = await client.SendAsync(message);
				var apiContent = await apiResponse.Content.ReadAsStringAsync();

				if (apiResponse.IsSuccessStatusCode)
				{
					// Check the type of response required (either list or single coupon)
					  if (Regex.IsMatch(requestDto.Url, @"/\d+$"))
					{
					
						// Assuming the request is to fetch a single coupon
						var coupon = JsonConvert.DeserializeObject<CouponDto>(apiContent);
						return new ResponseDto
						{
							IsSuccess = true,
							Message = "Coupon retrieved successfully.",
							Result = coupon
						};
					}
					else
					{
						// Assuming the request is to fetch a list of coupons
						var couponList = JsonConvert.DeserializeObject<List<CouponDto>>(apiContent);
						return new ResponseDto
						{
							IsSuccess = true,
							Message = "Coupons retrieved successfully.",
							Result = couponList
						};
					}
				}
				else
				{
					return new ResponseDto
					{
						IsSuccess = false,
						Message = $"Error: {apiResponse.StatusCode}, Content: {apiContent}"
					};
				}
			}
			catch (Exception ex)
			{
				// Log the exception (ex) for further analysis
				return new ResponseDto
				{
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}
