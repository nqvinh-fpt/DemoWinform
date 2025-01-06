using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReantSim
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnShowNetword_Click(object sender, EventArgs e)
        {
            string TokenAPI = txtTokenAPI.Text.Trim();
            if (string.IsNullOrEmpty(TokenAPI))
            {
                MessageBox.Show("Vui lòng nhập API Token.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string url = $"https://ironsim.com/api/network/list?token={TokenAPI}";
            try
            {
                var responseData = await GetApiData(url);

                if (responseData.Success)
                {
                    dgvListNetwork.DataSource = responseData.Data;
                }
                else
                {
                    MessageBox.Show($"API trả về lỗi: {responseData.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task<ApiResponse> GetApiData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });


                    return responseData;
                }
                else
                {
                    throw new Exception($"Lỗi HTTP: {response.StatusCode}");
                }
            }
        }
        private async Task<T> GetApiData<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var responseData = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return responseData;
                }
                else
                {
                    throw new Exception($"Lỗi HTTP: {response.StatusCode}");
                }
            }
        }


        private async void btnBuySim_Click(object sender, EventArgs e)
        {
            try
            {
                string TokenAPI = txtTokenAPI.Text.Trim();
                if (string.IsNullOrEmpty(TokenAPI))
                {
                    MessageBox.Show("Vui lòng nhập API Token.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvListNetwork.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một dòng trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvListNetwork.SelectedRows[0];
                int selectedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                string buySimUrl = $"https://ironsim.com/api/phone/new-session?token={TokenAPI}&service={selectedId}";
                var buySimResponse = await GetApiData<BuySimResponse>(buySimUrl);

                if (buySimResponse.Success)
                {
                    var session = buySimResponse.Data.Session;

                    string getOtpUrl = $"https://ironsim.com/api/session/{session}/get-otp?token={TokenAPI}";
                    var otpResponse = await GetApiData<OtpResponse>(getOtpUrl);

                    if (otpResponse.Success)
                    {
                        var otpData = otpResponse.Data;

                        MessageBox.Show(
                            $"Mua thành công!\n\nSố điện thoại: 0{otpData.PhoneNumber}\nID: {otpData.Id}\nDịch vụ: {otpData.ServiceName}",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show($"Không thể lấy OTP: {otpResponse.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Không thể mua SIM: {buySimResponse.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    public class ApiResponse
    {

        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public NetworkData[] Data { get; set; }
    }


    public class NetworkData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    public class BuySimResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public BuySimData Data { get; set; }
    }

    public class BuySimData
    {
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("network")]
        public int Network { get; set; }

        [JsonPropertyName("session")]
        public string Session { get; set; }

        [JsonPropertyName("service")]
        public string Service { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("balance")]
        public int Balance { get; set; }

        [JsonPropertyName("start")]
        public string Start { get; set; }

        [JsonPropertyName("end")]
        public string End { get; set; }
    }

    public class OtpResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public OtpData Data { get; set; }
    }

    public class OtpData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("service_name")]
        public string ServiceName { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }

}
