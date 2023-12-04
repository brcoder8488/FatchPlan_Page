using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Net;
using DataDynamics.ActiveReports;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
public partial class FatchPlan : System.Web.UI.Page
{
   // _FatchPlan _FatchPlan = new _FatchPlan();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
          //  monthyear();
          //  jsondata();
        }
    }

    //protected void monthyear()
    //{
    //    for (int i = 2010; i <= Convert.ToInt32(System.DateTime.Today.Year); i++)
    //    {
    //        ddlyear.Items.Add(i.ToString());
    //        // lblyear.Text = i.ToString();
    //    }

    //    for (int i = Convert.ToInt32(12); i >= 1; i--)
    //    {
    //        DateTime dt = DateTime.Now;
    //        var ddt = dt.AddMonths(+i);
    //        ddlmonths.Items.Add(ddt.ToString("MMMM"));
    //    }
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
       SendMsg();
    }
    public class _RPlan1
    {
      //  [JsonProperty(PropertyName = "Id")]
        public string id { get; set; }

     //   [JsonProperty(PropertyName = "operator_id")]
        public string operator_id { get; set; }

      //  [JsonProperty(PropertyName = "circle_id")]
        public string circle_id { get; set; }

     //   [JsonProperty(PropertyName = "recharge_amount")]
        public string recharge_amount { get; set; }

      //  [JsonProperty(PropertyName = "recharge_talktime")]
        public string recharge_talktime { get; set; }

      //  [JsonProperty(PropertyName = "recharge_validity")]
        public string recharge_validity { get; set; }

      //  [JsonProperty(PropertyName = "recharge_short_desc")]
        public string recharge_short_desc { get; set; }

      //  [JsonProperty(PropertyName = "recharge_long_desc")]
        public string recharge_long_desc { get; set; }

      //  [JsonProperty(PropertyName = "recharge_type")]
        public string recharge_type { get; set; }

    }

    public class GetOperator
    {
       // [JsonProperty("circlecode")]
        public string circlecode { get; set; }
      //  [JsonProperty("circlename")]
        public string circlename { get; set; }
    }
    public class _FatchPlan1
    {
        public string Status { get; set; }
        public string ErrorDescription { get; set; }
        public List<_RPlan1> PlanDescription { get; set; }
        // public string Status { get; set; }
        // public string ErrorMessage { get; set; }
        // public string SuccessMessage { get; set; }

        //public List<GetOperator> data { get; set; }
    }
    public void SendMsg()
    {
        string url = null;

        try
        {
              url = "https://cyrusrecharge.in/API/CyrusPlanFatchAPI.aspx?APIID=AP325695&PASSWORD=DFD56567JHJH&Operator_Code=JIO&Circle_Code=21&MobileNumber=7408618488&data=ALL";

           // url = "https://Cyrusrecharge.in/api/GetOperator.aspx?memberid=AP325695&pin=90A72CCA45&Method=getcircle";
            //var _Resp = JsonConvert.DeserializeObject <_RPlan>(results);
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            //-- Exectute api and give response
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            string _result = response.Content;

           var C = JsonConvert.DeserializeObject<_FatchPlan1>(_result);
            //  List<_FatchPlan1> C = JsonConvert.DeserializeObject<List<_FatchPlan1>>(_result);
            //foreach (var data in C.ToList())
            //{
            //    if (data.Status == "0")
            //    {
            //        Label1.Text = data.Status.ToString();
            //        lblmsg.Text = data.ErrorMessage.ToString();
            //    }
            //    else
            //    { 
            //        lblmsg.Text = data.SuccessMessage.ToString();
            //        Label1.Text = data.Status.ToString();
            //        foreach (var data1 in data.data.ToList())
            //        {
            //            DropDownList1.Items.Add(data1.circlecode);
            //            DropDownList2.Items.Add(data1.circlename);
            //        }
            //    }
            //    //console.writeline($"{data.lat} {data.lng} {data.fixtime}");
            //}
            if (C.Status == "1")
            {
                Label1.Text = C.Status.ToString();
              //  lblmsg.Text = data.ErrorMessage.ToString();
            }
            else
            {
                Label1.Text = C.Status.ToString();
                foreach (var data1 in C.PlanDescription.ToList())
                {
                    DropDownList1.Items.Add(data1.recharge_amount);
                    DropDownList2.Items.Add(data1.recharge_short_desc);
                }
            }

        }
        catch (Exception ex)
        {

        }
    }

    //public class DataType1
    //{
    //    public string EntityList { get; set; }
    //    public string KeyName { get; set; }
    //    public string Value { get; set; }
    //}

    //public class DataType2
    //{
    //    public string Id { get; set; }
    //    public string Status { get; set; }
    //}

    //public class MyData
    //{
    //    public DataType1 data1 { get; set; }
    //    public List<DataType2> data2 { get; set; }
    //}
    //protected void jsondata()
    //{
    //    var data = @"[{
    //            ""data1"": {
    //                ""EntityList"": ""Attribute"",
    //                ""KeyName"": ""AkeyName"",
    //                ""Value"": ""Avalue""
    //                    },
    //            ""data2"": [{
    //                ""Id"": ""jsdksjkjdiejkwp12193jdmsldm"",
    //                ""Status"": ""OK""
    //            },
    //                {
    //                ""Id"": ""jsdksjdffgdfgkjdiejkwp12193jdmsldm"",
    //                ""Status"": ""oOK""
    //            }]
    //        }]"; //variable with json string

    //    var myData = JsonConvert.DeserializeObject<List<MyData>>(data);

    //    foreach (var item in myData.ToList())
    //    {
    //        foreach (var item2 in item.data2.ToList())
    //        {
    //        DropDownList1.Items.Add(item2.Id.ToString());
    //        }
    //        // Label1.Text = item.Id;
    //    }
    //    //  Console.WriteLine($"EntityList:{myData.data1.EntityList}, KeyName:{myData.data1.KeyName}");
    //}

}