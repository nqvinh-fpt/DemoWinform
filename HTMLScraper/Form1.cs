using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace HTMLScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnScraper_Click(object sender, EventArgs e)
        {
            txtHtml.Text = ScrapeVnExpress();
        }

        private string ScrapeVnExpress()
        {
            string result = ""; 

            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Chạy chế độ ẩn
            options.AddArgument("--disable-gpu"); // Tắt GPU
            options.AddArgument("--no-sandbox"); // Tăng tính ổn định
            options.AddArgument("--disable-extensions"); // Tắt extension
            options.AddArgument("--blink-settings=imagesEnabled=false"); 
            options.AddArgument("--disable-javascript"); 
            options.AddArgument("--disable-css"); 
            options.AddArgument("--window-size=1920,1080"); // Cố định kích thước

            using (IWebDriver driver = new ChromeDriver(options))
            {
                try
                {
                    driver.Navigate().GoToUrl("https://vnexpress.net/tin-tuc-24h");

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    wait.Until(drv => drv.FindElement(By.XPath("//h3[@class='title-news']/a")));

                    var elements = driver.FindElements(By.XPath("//h3[@class='title-news']/a"));
                    foreach (var element in elements)
                    {
                        string title = element.Text.Trim();
                        string link = element.GetAttribute("href");

                        result += $"Tiêu đề: {title}{Environment.NewLine}";
                        result += $"Link: {link}{Environment.NewLine}";
                        result += "----------------------------------------" + Environment.NewLine;
                    }

                    if (string.IsNullOrEmpty(result))
                    {
                        result = "Không tìm thấy bài viết nào.";
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    result = "Lỗi: Không thể tải phần tử cần thiết.";
                }
                catch (Exception ex)
                {
                    result = "Lỗi không xác định: " + ex.Message;
                }
            }

            return result;
        }
    }
}
