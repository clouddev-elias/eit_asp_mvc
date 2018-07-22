using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EliasIT.API
{
    public partial class ApiServer : System.Web.UI.Page
    {

        private WebRequest _request;

        protected void Page_Load(object sender, EventArgs e)
        {
            PageAsyncTask task = new PageAsyncTask(
                new BeginEventHandler(BeginAsyncOperation),
                new EndEventHandler(EndAsyncOperation),
                new EndEventHandler(TimeoutAsyncOperation),
                null
            );
            RegisterAsyncTask(task);
        }

        IAsyncResult BeginAsyncOperation(object sender, EventArgs e,
            AsyncCallback cb, object state)
        {
            _request = WebRequest.Create("http://download.cnet.com/windows/most-popular/3101-20_4-0.html");
            return _request.BeginGetResponse(cb, state);
        }

        void EndAsyncOperation(IAsyncResult ar)
        {
            string text;
            using (WebResponse response = _request.EndGetResponse(ar))
            {
                using (StreamReader reader =
                    new StreamReader(response.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
            }
       
            //Regex regex = new Regex("href\\s*=\\s*\"([^\"]*)\"", RegexOptions.IgnoreCase);
            Regex regex = new Regex(@"<li class=""listing-unit""(.*\n)*?</li>", RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(text);
            StringBuilder builder = new StringBuilder();


            //builder.Append(text);
            foreach (Match match in matches)
            {
                 builder.Append(match);
                //builder.Append("<br/>");
            }

            labeltext.Text = builder.ToString();


        }

        void TimeoutAsyncOperation(IAsyncResult ar)
        {
            labeltext.Text = "Data temporarily unavailable";
        }


        //private string RegX() {
        
        //    return "<div(?:\s*[a-z_\-]+(?:=(?:"[^"]*"|'[^']*'|[^>]+))?)*>([^<]+)<span"
        //}






















        //private object AsyncString
        //{
        //    get;
        //    set;
        //}

        //private async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        Uri uri = new Uri("http://downloads.com");

        //        try
        //        {
                    

        //            string json = await client.GetStringAsync(uri);

        //            //response.EnsureSuccessStatusCode();
        //            //response.Content.ReadAsStringAsync().ToString();

        //            labeltext.Text = json;
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle network exceptions
        //           labeltext.Text = ex.InnerException.ToString();
        //        }
        //    }
        //}

 

    }
}