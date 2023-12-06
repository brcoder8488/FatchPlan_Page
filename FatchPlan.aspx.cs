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
    DataUtility objDUT = new DataUtility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblmsg.Text = "";
            recharge_circle();
            recharge_oprator(1);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlCircle.SelectedIndex == 0)
        {
            lblmsg.Text = "Please Select State.";
            return;
        }
        if (ddlOperator.SelectedIndex == 0)
        {
            lblmsg.Text = "Please Select Operator.";
            return;
        }
        if (txtmobile.Text.Trim() == "")
        {
            lblmsg.Text = "Please Enter Mobile No.";
            return;
        }
        try
        {
            SendMsg();
        }
        catch (Exception ex)
        {
            lblmsg.Text=ex.Message.ToString(); 
        }
    }
    public class _RPlan1
    {
        public string id { get; set; }
        public string operator_id { get; set; }
        public string circle_id { get; set; }
        public string recharge_amount { get; set; }
        public string recharge_talktime { get; set; }

        public string recharge_validity { get; set; }

        public string recharge_short_desc { get; set; }

        public string recharge_long_desc { get; set; }
        public string recharge_type { get; set; }

    }
    public class _FatchPlan1
    {
        public string Status { get; set; }
        public string ErrorDescription { get; set; }
        public List<_RPlan1> PlanDescription { get; set; }

    }
    public void SendMsg()
    {
        string url = null;

        try
        {
              url = "https://cyrusrecharge.in/API/CyrusPlanFatchAPI.aspx?APIID=AP325695&PASSWORD=DFD56567JHJH&Operator_Code="+ ddlOperator.SelectedValue + "&Circle_Code="+ ddlCircle.SelectedValue + "&MobileNumber="+ txtmobile.Text.Trim() + "&data=ALL";

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
            if (C.Status == "1")
            {
                Label1.Text = C.Status.ToString();
              //  lblmsg.Text = data.ErrorMessage.ToString();
            }
            else
            {
                // #Fatch Recharge Plan...
                string tested = "";
                int i = 0;
                Label1.Text = C.Status.ToString();
                foreach (var data1 in C.PlanDescription.ToList())
                {
                    tested += @"
                        <div class=""row align-items-center"">
            <div class=""col-4 col-lg-2 text-5 text-primary text-center"">&#8377;" + data1.recharge_amount + @" <span class=""text-1 text-muted d-block"">Amount</span></div>
            <div class=""col-4 col-lg-2 text-3 text-center"">"+data1.recharge_talktime+@"<span class=""text-1 text-muted d-block"">Talktime</span></div>
            <div class=""col-4 col-lg-2 text-3 text-center"">"+data1.recharge_validity+@"<span class=""text-1 text-muted d-block"">Validity</span></div>
            <div class=""col-7 col-lg-3 my-2 my-lg-0 text-1 text-muted"">"+data1.recharge_short_desc+@"</div>
            <div class=""col-5 col-lg-3 my-2 my-lg-0 text-end text-lg-center"">
              <button class=""btn btn-sm btn-outline-primary shadow-none text-nowrap"" type=""submit"">Recharge</button>
            </div>
          </div>
          <hr class=""my-4"">
";
                    i++; 
                }
                test2.InnerHtml = tested;
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void recharge_circle()
    {
        string strSqlCircle = "select * from Api_CircleDetails where active=1 order by circleName";
        DataTable dtCircle = objDUT.GetDataTable(strSqlCircle);
        if (dtCircle.Rows.Count > 0)
        {
            ddlCircle.DataSource = dtCircle;
            ddlCircle.DataTextField = "circleName";
            ddlCircle.DataValueField = "apid";
            ddlCircle.DataBind();
            ddlCircle.Items.Insert(0, new ListItem("Select Your Circle", "0"));
        }
    }

    protected void recharge_oprator(int apid)
    {
        string strSqlOprator = "select * from Api_OpratorDetails where active=1 and apid="+apid+ " order by opratorname";
        DataTable dtOprator = objDUT.GetDataTable(strSqlOprator);
        if (dtOprator.Rows.Count > 0)
        {
            ddlOperator.DataSource = dtOprator;
            ddlOperator.DataTextField = "opratorname";
            ddlOperator.DataValueField = "opratorcode";
            ddlOperator.DataBind();
            ddlOperator.Items.Insert(0, new ListItem("Select Your Operator", "0"));
        }
    }
}